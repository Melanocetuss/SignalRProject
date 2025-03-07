﻿using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDtos;
using SignalR.EntityLayer.Entities;
using AutoMapper;
using FluentValidation;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBookingDto> _validator;
        public BookingsController(IBookingService BookingService, IMapper mapper, IValidator<CreateBookingDto> validator)
        {
            _bookingService = BookingService;
            _mapper = mapper;
            _validator = validator;
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
            return Ok(_mapper.Map<GetBookingDto>(value));
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var validationResult = _validator.Validate(createBookingDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            else 
            {
                var bookingEntity = _mapper.Map<Booking>(createBookingDto);
                _bookingService.TAdd(bookingEntity);
                return Ok("Rezervasyon Eklendi");
            }
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
            var bookingEntity = _mapper.Map<Booking>(updateBookingDto);
            _bookingService.TUpdate(bookingEntity);
            return Ok("Rezervasyon Güncellendi");
        }

        [HttpPut("BookingStatusApproved")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.TBookingStatusApproved(id);
            return Ok("Rezervasyon Onaylandı");
        }

        [HttpPut("BookingStatusCancelled")]
        public IActionResult BookingStatusCancelled(int id)
        {
            _bookingService.TBookingStatusCancelled(id);
            return Ok("Rezervasyon İptal Edildi");
        }
    }
}