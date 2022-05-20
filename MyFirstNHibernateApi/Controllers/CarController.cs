using Microsoft.AspNetCore.Mvc;
using MyFirstNHibernateApi.Dto;
using MyFirstNHibernateApi.Services;

namespace MyFirstNHibernateApi.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarController : ControllerBase
    {
        private readonly CarService _carService;
        public CarController(CarService carService)
        {
            _carService = carService;
        }

        [HttpGet("manufacturers/{id}")]
        public IActionResult GetCarManufacturerById([FromRoute] int id)
        {
            var manufacturer = _carService.GetCarManufacturer(id);
            return Ok(manufacturer);
        }

        [HttpPost("manufacturer")]
        public IActionResult AddNewManufacturer([FromBody] AddNewCarManufacturerRequest request)
        {
            var manufacturerId = _carService.AddNewCarManufacturer(request);
            return Ok(manufacturerId);
        }

        [HttpPut("manufacturers/{id}")]
        public IActionResult UpdateManufaturer([FromRoute] int id, [FromBody] UpdateCarManufacturerRequest request)
        {
            _carService.UpdateCarManufacturer(id, request);
            return NoContent();
        }

        [HttpGet("models/{id}")]
        public IActionResult GetCarModel([FromRoute] int id)
        {
            var model = _carService.GetCarModel(id);
            return Ok(model);
        }

        [HttpPost("model")]
        public IActionResult AddNewModel([FromBody] AddNewCarModelRequest request)
        {
            var modelId = _carService.AddNewCarModel(request);
            return Ok(modelId);
        }



        [HttpPost]
        public IActionResult AddNewCar([FromBody] AddNewCarRequest request)
        {
            var carId = _carService.AddNewCar(request);
            return Ok(carId);
        }
    }
}
