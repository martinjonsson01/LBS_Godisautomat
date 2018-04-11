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

        public string IngredientNames {
            get
            {
                var names = "Contains:\n";
                foreach (var ingredient in Type.Ingredients)
                {
                    names += $"{ingredient.Name}, ";
                }
                return names;
            }
        }

        public List<Ingredient> AllergicIngredients
        {
            get
            {
                var allergicIngredients = new List<Ingredient>();
                foreach (var ingredient in Type.Ingredients)
                {
                    if (ingredient.IsAllergic)
                        allergicIngredients.Add(ingredient);
                }
                return allergicIngredients;
            }
        }

        #endregion

        #region Commands
        
        public ICommand BackCommand { get; set; }

        public ICommand BuyCommand { get; set; }

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
            BackCommand = new RelayCommand(() => IoC.Application.GoToPage(ApplicationPage.CandyTypes, new CandyTypesViewModel(Type.Category)));
            //BuyCommand = new RelayCommand(() => IoC.Application.GoToPage(ApplicationPage.Buy, new BuyViewModel(Type)));
        }

        #endregion
        
    }
}
