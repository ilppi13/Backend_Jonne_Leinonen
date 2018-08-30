using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test

{
    public class OfflineCityBikeDataFetcher : ICityBikeDataFetcher
    {

        public async Task<int> GetBikeCountInStation(string stationName) {
            string[] text = await System.IO.File.ReadAllLinesAsync(@"C:\Users\ilppi\Desktop\Backend\test\bikedata.txt");
            if (stationName.Any(char.IsDigit)) {
                Console.WriteLine("Station name has number!");
            }
            int availableBikes = 0;
            foreach(string name in text) {
                List<string> names = name.Split(": ").ToList<string>();
                if (names[0] == stationName){
                    return int.Parse(names[1]);
                }          
            }
            return availableBikes;
        }
    }
}