using LoadImpactApp.DeserializableClasses.Xml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LoadImpactApp
{
    enum MetricsTlpMode { WithLabels, WithTextBoxes };

    internal sealed class MetricsTableLayoutPanel : TableLayoutPanel
    {
        private List<string> m_Metrics;
        private Control m_MetricControl;
        private Button m_AddMetricButton;
        private Form m_AddMetricForm;

        public MetricsTlpMode Mode { get; set; }

        public MetricsTableLayoutPanel(MetricsTlpMode mode, List<string> m = null)
        {
            if (m != null)
            {
                m_Metrics = m;
                m_Metrics.Sort();
            }

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            Mode = mode;

            ColumnCount = 6;
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));

            Controls.Add(new Label() { Dock = DockStyle.Fill, Text = "Min", TextAlign = ContentAlignment.MiddleCenter }, 1, 0);
            Controls.Add(new Label() { Dock = DockStyle.Fill, Text = "Avg", TextAlign = ContentAlignment.MiddleCenter }, 2, 0);
            Controls.Add(new Label() { Dock = DockStyle.Fill, Text = "Max", TextAlign = ContentAlignment.MiddleCenter }, 3, 0);
            Controls.Add(new Label() { Dock = DockStyle.Fill, Text = "Arithmetic precision", TextAlign = ContentAlignment.MiddleCenter }, 4, 0);

            RowCount = 2;
            RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 30));

            m_AddMetricButton = new Button() { Dock = DockStyle.Fill, Text = "Add metric", BackColor = Color.WhiteSmoke };
            m_AddMetricButton.Click += AddButton_Click;
            Controls.Add(m_AddMetricButton, 0, 1);

            ControlAdded += ResultsTableLayoutPanel_ControlAdded;
        }

        private void ResultsTableLayoutPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control is Button)
                e.Control.Click += Control_Click;
        }

        private void Control_Click(object sender, EventArgs e)
        {
            SuspendLayout();
            int rowToDelete = GetRow((Button)sender);

            if (Mode == MetricsTlpMode.WithLabels)
            {
                m_Metrics.Add(((Label)GetControlFromPosition(0, rowToDelete)).Text);
                m_Metrics.Sort();
            }
            for (int i = 0; i < ColumnCount; i++)
            {
                var control = GetControlFromPosition(i, rowToDelete);
                Controls.Remove(control);
            }

            for (int i = rowToDelete + 1; i < RowCount - 1; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    var control = GetControlFromPosition(j, i);
                    SetRow(control, i - 1);
                }
            }
            SetRow(m_AddMetricButton, RowCount - 2);
            RowCount--;
            ResumeLayout();
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {

            m_AddMetricForm = new Form()
            {
                FormBorderStyle = FormBorderStyle.FixedSingle,
                StartPosition = FormStartPosition.CenterParent,
                Size = new Size(310, 110),
                MaximizeBox = false,
                MinimizeBox = false,
                ShowIcon = false,
            };

            if (Mode == MetricsTlpMode.WithLabels)
            {
                m_MetricControl = new ComboBox() { Size = new Size(170, 21), Location = new Point(20, 30), DataSource = m_Metrics };
            }
            else
            {
                m_MetricControl = new TextBox() { Size = new Size(170, 21), Location = new Point(20, 30) };
            }
            m_AddMetricForm.Controls.Add(m_MetricControl);

            var okButton = new Button() { Text = "OK", Location = new Point(m_MetricControl.Location.X + m_MetricControl.Width + 10, m_MetricControl.Location.Y - 1) };
            m_AddMetricForm.Controls.Add(okButton);

            var label = new Label() { Text = "Metric name:", Location = new Point(m_MetricControl.Location.X - 3, m_MetricControl.Location.Y - 15) };
            m_AddMetricForm.Controls.Add(label);

            okButton.Click += OkButton_Click;
            m_AddMetricForm.ShowDialog();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            string metric = null;
            if (Mode == MetricsTlpMode.WithLabels)
            {
                if (((ComboBox)m_MetricControl).SelectedItem != null)
                    metric = ((ComboBox)m_MetricControl).SelectedItem.ToString();
                m_Metrics.Remove(metric);
            }
            else
            {
                metric = ((TextBox)m_MetricControl).Text;
            }

            AddMetricSettings(new MetricSettings() { Name = metric, Min = true, Avg = true, Max = true, Precision = 2 });
            m_AddMetricForm.Close();
        }

        public void AddMetricSettings(MetricSettings metricSettings)
        {
            SuspendLayout();
            if (metricSettings.Name != "" && metricSettings.Name != null)
            {
                RowCount++;
                RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                SetRow(m_AddMetricButton, RowCount - 1);

                if (Mode == MetricsTlpMode.WithLabels)
                {
                    Controls.Add(new Label() { Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Text = metricSettings.Name }, 0, RowCount - 2);
                }
                else
                {
                    Controls.Add(new TextBox() { Dock = DockStyle.Fill, Text = metricSettings.Name }, 0, RowCount - 2);
                }
                Controls.Add(new CheckBox() { Dock = DockStyle.Fill, Checked = metricSettings.Min, CheckAlign = ContentAlignment.MiddleCenter }, 1, RowCount - 2);
                Controls.Add(new CheckBox() { Dock = DockStyle.Fill, Checked = metricSettings.Avg, CheckAlign = ContentAlignment.MiddleCenter }, 2, RowCount - 2);
                Controls.Add(new CheckBox() { Dock = DockStyle.Fill, Checked = metricSettings.Max, CheckAlign = ContentAlignment.MiddleCenter }, 3, RowCount - 2);
                Controls.Add(new NumericUpDown() { Dock = DockStyle.Fill, Value = metricSettings.Precision, Font = new Font("Microsoft Sans Serif", 10), Maximum = 5 }, 4, RowCount - 2);
                Controls.Add(new Button()
                {
                    Dock = DockStyle.Fill,
                    FlatStyle = FlatStyle.Popup,
                    BackColor = Color.Pink,
                    Text = "X",
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.Red
                }, 5, RowCount - 2);
            }
            ResumeLayout();
        }

        public void AddRangeMetricSettings(List<MetricSettings> range)
        {
            foreach (var item in range)
            {
                AddMetricSettings(item);
            }
        }

        public List<MetricSettings> GetMetricsSettings()
        {
            var metricsSettings = new List<MetricSettings>();
            for (int i = 1; i < RowCount - 1; i++)
            {
                metricsSettings.Add(new MetricSettings()
                {
                    Name = GetControlFromPosition(0, i).Text,
                    Min = ((CheckBox)GetControlFromPosition(1, i)).Checked,
                    Avg = ((CheckBox)GetControlFromPosition(2, i)).Checked,
                    Max = ((CheckBox)GetControlFromPosition(3, i)).Checked,
                    Precision = (int)((NumericUpDown)GetControlFromPosition(4, i)).Value
                });
            }

            return metricsSettings;
        }
    }
}
