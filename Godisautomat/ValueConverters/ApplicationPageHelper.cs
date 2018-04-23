using Godisautomat.DataModels;
using Godisautomat.IoCComponents.Base;
using Godisautomat.Pages;
using Godisautomat.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godisautomat.ValueConverters
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public static class ApplicationPageHelpers
    {
        /// <summary>
        /// Takes a <see cref="ApplicationPage"/> and a view model, if any, and creates the desired page
        /// </summary>
        /// <param name="page"></param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static BasePage ToBasePage(this ApplicationPage page, object viewModel = null)
        {
            // Find the appropriate page
            switch (page)
            {
                case ApplicationPage.Categories:
                    return new CategoriesPage(viewModel as CategoriesViewModel);

                case ApplicationPage.CandyTypes:
                    return new CandyTypesPage(viewModel as CandyTypesViewModel);

                case ApplicationPage.CandyDetails:
                    return new CandyDetailsPage(viewModel as CandyDetailsViewModel);

                case ApplicationPage.Buy:
                    return new BuyPage(viewModel as BuyViewModel);

                default:
                    Debugger.Break();
                    return null;
            }
        }

        /// <summary>
        /// Converts a <see cref="BasePage"/> to the specific <see cref="ApplicationPage"/> that is for that type of page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static ApplicationPage ToApplicationPage(this BasePage page)
        {
            // Find application page that matches the base page
            if (page is CategoriesPage)
                return ApplicationPage.Categories;

            if (page is CandyTypesPage)
                return ApplicationPage.CandyTypes;

            if (page is CandyDetailsPage)
                return ApplicationPage.CandyDetails;

            if (page is BuyPage)
                return ApplicationPage.Buy;

            // Alert developer of issue
            Debugger.Break();
            return default(ApplicationPage);
        }
    }
}
