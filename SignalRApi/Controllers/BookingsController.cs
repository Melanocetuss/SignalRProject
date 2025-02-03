using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDtos;
using SignalR.EntityLayer.Entities;
using AutoMapper;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        public BookingsController(IBookingService BookingService, IMapper mapper)
        {
            _bookingService = BookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBookingList()
        {
            var values = _mapper.Map<List<ResultBookingDto>>(_bookingService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("GetBooking")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            _bookingService.TAdd(new Booking()
            {
                Name = createBookingDto.Name,
                Phone = createBookingDto.Phone,
                Email = createBookingDto.Email,
                PersonCount = createBookingDto.PersonCount,
                Date = createBookingDto.Date
            });
            return Ok("Rezervasyon Eklendi");
        }

        [HttpDelete]
        public IActionResult RemoveBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            _bookingService.TDelete(value);
            return Ok("Rezervasyon Silindi");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            _bookingService.TUpdate(new Booking()
            {
                BookingID = updateBookingDto.BookingID,
                Name = updateBookingDto.Name,
                Phone = updateBookingDto.Phone,
                Email = updateBookingDto.Email,
                PersonCount = updateBookingDto.PersonCount,
                Date = updateBookingDto.Date
            });
            return Ok("Rezervasyon Güncellendi");
        }
    }
}