using System;

namespace TelCo.ColorCoder
{
     /// <summary>
        /// Given the two colors the function returns the pair number corresponding to them
        /// </summary>
        /// <param name="colorinfo">Color pair with major and minor color</param>
        /// <returns></returns>
        internal static int GetPairNumberFromColor(ColorPair colorinfo, ColorPair objColorPairs)
        {
            // Find the major color in the array and get the index
            int majorIndex = -1;
            for (int color_index = 0; color_index < objColorPairs.colorMapMajor.Length; color_index++)
            {
                if (objColorPairs.colorMapMajor[color_index] == colorinfo.majorColor)
                {
                    majorIndex = color_index;
                    break;
                }
            }

            // Find the minor color in the array and get the index
            int minorIndex = -1;
            for (int color_index = 0; color_index < objColorPairs.colorMapMinor.Length; color_index++)
            {
                if (objColorPairs.colorMapMinor[color_index] == colorinfo.minorColor)
                {
                    minorIndex = color_index;
                    break;
                }
            }
            // If colors can not be found throw an exception
            if (majorIndex == -1 || minorIndex == -1)
            {
                throw new ArgumentException(
                    string.Format("Unknown Colors: {0}", colorinfo.ToString()));
            }

            // Compute pair number and Return  
            // (Note: +1 in compute is because pair number is 1 based, not zero)
            return (majorIndex * objColorPairs.colorMapMinor.Length) + (minorIndex + 1);
        }
}
