using System;
using System.Diagnostics;
using System.Drawing;

namespace TelCo.ColorCoder
{
    /// <summary>
    /// The 25-pair color code, originally known as even-count color code, 
    /// is a color code used to identify individual conductors in twisted-pair 
    /// wiring for telecommunications.
    /// This class provides the color coding and 
    /// mapping of pair number to color and color to pair number.
    /// </summary>
    class Program
    {                       
        
        /// <summary>
        /// Test code for the class
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            //Major and Minor Color Initilization
            Color[] majorColorGroup = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
            Color[] minorColorGroup = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };    
            
            ColorPair objColorPairs = new ColorPair(majorColorGroup, minorColorGroup);
            int pairNumber=4;
            ColorPair color_pair_result = ColorCode.GetColorFromPairNumber(pairNumber, objColorPairs);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, color_pair_result);
            Debug.Assert(color_pair_result.majorColor == Color.White);
            Debug.Assert(color_pair_result.minorColor == Color.Brown);
            
            ColorPair colors_pair_data = new ColorPair() { majorColor = Color.Yellow, minorColor = Color.Green };
            pairNumber = ColorData.GetPairNumberFromColor(colors_pair_data, objColorPairs);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", colors_pair_data, pairNumber);
            Debug.Assert(pairNumber == 18);
        }
    }
}
