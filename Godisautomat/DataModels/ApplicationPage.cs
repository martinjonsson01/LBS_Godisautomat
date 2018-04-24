using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godisautomat.DataModels
{
    /// <summary>
    /// A page of the application
    /// </summary>
    public enum ApplicationPage
    {
        /// <summary>
        /// The initial categories page.
        /// </summary>
        Categories = 0,

        /// <summary>
        /// The candy types page.
        /// </summary>
        CandyTypes = 1,

        /// <summary>
        /// The candy type details page.
        /// </summary>
        CandyDetails = 2,

        /// <summary>
        /// The buy page.
        /// </summary>
        Buy = 3,

        /// <summary>
        /// The card payment modal page.
        /// </summary>
        ModalCardPayment = 4,

        /// <summary>
        /// The cash payment modal page.
        /// </summary>
        ModalCashPayment = 5,

        /// <summary>
        /// The payment success modal page.
        /// </summary>
        ModalPaymentSuccess = 6,

        /// <summary>
        /// The payment failure modal page.
        /// </summary>
        ModalPaymentFailure = 7,

        /// <summary>
        /// No page.
        /// </summary>
        None = 8,
    }
}
