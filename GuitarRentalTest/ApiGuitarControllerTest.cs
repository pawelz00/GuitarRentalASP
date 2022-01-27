using GuitarRental.Controllers;
using GuitarRental.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace GuitarRentalTest
{
    public class ApiGuitarControllerTest
    {
        [Fact]
        public void testGet()
        {
            //Given
            ICRUDGuitarRepository guitars = new TestMemoryGuitarRepository();
            RestGuitarController controller = new RestGuitarController(guitars);
            Guitar guitar = new Guitar()
            { Name = "test", GuitarStringsId = 1, GuitarTypeId = 1, ProductionYear = 2000 };
            //When
            ActionResult actionresult = controller.Get(1);
            ActionResult actionresult2 = controller.Get(10);
            //That
            Assert.IsType<OkObjectResult>(actionresult);
            Assert.IsType<NotFoundResult>(actionresult2);
        }
        [Fact]
        public void testDelete()
        {
            //Given
            ICRUDGuitarRepository guitars = new TestMemoryGuitarRepository();
            RestGuitarController controller = new RestGuitarController(guitars);
            Guitar guitar = new Guitar()
            { Name = "test", GuitarStringsId = 1, GuitarTypeId = 1, ProductionYear = 2000 };
            //When
            ActionResult actionresult = controller.Delete(1);
            ActionResult actionresult2 = controller.Delete(5);
            //That
            Assert.IsType<OkObjectResult>(actionresult);
            Assert.IsType<NotFoundObjectResult>(actionresult2);
        }
        [Fact]
        public void testAdd()
        {
            //Given
            ICRUDGuitarRepository guitars = new TestMemoryGuitarRepository();
            RestGuitarController controller = new RestGuitarController(guitars);
            Guitar guitar = new Guitar()
            { Name = "test", GuitarStringsId = 1, GuitarTypeId = 1, ProductionYear = 2000 };
            //WHEN
            ActionResult actionresult = controller.Add(guitar);
            //THAT
            Assert.IsType<CreatedResult>(actionresult);
        }
    }
}
