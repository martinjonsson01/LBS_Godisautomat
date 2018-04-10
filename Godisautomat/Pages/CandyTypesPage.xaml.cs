using Godisautomat.Controls;
using Godisautomat.DataModels;
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

namespace Godisautomat.Pages
{
    /// <summary>
    /// Interaction logic for CandyTypesPage.xaml
    /// </summary>
    public partial class CandyTypesPage : BasePage<CandyTypesViewModel>
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public CandyTypesPage() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model.
        /// </summary>
        public CandyTypesPage(CandyTypesViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();

            foreach (var types in specificViewModel?.Category?.CandyTypes)
            {
                var button = new ButtonCandy(types)
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
