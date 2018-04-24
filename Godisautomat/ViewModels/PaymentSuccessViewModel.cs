using Godisautomat.Animation;
using Godisautomat.DataModels;
using Godisautomat.IoCComponents.Base;
using Godisautomat.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Godisautomat.ViewModels
{
    public class PaymentSuccessViewModel : BaseViewModel
    {
        #region Public Properties
        
        #endregion

        #region Commands
        
        public ICommand DoneCommand { get; set; }

        #endregion

        #region Constructor

        public PaymentSuccessViewModel()
        {

        }

        public PaymentSuccessViewModel(BuyViewModel parentViewModel)
        {
            DoneCommand = new RelayCommand(() =>
            {
                //parentViewModel.GoToModal(ApplicationPage.None);
                IoC.Application.DarkeningGridOpacity = 0.0f;
                IoC.Application.PayButtonVisibility = Visibility.Hidden;
                IoC.Application.GoToPage(ApplicationPage.Categories, new CategoriesViewModel { PageLoadAnimation = PageAnimation.None });
            });
        }

        #endregion

    }
}
