using Microsoft.Extensions.Options;
using Task3.WebService.Configs;
using Task3.WebService.Model;
using Task3.WebService.Utilities;

namespace Task3.WebService.Repositories
{
    public class HotelRateRepository:IHotelRateRepository
    {

        private readonly IJsonHandler JsonHandler;
        private readonly string JsonFilePath;

        public HotelRateRepository(IJsonHandler jsonHandler, IOptions<Files> files)
        {
            this.JsonHandler = jsonHandler;
            this.JsonFilePath = files.Value.HotelsRatesFilePath;
        }

        public List<HotelRate> FindAllByHotelIdAndTargetDay(int hotelId, DateTime targetDay)
        {
            var jsonContent = JsonHandler.LoadJsonFile(JsonFilePath);
            var hotelsRates = JsonHandler.ReadJson<List<HotelsRates>>(jsonContent);
            var hotel = hotelsRates.FirstOrDefault(hr => hr.hotel.hotelID == hotelId);
            if(hotel == null)   
                return null;
            var hotelRateList = hotel.hotelRates.Where(rates => rates.targetDay.Date.Equals(targetDay.Date)).ToList();
            return hotelRateList;   
        }
    }
}
