using Godisautomat.Animation;
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
    /// <summary>
    /// The View Model for a candy types screen
    /// </summary>
    public class CandyTypesViewModel : BaseViewModel
    {
        #region Public Properties
        
        public CandyCategory Category { get; set; }

        public string CandyTypeName => Category.Name;

        #endregion

        #region Commands

        /// <summary>
        /// The command to open CandyTypes page.
        /// </summary>
        public ICommand SelectCandyTypeCommand { get; set; }

        public ICommand BackCommand { get; set; }

        #endregion

        #region Constructor

        public CandyTypesViewModel()
        {

        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public CandyTypesViewModel(CandyCategory category)
        {
            Category = category;

            // Create commands
            SelectCandyTypeCommand = new RelayParameterizedCommand(async (parameter) => 
            await SelectCandyTypeAsync(parameter));
            BackCommand = new RelayCommand(() => Back());
        }

        #endregion

        private async Task SelectCandyTypeAsync(object parameter)
        {
            IoC.Application.GoToPage(ApplicationPage.CandyDetails, new CandyDetailsViewModel { PageLoadAnimation = PageAnimation.SlideInFromLeft, PageUnloadAnimation = PageAnimation.SlideOutToRight });

            await Task.Delay(1);
        }

        private void Back()
        {
            PageUnloadAnimation = PageAnimation.SlideOutToRight;
            IoC.Application.GoToPage(ApplicationPage.Categories, new CategoriesViewModel { PageLoadAnimation = PageAnimation.SlideInFromLeft });
        }

    }
}
