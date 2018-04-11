using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godisautomat.Animation
{
    /// <summary>
    /// Styles of page animations for appearing/disappearing
    /// </summary>
    public enum PageAnimation
    {
        /// <summary>
        /// No animation takes place
        /// </summary>
        None = 0,

        /// <summary>
        /// The page slides in and fades in from the right
        /// </summary>
        SlideInFromRight = 1,

        /// <summary>
        /// The page slides out and fades out to the left
        /// </summary>
        SlideOutToLeft = 2,

        /// <summary>
        /// The page slides out and fades out to the right
        /// </summary>
        SlideOutToRight = 3,

        /// <summary>
        /// The page slides in and fades in from the left
        /// </summary>
        SlideInFromLeft = 4,
    }
}
