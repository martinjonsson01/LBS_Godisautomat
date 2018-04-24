using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System;
using System.ComponentModel;
using Godisautomat.Animation;
using Godisautomat.ViewModels.Base;
using Godisautomat.IoCComponents.Base;

namespace Godisautomat.Pages
{
    /// <summary>
    /// The base page for all pages to gain base functionality
    /// </summary>
    public class BasePage : UserControl
    {
        #region Private Member

        /// <summary>
        /// The View Model associated with this page
        /// </summary>
        private object mViewModel;

        #endregion

        #region Public Properties
        
        /// <summary>
        /// The time any slide animation takes to complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.4f;

        /// <summary>
        /// A flag to indicate if this page should animate out on load.
        /// Useful for when we are moving the page to another frame
        /// </summary>
        public bool ShouldAnimateOut { get; set; }

        /// <summary>
        /// The View Model associated with this page
        /// </summary>
        public object ViewModelObject
        {
            get => mViewModel;
            set
            {
                // If nothing has changed, return
                if (mViewModel == value)
                    return;

                // Update the value
                mViewModel = value;

                // Fire the view model changed method
                OnViewModelChanged();

                // Set the data context for this page
                DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage()
        {
            // Don't bother animating in design time
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            if (mViewModel is BaseViewModel vm)
            {
                // If we are animating in, hide to begin with
                if (vm.PageLoadAnimation != PageAnimation.None)
                    Visibility = Visibility.Collapsed;
            }

            // Listen out for the page loading
            Loaded += BasePage_LoadedAsync;
        }

        #endregion

        #region Animation Load / Unload

        /// <summary>
        /// Once the page is loaded, perform any required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_LoadedAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            // If we are setup to animate out on load
            if (ShouldAnimateOut)
                // Animate out the page
                await AnimateOutAsync();
            // Otherwise...
            else
                // Animate the page in
                await AnimateInAsync();
        }

        /// <summary>
        /// Animates the page in
        /// </summary>
        /// <returns></returns>
        public async Task AnimateInAsync()
        {
            if (mViewModel is BaseViewModel vm)
            {
                // Make sure we have something to do
                if (vm.PageLoadAnimation == PageAnimation.None)
                    return;

                switch (vm.PageLoadAnimation)
                {
                    case PageAnimation.SlideInFromRight:

                        // Start the animation
                        await this.SlideAndFadeInAsync(AnimationSlideInDirection.Right, false, SlideSeconds, size: (int)Application.Current.MainWindow.Width, fade: false);

                        break;

                    case PageAnimation.SlideInFromLeft:

                        // Start the animation
                        await this.SlideAndFadeInAsync(AnimationSlideInDirection.Left, false, SlideSeconds, size: (int)Application.Current.MainWindow.Width, fade: false);

                        break;
                }
            }
        }

        /// <summary>
        /// Animates the page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOutAsync()
        {
            if (mViewModel is BaseViewModel vm)
            {
                // Make sure we have something to do
                if (vm.PageUnloadAnimation == PageAnimation.None)
                    return;

                switch (vm.PageUnloadAnimation)
                {
                    case PageAnimation.SlideOutToLeft:

                        // Start the animation
                        await this.SlideAndFadeOutAsync(AnimationSlideInDirection.Left, SlideSeconds, fade: false);

                        break;

                    case PageAnimation.SlideOutToRight:

                        // Start the animation
                        await this.SlideAndFadeOutAsync(AnimationSlideInDirection.Right, SlideSeconds, fade: false);

                        break;
                }
            }
        }

        #endregion

        /// <summary>
        /// Fired when the view model changes
        /// </summary>
        protected virtual void OnViewModelChanged()
        {
            
        }
    }

    /// <summary>
    /// A base page with added ViewModel support
    /// </summary>
    public class BasePage<VM> : BasePage
        where VM : BaseViewModel, new()
    {
        #region Public Properties

        /// <summary>
        /// The view model associated with this page
        /// </summary>
        public VM ViewModel
        {
            get => (VM)ViewModelObject;
            set => ViewModelObject = value;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage() : base()
        {
            // Create a default view model
            ViewModel = IoC.Get<VM>();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">The specific view model to use, if any</param>
        public BasePage(VM specificViewModel = null) : base()
        {
            // Set specific view model
            if (specificViewModel != null)
            {
                ViewModel = specificViewModel;
            }
            else
                // Create a default view model
                ViewModel = IoC.Get<VM>();
        }

        #endregion
    }
}
