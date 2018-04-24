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

            foreach (var type in specificViewModel?.Category?.CandyTypes)
            {
                var leftMargin = 24.0f;
                var rightMargin = 24.0f;
                // If first in categories.
                if (specificViewModel?.Category?.CandyTypes.IndexOf(type) == 0 ||
                    specificViewModel?.Category?.CandyTypes.IndexOf(type) == 3)
                {
                    leftMargin = 29f;
                    rightMargin = 24.0f;
                }

                var button = new ButtonCandyType(type)
                {
                    Width = 337,
                    Height = 263,
                    Margin = new Thickness(leftMargin, 10f, rightMargin, 10f) 
                };
                ButtonContainer.Children.Add(button);
            }
        }
    }
}
