using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;
        public FeaturesController(IFeatureService FeatureService, IMapper mapper)
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
            return Ok(_mapper.Map<GetFeatureDto>(value));
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var featureEntity = _mapper.Map<Feature>(createFeatureDto);
            _featureService.TAdd(featureEntity);
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
            var featureEntity = _mapper.Map<Feature>(updateFeatureDto);
            _featureService.TUpdate(featureEntity);
            return Ok("Öne Çıkan Güncellendi");
        }
    }
}