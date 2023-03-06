using Task3.WebService.Model;

namespace Task3.WebService.Services
{
    public interface IHotelRateService
    {
        public List<HotelRate> FilterHotelsRates(int hotelId, DateTime arrivalDate);
    }
}
