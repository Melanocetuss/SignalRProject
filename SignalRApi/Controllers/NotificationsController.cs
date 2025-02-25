using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public NotificationsController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetNotificationList() 
        {
            var values = _mapper.Map<List<ResultNotificationDto>>(_notificationService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("GetNotification")]
        public IActionResult GetNotification(int id) 
        {
            var value = _notificationService.TGetByID(id);
            return Ok(_mapper.Map<GetNotificationDto>(value));
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var NotificationEntity = _mapper.Map<Notification>(createNotificationDto);
            _notificationService.TAdd(NotificationEntity);
            return Ok("Bildirim Eklendi");
        }

        [HttpDelete]
        public IActionResult RemoveNotification(int id) 
        {
            var value = _notificationService.TGetByID(id);
            _notificationService.TDelete(value);
            return Ok("Bildirim Silindi");
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var NotificationEntity = _mapper.Map<Notification>(updateNotificationDto);
            _notificationService.TUpdate(NotificationEntity);
            return Ok("Bildirim Güncellendi");
        }

        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }

        [HttpGet("GetAllNotificationsByStatusFalse")]
        public IActionResult GetAllNotificationsByStatusFalse() 
        {
            return Ok(_notificationService.TGetAllNotificationsByStatusFalse());
        }

        [HttpPut("NotificationStatusChangeToTrue")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            try
            {
                _notificationService.TNotificationStatusChangeToTrue(id);
                return Ok("Okundu Olarak İşaretlendi");
            }

            catch (Exception ex)
            {
                return BadRequest($"Bir hata oluştu: {ex.Message}");
            }
        }

        [HttpPut("NotificationStatusChangeToFalse")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
            try
            {
                _notificationService.TNotificationStatusChangeToFalse(id);
                return Ok("Okunmadı Olarak İşaretlendi");
            }

            catch (Exception ex)
            {
                return BadRequest($"Bir hata oluştu: {ex.Message}");
            }
        }
    }
}