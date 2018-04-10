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

        #endregion

        #region Commands

        /// <summary>
        /// The command to open CandyTypes page.
        /// </summary>
        public ICommand SelectCandyTypeCommand { get; set; }
        
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CandyTypesViewModel(CandyCategory category)
        {
            Category = category;

            // Create commands
            SelectCandyTypeCommand = new RelayParameterizedCommand(async (parameter) => await SelectCandyTypeAsync(parameter));
        }

        #endregion

        private async Task SelectCandyTypeAsync(object parameter)
        {
            IoC.Application.GoToPage(ApplicationPage.CandyDetails);

            await Task.Delay(1);
        }

    }
}
