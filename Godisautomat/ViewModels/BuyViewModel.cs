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
    public class BuyViewModel : BaseViewModel
    {
        #region Public Properties

        public CandyType Type { get; set; }

        #endregion

        #region Commands

        public ICommand BackCommand { get; set; }

        public ICommand CardCommand { get; set; }

        public ICommand CashCommand { get; set; }

        #endregion

        #region Constructor

        public BuyViewModel()
        {

        }

        public BuyViewModel(CandyType type)
        {
            Type = type;

            // Create commands
            BackCommand = new RelayCommand(() => IoC.Application.GoToPage(ApplicationPage.CandyDetails, new CandyDetailsViewModel(Type)));
            CardCommand = new RelayCommand(() => IoC.Application.GoToPage(ApplicationPage.CandyDetails, new CandyTypesViewModel(Type.Category)));
            CashCommand = new RelayCommand(() => IoC.Application.GoToPage(ApplicationPage.CandyTypes, new CandyTypesViewModel(Type.Category)));
        }

        #endregion

    }
}
