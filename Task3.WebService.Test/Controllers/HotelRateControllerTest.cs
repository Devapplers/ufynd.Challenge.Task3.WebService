using Microsoft.AspNetCore.Mvc;
using Moq;
using Task3.WebService.Controllers;
using Task3.WebService.Model;
using Task3.WebService.Services;

namespace Task3.WebService.Test.Controllers
{
    [TestFixture]
    public class HotelRateControllerTest
    {
        Mock<IHotelRateService> moqHotelRateService;


        [OneTimeSetUp]
        public void HotelRateServiceMoqSetup()
        {
            moqHotelRateService = new Mock<IHotelRateService>();
            moqHotelRateService.Setup(m => m.FilterHotelsRates(It.IsAny<int>(), It.IsAny<DateTime>()))
                .Returns((int hotelId, DateTime arrivalDate) => MockDataHandler.MockFilterHotelRates(hotelId, arrivalDate));

        }


        [Test]
        [TestCase(25, "2016-10-25")]
        public async Task FilterReturnsOKTest(int hotelId, DateTime arrivalDate)
        {
            //Arrange
            var controller = new HotelRateController(moqHotelRateService.Object);
            //Act
            var result = await controller.Filter(hotelId, arrivalDate);
            //Assert
            Assert.IsInstanceOf(typeof(OkObjectResult), result);
            Assert.IsNotNull((result as OkObjectResult).Value as List<HotelRate>);

        }

        [Test]
        [TestCase(0, "2016-10-25")]
        public async Task FilterReturnsBadRequestTest(int hotelId, DateTime arrivalDate)
        {
            //Arrange
            var controller = new HotelRateController(moqHotelRateService.Object);
            //Act
            var result = await controller.Filter(hotelId, arrivalDate);
            //Assert
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), result);

        }
    }
}
