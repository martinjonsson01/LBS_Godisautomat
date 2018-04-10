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
    /// The View Model for a categories screen
    /// </summary>
    public class CategoriesViewModel : BaseViewModel
    {
        #region Public Properties
        
        #endregion

        #region Commands

        /// <summary>
        /// The command to open CandyTypes page.
        /// </summary>
        public ICommand SelectCategoryCommand { get; set; }
        
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CategoriesViewModel()
        {
            // Create commands
            SelectCategoryCommand = new RelayParameterizedCommand(async (parameter) => await SelectCategoryAsync(parameter));
        }

        #endregion

        private async Task SelectCategoryAsync(object parameter)
        {
            IoC.Application.GoToPage(ApplicationPage.CandyTypes);

            await Task.Delay(1);
        }

    }
}
