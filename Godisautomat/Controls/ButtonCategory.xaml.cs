using Godisautomat.DataModels;
using Godisautomat.IoCComponents.Base;
using Godisautomat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for ButtonCategory.xaml
    /// </summary>
    public partial class ButtonCandy : UserControl
    {
        private CandyCategory _category;

        public ButtonCandy(CandyCategory category)
        {
            InitializeComponent();
            _category = category;
            button_main.Background = new ImageBrush(new BitmapImage(new Uri(category.ImageUrl)));
            button_main.Content = category.Name;
            button_main.Click += Category_Click;
        }
        
        private void Category_Click(object sender, RoutedEventArgs e)
        {
            IoC.Application.GoToPage(ApplicationPage.CandyTypes, new CandyTypesViewModel(_category));
        }
    }
}
