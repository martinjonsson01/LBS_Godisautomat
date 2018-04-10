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

            foreach (var category in IoC.Application.CandyCategories)
            {
                var button = new ButtonCandy(category)
                {
                    Width = 367,
                    Height = 303,
                    Margin = new Thickness(70, 20, 70, 20)
                };
                ButtonContainer.Children.Add(button);
            }
        }
    }
}
