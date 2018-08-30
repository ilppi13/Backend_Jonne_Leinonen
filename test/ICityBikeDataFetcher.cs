using System.Threading.Tasks;

namespace test
{
    public interface ICityBikeDataFetcher
    {
         Task<int> GetBikeCountInStation(string stationName);
    }
}