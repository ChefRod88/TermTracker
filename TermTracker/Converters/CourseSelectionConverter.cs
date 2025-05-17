using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using TermTracker.Models;

namespace TermTracker.Converters
{
    public class CourseSelectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var selectedCourse = value as Course;
            var currentCourse = parameter as Course;

            return selectedCourse == currentCourse ? Colors.DodgerBlue : Colors.DarkGray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}

