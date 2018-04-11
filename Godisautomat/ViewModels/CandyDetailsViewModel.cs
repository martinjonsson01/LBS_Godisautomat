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
    /// The View Model for a candy details screen
    /// </summary>
    public class CandyDetailsViewModel : BaseViewModel
    {
        #region Public Properties

        public CandyType Type { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to open CandyTypes page.
        /// </summary>
        public ICommand SelectCandyTypeCommand { get; set; }

        #endregion

        #region Constructor

        public CandyDetailsViewModel()
        {

        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public CandyDetailsViewModel(CandyType type)
        {
            Type = type;

            // Create commands
            //SelectCandyTypeCommand = new RelayParameterizedCommand(async (parameter) => await SelectCandyTypeAsync(parameter));
        }

        #endregion

        /*private async Task SelectCandyTypeAsync(object parameter)
        {
            IoC.Application.GoToPage(ApplicationPage.CandyDetails);

            await Task.Delay(1);
        }*/

    }
}
