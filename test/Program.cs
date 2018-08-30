using System;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            try{
            ICityBikeDataFetcher fetcher;
            if((args[0]) == "realtime"){
                fetcher = new RealTimeCityBikeDataFetcher();
            } else if ((args[0]) == "offline"){
                fetcher = new OfflineCityBikeDataFetcher();
            } else {
                Console.WriteLine("Type realtime or offline");
                return;
            }
            
            Task<int> task = fetcher.GetBikeCountInStation(args[1]);
            task.Wait();
            Console.WriteLine(task.Result); }
            catch (AggregateException ae) {
                foreach (Exception exception in ae.InnerExceptions) {
                    if (exception is NotFoundException) {
                        Console.WriteLine(exception);
                    } else if (exception is ArgumentException) {
                        Console.WriteLine(exception);
                    } else {
                        Console.WriteLine(exception);
                    }
                }
            }
        }
    }
}
