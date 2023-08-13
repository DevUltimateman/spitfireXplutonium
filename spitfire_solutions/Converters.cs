using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;

#nullable enable

namespace spitfire_solutions
{
    public class ObjectToUIElementConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return DependencyProperty.UnsetValue;
            if (!uiElements.TryGetValue(value, out var element))
            {
                if (value is UIElement elm)
                {
                    element = elm;
                }
                else
                {
                    element = new ContentControl()
                    { DataContext = value, Content = value };
                }
                uiElements.Add(value, element);
            }
            return element;
        }

        private readonly ConditionalWeakTable<object, UIElement> uiElements
            = new ConditionalWeakTable<object, UIElement>();

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static ObjectToUIElementConverter Default { get; } = new ObjectToUIElementConverter();
    }
}
