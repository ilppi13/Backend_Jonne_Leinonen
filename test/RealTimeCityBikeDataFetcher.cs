using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
    
namespace test
{

    public class NotFoundException:Exception {
        public NotFoundException(string message) : base (message) {

        }
    }
    public class Stations
    {
        public List<Station> stations;
    }

    public class Station
    {

        public string name {get;set;}
        public int bikesAvailable {get;set;}
    }
    public class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
    {
        public async Task<int> GetBikeCountInStation(string stationName) 
        {
            if (stationName.Any(char.IsDigit)) {
                throw new ArgumentException ("Station name has number!");
            }
            HttpClient client = new HttpClient() ;
            var response = await client.GetAsync(new Uri("http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental"));
            Stations json = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync(), typeof(Stations)) as Stations;
            int availableBikes = 0;
            
            foreach(var item in json.stations) {
                if (item.name == stationName) {
                    availableBikes = item.bikesAvailable;
                    return availableBikes;
                }
            }
            throw new NotFoundException("Not found: " + stationName);
            
            
        }
    }

  
}