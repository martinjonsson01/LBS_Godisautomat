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
    /// Interaction logic for CandyDetailsPage.xaml
    /// </summary>
    public partial class CandyDetailsPage : BasePage<CandyDetailsViewModel>
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public CandyDetailsPage() : base()
        {
            PageUnloadAnimation = Animation.PageAnimation.SlideInFromLeft;
            PageLoadAnimation = Animation.PageAnimation.SlideInFromRight;
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model.
        /// </summary>
        public CandyDetailsPage(CandyDetailsViewModel specificViewModel) : base(specificViewModel)
        {
            PageUnloadAnimation = Animation.PageAnimation.SlideInFromLeft;
            PageLoadAnimation = Animation.PageAnimation.SlideInFromRight;
            InitializeComponent();
        }
    }
}
