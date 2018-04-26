using Godisautomat.Animation;
using Godisautomat.DataModels;
using Godisautomat.IoCComponents.Base;
using Godisautomat.Pages;
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
    public class BuyViewModel : BaseViewModel
    {
        #region Public Properties

        public CandyType Type { get; set; }

        public string Amount { get; set; }

        public BaseViewModel CurrentModalViewModel { get; set; }

        public ApplicationPage CurrentModalPage { get; private set; } = ApplicationPage.None;

        public float DarkeningGridOpacity { get; set; } = 0.0f;

        public Visibility DarkeningGridVisibility { get; set; } = Visibility.Hidden;

        public string TotalPrice
        {
            get
            {
                var priceString = Type.Price.Substring(0, Type.Price.Length - 3);
                var price = int.Parse(priceString);
                var totalPrice = price * Type.Sizes.IndexOf(Amount) + price;
                return $"{totalPrice} kr";
            }
        }

        #endregion

        #region Commands

        public ICommand BackCommand { get; set; }

        public ICommand CardCommand { get; set; }

        public ICommand CashCommand { get; set; }

        public ICommand PayCommand { get; set; }

        #endregion

        #region Constructor

        public BuyViewModel()
        {

        }

        public BuyViewModel(CandyType type, string amount)
        {
            Type = type;
            Amount = amount;
            
            // Create commands
            BackCommand = new RelayCommand(() =>
            {
                PageUnloadAnimation = PageAnimation.SlideOutToRight;
                IoC.Application.GoToPage(ApplicationPage.CandyDetails, new CandyDetailsViewModel(Type) { PageLoadAnimation = PageAnimation.SlideInFromLeft });
            });
            CardCommand = new RelayCommand(() => 
            {
                DarkeningGridVisibility = Visibility.Visible;
                DarkeningGridOpacity = 0.9f;
                IoC.Application.DarkeningGridOpacity = 0.9f;
                IoC.Application.PayButtonVisibility = Visibility.Visible;
                GoToModal(ApplicationPage.ModalCardPayment, new CardPaymentViewModel(Type, Amount, this));
            });
            CashCommand = new RelayCommand(() =>
            {
                DarkeningGridVisibility = Visibility.Visible;
                DarkeningGridOpacity = 0.9f;
                IoC.Application.DarkeningGridOpacity = 0.9f;
                IoC.Application.PayButtonVisibility = Visibility.Visible;
                GoToModal(ApplicationPage.ModalCashPayment, new CashPaymentViewModel(Type, Amount, this));
            });
            PayCommand = new RelayCommand(() =>
            {
                DarkeningGridVisibility = Visibility.Visible;
                DarkeningGridOpacity = 0.9f;
                IoC.Application.DarkeningGridOpacity = 0.9f;
                IoC.Application.PayButtonVisibility = Visibility.Visible;

                // 5% risk of not being successful.
                var rand = IoC.Application.Random.Next(2);
                bool successful = rand != 1;
                if (successful)
                    GoToModal(ApplicationPage.ModalPaymentSuccess, new PaymentSuccessViewModel(this));
                else
                    GoToModal(ApplicationPage.ModalPaymentFailure, new PaymentFailureViewModel(this));

                IoC.Application.PayButtonVisibility = Visibility.Hidden;
            });

            // Update application BuyViewModel property.
            IoC.Application.BuyViewModel = this;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Navigates to the specified modal
        /// </summary>
        /// <param name="page">The modal page to go to</param>
        /// <param name="viewModel">The view model, if any, to set explicitly to the new modal page</param>
        public void GoToModal(ApplicationPage page, BaseViewModel viewModel = null)
        {
            // Set the view model
            CurrentModalViewModel = viewModel;

            // See if page has changed
            var different = CurrentModalPage != page;

            // Set the current page
            CurrentModalPage = page;

            if (page == ApplicationPage.None)
            {
                DarkeningGridOpacity = 0.0f;
                IoC.Application.DarkeningGridOpacity = 0.0f;
                IoC.Application.PayButtonVisibility = Visibility.Hidden;
                DarkeningGridVisibility = Visibility.Hidden;
            }

            // If the page hasn't changed, fire off notification
            // So pages still update if just the view model has changed
            if (!different)
                OnPropertyChanged(nameof(CurrentModalPage));
        }

        #endregion

    }
}
