using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluralsight.BegCollections.TopTenProps
{
    class Program
    {
        static void Main(String[] args)
        {
            //Get the file
            string filePath = "Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);

            //construct the country region dictionary
            Dictionary<string, List<Country>> regions = reader.ReadAllDicRegions();
            foreach (string region in regions.Keys)      
                System.Console.WriteLine(region);

            //Ask for user region input
            System.Console.WriteLine("Which of the above regions would you like to view?");
            string chosenRegion = Console.ReadLine();

            //validate region and display the corresponding countries
            if (regions.ContainsKey(chosenRegion))
            {
                foreach (Country country in regions[chosenRegion].Take(10))
                    System.Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
            else
            {
                System.Console.WriteLine("Not a valid region");
            }

            // List<Country> countries = reader.ReadAllCountries();
            // //reader.RemoveCommaCountries(countries);
            // var filteredCountries = countries.Where(x => !x.Name.Contains(',')).Take(20);
            // var filteredCountries2 =    from country in countries
            //                             where !country.Name.Contains(',')
            //                             select country;    
            // // int lilliputIndex = countries.FindIndex(x => x.Population < 2_000_000);
            // // Country lilliput = new Country("Lilliput", "LIL", "Somewhere", 2_000_000);
            // // countries.Insert(lilliputIndex, lilliput);
            // // countries.RemoveAt(lilliputIndex);
            
            // foreach (Country country in filteredCountries2)
            // {
            //     Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            // }

            // Console.WriteLine("Enter number of countries to display");
            // bool inputIsInt = int.TryParse(Console.ReadLine(), out int userInput);

            // if (!inputIsInt || userInput <= 0 || userInput > countries.Count)
            // {
            //     Console.WriteLine($"You must enter a number between 1 and {countries.Count}");
            //     return;
            // }

            // for (int currCountry = 0; currCountry < userInput; currCountry++)
            // {
            //     Country country = countries[currCountry];
            //     Console.WriteLine($"{currCountry + 1}: {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            // }
            //foreach (Country country in countries)
                //Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            //Console.WriteLine($"{countries.Count} countries");
            // Dictionary<string, Country> countries = reader.ReadAllDicCountries();

            // Console.WriteLine("Which country code do you want to look up?");
            // string userInput = Console.ReadLine();

            // bool gotCountry = countries.TryGetValue(userInput, out Country country);
            // if (!gotCountry)
            //     Console.WriteLine("Country not found.");
            // else
            //     Console.WriteLine($"{country.Name} has population {PopulationFormatter.FormatPopulation(country.Population)}");
            
            // Country norway = new Country("Norway", "NOR", "Europe", 5_282_223);
            // Country finland = new Country("Finland", "FIN", "Europe", 5_511_303);
            // Country musmus = new Country("Musmus", "MUS", "Europe", 6_000_000);

            // var countries = new Dictionary<string, Country>();

            // countries.Add(norway.Code, norway);
            // countries.Add(finland.Code, finland);

            // bool exists = countries.TryGetValue("MUS", out Country country);
            // if (exists)
            //     Console.WriteLine(country.Name);
            // else
            //     Console.WriteLine($"Country code not found.");

            // foreach (var country in countries.Values)
            //     Console.WriteLine(country.Name);            
            
            // Country selectedCountry = countries["NOR"];
            // Console.WriteLine(selectedCountry.Name);
            // string filepath = "Pop by Largest Final.csv";
            // CsvReader reader = new CsvReader(filepath);

            // List<Country> countries = reader.ReadAllCountries();
            // // int lilliputIndex = countries.FindIndex(x => x.Population < 2_000_000);
            // // Country lilliput = new Country("Lilliput", "LIL", "Somewhere", 2_000_000);
            // // countries.Insert(lilliputIndex, lilliput);
            // // countries.RemoveAt(lilliputIndex);

            // foreach (Country country in countries)
            // {
            //     Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            // }
            // Console.WriteLine($"{countries.Count} countries");
            
            // List<string> daysOfWeek = new List<string>()
            // {
            //     "Monday",
            //     "Tuesday",
            //     "Wednesday",
            //     "Thursday",
            //     "Friday",
            //     "Saturday"
            // };
            // daysOfWeek.Add("Sunday");
            
            // string filepath = "Pop by Largest Final.csv";
            // CsvReader reader = new CsvReader(filepath);

            // Country[] countries = reader.ReadFirstNCountries(10);

            // foreach (Country country in countries)
            // {
            //     Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            // }
            
            // string [] daysOfWeek = 
            // {
            //     "Monday",
            //     "Tuesday",
            //     "Wednesday",
            //     "Thursday",
            //     "Friday",
            //     "Saturday",
            //     "Sunday"
            // };

            // Console.WriteLine("Which day would you like to display? \nMonday = 1, Tuesday = 2, etc.");
            // Console.WriteLine($"You've chosen {daysOfWeek[int.Parse(Console.ReadLine()) - 1]}");
            
            // string ChosenDay = daysOfWeek[(int.Parse(Console.ReadLine()) - 1)];
            // foreach (string day in daysOfWeek)
            // {
            //     Console.WriteLine(day);
            // }
        }
    }
}