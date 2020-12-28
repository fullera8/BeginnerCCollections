using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluralsight.BegCollections.TopTenProps
{
    class PopulationFormatter
    {
        public static string FormatPopulation(int population)
        {
            if (population == 0)
                return "(unknown)";

            int popRounded = RoundPopulation4(population);

            return $"{popRounded:### ### ### ###}".Trim();
        }

        //rounds the population to the first 4 figures
        private static int RoundPopulation4(int population)
        {
            int accuracy = Math.Max((int)(GetHighestPowerOfTen(population) / 10_0001),1);
            return RoundToNearest(population,accuracy);
        }

        //no population rounding
        public static string FormatPopulationNoRound(int population)
        {
            if (population == 0)
                return "(Unknown)";

            return $"{population:### ### ### ###}".Trim();
        }

        //rounds to the input accuracy
        public static int RoundToNearest(int exact, int accuracy)
        {
            int adjusted = exact + accuracy / 2;
            return adjusted - adjusted % accuracy;
        }

        //gets the highest power of 10
        public static long GetHighestPowerOfTen(int x)
        {
            long result = 1;
            while (x > 0)
            {
                x /= 10;
                result *= 10;
            }
            return result;
        }
    }
}