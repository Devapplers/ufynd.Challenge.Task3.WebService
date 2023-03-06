using Task3.WebService.Model;
using Task3.WebService.Repositories;

namespace Task3.WebService.Services
{
    public class HotelRatesService : IHotelRateService
    {
        private readonly IHotelRateRepository HotelRatesRepository;

        public HotelRatesService(IHotelRateRepository hotelsRatesRepository)
        {
            this.HotelRatesRepository = hotelsRatesRepository;
        }

        public List<HotelRate> FilterHotelsRates(int hotelId, DateTime arrivalDate)
        {
            if (hotelId == 0)
                throw new ArgumentException("hotelId should be a nonezero integer");
            if (arrivalDate == DateTime.MinValue)
                throw new ArgumentException("arrivalDate should be a valid datetime");

            var result = HotelRatesRepository.FindAllByHotelIdAndTargetDay(hotelId, arrivalDate);
            return result;
        }
    }
}
