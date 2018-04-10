using Godisautomat.DataModels;
using Godisautomat.IoCComponents.Base;
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
    /// Interaction logic for ButtonCandyType.xaml
    /// </summary>
    public partial class ButtonCandyType : UserControl
    {
        public ButtonCandyType(CandyType type)
        {
            InitializeComponent();
            button_main.Background = new ImageBrush(new BitmapImage(new Uri(type.ImageUrl)));
            button_main.Content = type.Name;
            button_main.Click += CandyType_Click;
        }

        private void CandyType_Click(object sender, RoutedEventArgs e)
        {
            IoC.Application.GoToPage(ApplicationPage.CandyDetails);
        }
    }
}
