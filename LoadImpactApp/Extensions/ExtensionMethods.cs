using System;
using System.Collections.Generic;
using System.Linq;

namespace LoadImpactApp.Extensions
{
    public static class ExtensionMethods
    {
        public static T Median<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            int count = source.Count();
            if (count == 0)
            {
                throw new InvalidOperationException();
            }

            var sortedList = from number in source
                             orderby number
                             select number;

            int itemIndex = sortedList.Count() / 2;

            if (sortedList.Count() % 2 == 0)
            {
                return (sortedList.ElementAt(itemIndex) + sortedList.ElementAt(itemIndex - 1)) / 2;
            }
            else
            {
                return sortedList.ElementAt(itemIndex);
            }
        }

        public static double Median<T>(this IEnumerable<T> numbers, Func<T, double> selector)
        {
            return (from num in numbers select selector(num)).Median();
        }
    }
}
}
