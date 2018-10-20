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
    /// <summary>
    /// The View Model for a candy details screen
    /// </summary>
    public class CandyDetailsViewModel : BaseViewModel
    {
        private string _currentAmount;
        #region Public Properties

        public CandyType Type { get; set; }

        public string TotalPrice
        {
            get
            {
                var priceString = Type.Price.Substring(0, Type.Price.Length - 3);
                var price = int.Parse(priceString);
                var totalPrice = Math.Pow(price, Type.Sizes.IndexOf(CurrentAmount)) + price;
                if (CurrentAmount == "9001 g")
                    return "Bush did 9/11 kr";
                return $"{totalPrice} kr";
            }
        }

        public string IngredientNames
        {
            get
            {
                var names = "Contains:\n";
                foreach (var ingredient in Type.Ingredients)
                {
                    names += $"{ingredient.Name}";
                    if (Type.Ingredients.Last() != ingredient)
                        names += ", ";
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

        public string CurrentAmount
        {
            get => _currentAmount;
            set
            {
                _currentAmount = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public Visibility AmountMenuVisibility { get; set; } = Visibility.Hidden;

        #endregion

        #region Commands

        public ICommand BackCommand { get; set; }

        public ICommand BuyCommand { get; set; }

        public ICommand WeightCommand { get; set; }

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
            CurrentAmount = Type.Sizes[0];

            // Create commands
            BackCommand = new RelayCommand(() =>
            {
                PageUnloadAnimation = PageAnimation.SlideOutToRight;
                IoC.Application.GoToPage(ApplicationPage.CandyTypes, new CandyTypesViewModel(Type.Category) { PageLoadAnimation = PageAnimation.SlideInFromLeft });
            });
            BuyCommand = new RelayCommand(() => IoC.Application.GoToPage(ApplicationPage.Buy, new BuyViewModel(Type, CurrentAmount) { PageLoadAnimation = PageAnimation.SlideInFromRight, PageUnloadAnimation = PageAnimation.SlideOutToRight }));
            WeightCommand = new RelayParameterizedCommand((size) =>
            {
                if (size is string sizeString)
                {
                    CurrentAmount = sizeString;
                    AmountMenuVisibility = Visibility.Hidden;
                }
                else
                {
                    AmountMenuVisibility = Visibility.Visible;
                }
            });
        }

        #endregion

    }
}
