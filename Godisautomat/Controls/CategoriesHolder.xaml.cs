using Godisautomat.IoCComponents.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Godisautomat.Controls
{
    /// <summary>
    /// Interaction logic for CategoriesHolder.xaml
    /// </summary>
    public partial class CategoriesHolder : UserControl
    {
        public CategoriesHolder()
        {
            InitializeComponent();

            // If not in designer.
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                foreach (var category in IoC.Application.CandyCategories)
                {
                    var leftMargin = 42.5f;
                    var rightMargin = 42.5f;
                    // If first in categories.
                    if (IoC.Application.CandyCategories.IndexOf(category) == 0 ||
                        IoC.Application.CandyCategories.IndexOf(category) == 3)
                    {
                        leftMargin = 48f;
                        rightMargin = 42.5f;
                    }
                    // If last in categories.
                    if (IoC.Application.CandyCategories.IndexOf(category) == IoC.Application.CandyCategories.Count - 1)
                    {
                        leftMargin = 42.5f;
                        rightMargin = 40f;
                    }

                    var button = new ButtonCandy(category)
                    {
                        Width = 367,
                        Height = 303,
                        Margin = new Thickness(leftMargin, 10f, rightMargin, 10f)
                    };
                    ButtonContainer.Children.Add(button);
                }
            }
        }
    }
}
