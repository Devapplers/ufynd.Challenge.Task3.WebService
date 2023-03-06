using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.WebService.Model;
using Task3.WebService.Repositories;
using Task3.WebService.Services;

namespace Task3.WebService.Test.Services
{
    [TestFixture]
    public class HotelRatesServiceTest
    {
        Mock<IHotelRateRepository> moqHotelRateRepository;

        [OneTimeSetUp]
        public void HotelRateMoqRepositorySetup()
        {
            moqHotelRateRepository = new Mock<IHotelRateRepository>();
            moqHotelRateRepository.Setup(m => m.FindAllByHotelIdAndTargetDay(It.IsAny<int>(), It.IsAny<DateTime>()))
                .Returns((int hotelId, DateTime targetDay) => MockDataHandler.MockFilterHotelRates(hotelId, targetDay));
        }


        [Test]
        [TestCase(25, "2016-10-25")]
        public async Task FilterHotelsRatesReturnsValueTest(int hotelId, DateTime arrivalDate)
        {
            //Arrange
            var service = new HotelRatesService(moqHotelRateRepository.Object);

            //Act
            var result = service.FilterHotelsRates(hotelId, arrivalDate);

            //Assert
            Assert.IsInstanceOf(typeof(List<HotelRate>), result);
            Assert.IsNotNull(result);

        }

        [Test]
        [TestCase(0, "2016-10-25")]
        public async Task FilterHotelsRatesThrowsIdException(int hotelId, DateTime arrivalDate)
        {
            //Arrange
            var service = new HotelRatesService(moqHotelRateRepository.Object);

            //Act
            //Assert
            var ex = Assert.Throws<ArgumentException>(() => service.FilterHotelsRates(hotelId, arrivalDate));
            Assert.That(ex.Message, Is.EqualTo("hotelId should be a nonezero integer"));
        }


        [Test]
        [TestCase(2022, "0001-01-01")]
        public async Task FilterHotelsRatesThrowsArrivalDateException(int hotelId, DateTime arrivalDate)
        {
            //Arrange
            var service = new HotelRatesService(moqHotelRateRepository.Object);

            //Act
            //Assert
            var ex = Assert.Throws<ArgumentException>(() => service.FilterHotelsRates(hotelId, arrivalDate));
            Assert.That(ex.Message, Is.EqualTo("arrivalDate should be a valid datetime"));
        }
    }
}
