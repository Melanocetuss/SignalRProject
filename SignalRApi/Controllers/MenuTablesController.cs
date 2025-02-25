using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;
        private readonly IMapper _mapper;
        public MenuTablesController(IMenuTableService menuTableService, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMenuTableList()
        {
            var values = _mapper.Map<List<ResultMenuTableDto>>(_menuTableService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("GetMenuTable")]
        public IActionResult GetMenuTable(int id)
        {
            var value = _mapper.Map<GetMenuTableDto>(_menuTableService.TGetByID(id));
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            var menuTableEntity = _mapper.Map<MenuTable>(createMenuTableDto);
            _menuTableService.TAdd(menuTableEntity);
            return Ok("Masa Eklendi");
        }

        [HttpDelete]
        public IActionResult RemoveMenuTable(int id)
        {
            var value = _menuTableService.TGetByID(id);
            _menuTableService.TDelete(value);
            return Ok("Masa Silindi");
        }

        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            var menuTableEntity = _mapper.Map<MenuTable>(updateMenuTableDto);
            _menuTableService.TUpdate(menuTableEntity);
            return Ok("Masa Güncellendi");
        }

        [HttpGet("GetMenuTableByStatusFalseCount")]
        public IActionResult GetMenuTableByStatusFalseCount()
        {
            var value = _menuTableService.TGetMenuTableByStatusFalseCount();
            return Ok(value);
        }
    }
}