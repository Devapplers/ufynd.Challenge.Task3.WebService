using Microsoft.Extensions.Options;
using Task3.WebService.Configs;
using Task3.WebService.Model;
using Task3.WebService.Utilities;

namespace Task3.WebService.Repositories
{
    public class HotelsRatesRepository : IHotelsRatesRepository
    {
        private readonly IJsonHandler JsonHandler;
        private readonly string JsonFilePath;
        private List<HotelsRates> HotelsRates;
        
        public HotelsRatesRepository(IJsonHandler jsonHandler, IOptions<Files> files)
        {
            this.JsonHandler = jsonHandler;
            this.JsonFilePath = files.Value.HotelsRatesFilePath;
            this.HotelsRates = FindAll();
        }

        public List<HotelsRates> FindAll()
        {
            var jsonContent = JsonHandler.LoadJsonFile(JsonFilePath);
            return JsonHandler.ReadJson<List<HotelsRates>>(jsonContent);
        }

        public HotelsRates FindByHotelId(int hotelId)
        {
           return this.HotelsRates.FirstOrDefault(hr => hr.hotel.hotelID == hotelId);
        }
    }
}
