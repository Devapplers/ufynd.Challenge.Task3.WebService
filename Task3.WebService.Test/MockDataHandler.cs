using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.WebService.Model;
using Tynamix.ObjectFiller;

namespace Task3.WebService.Test
{
    public class MockDataHandler
    {
        public static List<HotelsRates> MoqHotelRates;

        public static List<HotelsRates> GenerateMockHotelsRates()
        {
            if (MoqHotelRates == null)
                MoqHotelRates = new Filler<HotelsRates>().Create(2).ToList();
            return MoqHotelRates;
        }
        public static List<HotelRate> MockFilterHotelRates(int hotelId, DateTime arrivalDate)
        {
            if (hotelId == 0)
                throw new ArgumentException();
            var moqHotelRates = new Filler<HotelRate>().Create(9).ToList();
            moqHotelRates.ForEach(hr => hr.targetDay = arrivalDate);
            return moqHotelRates;
        }
    }
}
