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
    /// Interaction logic for CardPaymentPage.xaml
    /// </summary>
    public partial class CardPaymentPage : BasePage<CardPaymentViewModel>
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public CardPaymentPage() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model.
        /// </summary>
        public CardPaymentPage(CardPaymentViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }
    }
}
