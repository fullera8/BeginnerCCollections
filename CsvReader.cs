using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluralsight.BegCollections.TopTenProps
{
    class CsvReader
    {
        private string _csvFilePath;
        private string csvLine = "";

        public CsvReader(string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
        }
        
        public Dictionary<string, List<Country>> ReadAllDicRegions()
        {
            var regions = new Dictionary<string, List<Country>>();

            /*
                The values inside the textfile object need to be disposed instead of the text file object itself.
                The using call will dispose of the elements in the list once they are done being used instead of the object.
            */
            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                //read header
                sr.ReadLine();

                while ((csvLine = sr.ReadLine()) != null)
                {
                    Country country = ReadCountryFromCsvLine(csvLine);
                    if (regions.ContainsKey(country.Region))
                    {
                        regions[country.Region].Add(country);
                    }
                    else
                    {
                        List<Country> countries = new List<Country>() {country};
                        regions.Add(country.Region, countries);
                    }
                }

            }

            return regions;
        }
        
        public Dictionary<string, Country> ReadAllDicCountries()
        {
            var countries = new Dictionary<string, Country>();

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                //skip the header
                sr.ReadLine();

                while ((csvLine =  sr.ReadLine()) != null)
                {
                    Country country = ReadCountryFromCsvLine(csvLine);
                    countries.Add(country.Code, country);
                }
            }

            return countries;
        }
        
        //removes the countries with commas in their names
        public void RemoveCommaCountries(List<Country> countries)
        {
            countries.RemoveAll(x => x.Name.Contains(','));
            
            // for (int countryCount = countries.Count - 1; countryCount >= 0; countryCount--)
            // {
            //     if (countries[countryCount].Name.Contains(','))
            //         countries.RemoveAt(countryCount);
            // }
        }

        //Reads every country in the file into the list
        public List<Country> ReadAllCountries()
        {
            List<Country> countries = new List<Country>();

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                //ignore the header
                sr.ReadLine();

                while ((csvLine = sr.ReadLine()) != null)
                {
                    countries.Add(ReadCountryFromCsvLine(csvLine));
                }
            }
            return countries;
        }
        
        //reads top n countries supplied by input
        public Country[] ReadFirstNCountries(int nCountries)
        {
            Country[] countries = new Country[nCountries];

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                //ignore header
                sr.ReadLine();

                for (int country = 0; country < nCountries; country++)
                {
                    csvLine = sr.ReadLine();
                    countries[country] = ReadCountryFromCsvLine(csvLine);
                }
            }

            return countries;
        }

       

        public Country ReadCountryFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(',');
            string name;
            string code;
            string region;
            string population;
            
            switch (parts.Length)
            {
                case 4:
                    name = parts[0];
                    code = parts[1];
                    region = parts[2];
                    population = parts[3];
                    break;
                case 5:
                    name = parts[0] + ", " + parts[1];
                    name = name.Replace("\"", null).Trim();
                    code = parts[2];
                    region = parts[3];
                    population = parts[4];
                    break;
                default:
                    throw new Exception($"Can't parse country from csvLine: {csvLine}");
            }

            //returns population as 0 if it cant parse
            int.TryParse(population, out int outPopulation);
            return new Country(name, code, region, outPopulation);
        }
    }
}