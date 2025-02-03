using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaeturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;
        public FeaeturesController(IFeatureService FeatureService, IMapper mapper)
        {
            _featureService = FeatureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetFeatureList()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var value = _featureService.TGetByID(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {

            _featureService.TAdd(new Feature()
            {
                FirstTitle = createFeatureDto.FirstTitle,
                FirstDescription = createFeatureDto.FirstDescription,
                SecondTitle = createFeatureDto.SecondTitle,
                SecondDescription = createFeatureDto.SecondDescription,
                ThirtTitle = createFeatureDto.ThirtTitle,
                ThirtDescription = createFeatureDto.ThirtDescription
            });
            return Ok("Öne Çıkan Eklendi");
        }

        [HttpDelete]
        public IActionResult RemoveFeature(int id)
        {
            var value = _featureService.TGetByID(id);
            _featureService.TDelete(value);
            return Ok("Öne Çıkan Silindi");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            _featureService.TUpdate(new Feature()
            {
                FeatureID = updateFeatureDto.FeatureID,
                FirstTitle = updateFeatureDto.FirstTitle,
                FirstDescription = updateFeatureDto.FirstDescription,
                SecondTitle = updateFeatureDto.SecondTitle,
                SecondDescription = updateFeatureDto.SecondDescription,
                ThirtTitle = updateFeatureDto.ThirtTitle,
                ThirtDescription = updateFeatureDto.ThirtDescription          
            });
            return Ok("Öne Çıkan Güncellendi");
        }
    }
}
