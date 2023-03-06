using Task3.WebService.Model;

namespace Task3.WebService.Repositories
{
    public interface IHotelsRatesRepository
    {
        public List<HotelsRates> FindAll();
        public HotelsRates FindByHotelId(int hotelId);
    }
}
