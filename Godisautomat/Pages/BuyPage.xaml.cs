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
    /// Interaction logic for BuyPage.xaml
    /// </summary>
    public partial class BuyPage : BasePage<BuyViewModel>
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public BuyPage() : base()
        {
            PageUnloadAnimation = Animation.PageAnimation.SlideInFromLeft;
            PageLoadAnimation = Animation.PageAnimation.SlideInFromRight;
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model.
        /// </summary>
        public BuyPage(BuyViewModel specificViewModel) : base(specificViewModel)
        {
            PageUnloadAnimation = Animation.PageAnimation.SlideInFromLeft;
            PageLoadAnimation = Animation.PageAnimation.SlideInFromRight;
            InitializeComponent();
        }
    }
}
