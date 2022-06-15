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
        /// DisplayColorInfo method shows the pair color using the Pair Number 
        /// </summary>
        private static void DisplayColorInfo(int pair_number, ColorPair objcolorinfo)
        {
            ColorPair color_pair_result = ColorCode.GetColorFromPairNumber(pair_number, objcolorinfo);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pair_number, color_pair_result);

            if (pair_number == 4)
            {
                Debug.Assert(color_pair_result.majorColor == Color.White);
                Debug.Assert(color_pair_result.minorColor == Color.Brown);
            }
            else if (pair_number == 5)
            {
                Debug.Assert(color_pair_result.majorColor == Color.White);
                Debug.Assert(color_pair_result.minorColor == Color.SlateGray);
            }
            else if (pair_number == 23)
            {
                Debug.Assert(color_pair_result.majorColor == Color.Violet);
                Debug.Assert(color_pair_result.minorColor == Color.Green);
            }
        }
        /// <summary>
        /// DisplayPairnumber method shows the Pair Number for the corresponding color
        /// </summary>
        private static void DisplayPairNumber(ColorPair color_pair_data, ColorPair objcolorinfo)
        {
            int pair_Number = ColorCode.GetPairNumberFromColor(color_pair_data, objcolorinfo);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", color_pair_data, pair_Number);

            if (color_pair_data.majorColor == Color.Yellow && color_pair_data.minorColor == Color.Green)
            {
                Debug.Assert(pair_Number == 18);
            }
            else if (color_pair_data.majorColor == Color.Red && color_pair_data.minorColor == Color.Blue)
            {
                Debug.Assert(pair_Number == 6);
            }
        }
        
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
            int[] pair_numbers = new int[3] { 4, 5, 23 };

            //Fetch the Color Pair Infor from the Pair Number
            foreach (int pair in pair_numbers)
            {
                DisplayColorInfo(pair, objColorPairs);
            }
            
            ColorPair[] colors_pair_data = new ColorPair[2];
            colors_pair_data[0] = new ColorPair() { majorColor = Color.Yellow, minorColor = Color.Green };
            colors_pair_data[1] = new ColorPair() { majorColor = Color.Red, minorColor = Color.Blue };
            
            //Fetch the Pair Number information from Color pairs
            foreach (ColorPair color_pair_info in colors_pair_data)
            {
                DisplayPairNumber(color_pair_info, objColorPairs);
            }
        }
    }
}
