using System;
using System.Collections.Generic;
using System.Text;

namespace TelCo.ColorCoder
{
    internal static class ColorCode
    {
        /// <summary>
        /// Given a pair number function returns the major and minor colors in that order
        /// </summary>
        /// <param name="pairNumber">Pair number of the color to be fetched</param>
        /// <returns></returns>
        internal static ColorPairs GetColorFromPairNumber(int pairNumber, ColorPairs objColorPairs)
        {
            // The function supports only 1 based index. Pair numbers valid are from 1 to 25
            int minorSize = objColorPairs.colorMapMajor.Length;
            int majorSize = objColorPairs.colorMapMinor.Length;
            if (pairNumber < 1 || pairNumber > minorSize * majorSize)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            }

            // Find index of major and minor color from pair number
            int zeroBasedPairNumber = pairNumber - 1;
            int majorIndex = zeroBasedPairNumber / minorSize;
            int minorIndex = zeroBasedPairNumber % minorSize;

            // Construct the return val from the arrays
            ColorPairs pair = new ColorPairs
            {
                majorColor = objColorPairs.colorMapMajor[majorIndex],
                minorColor = objColorPairs.colorMapMinor[minorIndex]
            };

            // return the value
            return pair;
        }

        /// <summary>
        /// Given the two colors the function returns the pair number corresponding to them
        /// </summary>
        /// <param name="colorinfo">Color pair with major and minor color</param>
        /// <returns></returns>
        internal static int GetPairNumberFromColor(ColorPairs colorinfo, ColorPairs objColorPairs)
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
}
