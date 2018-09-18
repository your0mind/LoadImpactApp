﻿using LoadImpactApp.DeserializableClasses.Xml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LoadImpactApp.ResultsSettings
{
    public class MetricSettingsTableWithLabels : AbstractMetricSettingsTable
    {
        public List<string> Metrics { get; set; }

        public MetricSettingsTableWithLabels()
        {
            Metrics = new List<string>();
        }

        protected override void RemoveMetricSettingsRow_Click(object sender, EventArgs e)
        {
            int rowToDelete = GetRow((Button)sender);
            Metrics.Add(((Label)GetControlFromPosition(0, rowToDelete)).Text);

            for (int i = 0; i < ColumnCount; i++)
            {
                Controls.Remove(GetControlFromPosition(i, rowToDelete));
            }

            for (int i = rowToDelete + 1; i < RowCount - 1; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    SetRow(GetControlFromPosition(j, i), i - 1);
                }
            }

            SetRow(m_AddMetricButton, RowCount - 2);
            RowCount--;
        }

        protected override void AddMetricButton_Click(object sender, EventArgs e)
        {
            var addMetricForm = new AddMetricFormWithComboBox(Metrics);
            addMetricForm.FormClosing += AddMetricForm_FormClosing;
            addMetricForm.ShowDialog();
        }

        private void AddMetricForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AddMetricSettings(new MetricSettings()
            {
                Name = ((AddMetricFormWithComboBox)sender).GetMetric(),
                Min = true,
                Median = true,
                Max = true,
                LookForStability = true,
                Precision = 2
            });
        }

        public override void AddMetricSettings(MetricSettings metricSettings)
        {
            RowCount++;
            RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            SetRow(m_AddMetricButton, RowCount - 1);

            Controls.Add(new Label() { Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Text = metricSettings.Name }, 0, RowCount - 2);
            Controls.Add(new CheckBox() { Dock = DockStyle.Fill, CheckAlign = ContentAlignment.MiddleCenter, Checked = metricSettings.Min }, 1, RowCount - 2);
            Controls.Add(new CheckBox() { Dock = DockStyle.Fill, CheckAlign = ContentAlignment.MiddleCenter, Checked = metricSettings.Min }, 2, RowCount - 2);
            Controls.Add(new CheckBox() { Dock = DockStyle.Fill, CheckAlign = ContentAlignment.MiddleCenter, Checked = metricSettings.Min }, 3, RowCount - 2);
            Controls.Add(new CheckBox() { Dock = DockStyle.Fill, CheckAlign = ContentAlignment.MiddleCenter, Checked = metricSettings.Min }, 4, RowCount - 2);
            Controls.Add(new NumericUpDown() { Value = metricSettings.Precision, Font = new Font("Microsoft Sans Serif", 10), Maximum = 5 }, 5, RowCount - 2);
            Controls.Add(new Button()
            {
                TextAlign = ContentAlignment.MiddleCenter,
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.Pink,
                ForeColor = Color.Red,
                Dock = DockStyle.Fill,
                Text = "X"
            }, 6, RowCount - 2);

            Metrics.Remove(metricSettings.Name);
        }

    }
}
