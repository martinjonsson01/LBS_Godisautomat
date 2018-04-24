using Godisautomat.DataModels;
using Godisautomat.IoCComponents.Base;
using Godisautomat.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Godisautomat.ViewModels
{
    public class CashPaymentViewModel : BaseViewModel
    {
        #region Public Properties
        
        public CandyType Type { get; set; }

        public string Amount { get; set; }

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

        #endregion

        #region Constructor

        public CashPaymentViewModel()
        {

        }

        public CashPaymentViewModel(CandyType type, string amount, BuyViewModel parentViewModel)
        {
            Type = type;
            Amount = amount;
            BackCommand = new RelayCommand(() => parentViewModel.GoToModal(ApplicationPage.None));
        }

        #endregion

    }
}
