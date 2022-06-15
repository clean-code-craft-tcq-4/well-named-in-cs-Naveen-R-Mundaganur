using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TelCo.ColorCoder
{
  internal class ColorPair
    {
        /// <summary>
        /// Array of Major colors
        /// </summary>
        internal Color[] colorMapMajor;
        /// <summary>
        /// Array of minor colors
        /// </summary>
        internal Color[] colorMapMinor;
        
        internal Color majorColor;
        internal Color minorColor;
        
        public override string ToString()
        {
            return string.Format("MajorColor:{0}, MinorColor:{1}", majorColor.Name, minorColor.Name);
        }
        public ColorPair()
        {

        }
        public ColorPair(Color[] objMajorColor, Color[] objMinorColor)
        {
            this.colorMapMajor = objMajorColor;
            this.colorMapMinor = objMinorColor;
        }

    }
}
