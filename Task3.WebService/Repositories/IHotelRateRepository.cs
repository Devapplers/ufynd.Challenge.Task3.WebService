using Task3.WebService.Model;

namespace Task3.WebService.Repositories
{
    public interface IHotelRateRepository
    {
        public List<HotelRate> FindAllByHotelIdAndTargetDay(int hotelId, DateTime targetDay);
    }
}
