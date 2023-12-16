using AutoMapper;
using HospitalManegementSystem.ActionFilters;
using HospitalManegementSystem.Data.Models;
using HospitalManegementSystem.Services;
using Microsoft.AspNetCore.Mvc;
namespace HospitalManegementSystem.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController:ControllerBase
    {
        private readonly IRepository<Doctor> _repo;
        private readonly ILogger<DoctorController> _logger;
        private readonly IMapper _mapper;

        public DoctorController(IRepository<Doctor> repo, ILogger<DoctorController> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("api/GetAll")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetAll()
        {
            try
            {
                var records = await _repo.GetAllAsync();
                var recordsDTO = _mapper.Map<HashSet<DoctorDTO>>(records);
                return recordsDTO;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("api/GetById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<DoctorDTO>> GetById([FromBody] int id)
        {
            try
            {
                var record = await _repo.GetByIdAsync(id);

                var recordDTO = _mapper.Map<DoctorDTO>(record);
                return recordDTO;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        [Route("api/Create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Create([FromBody] DoctorDTO dto)
        {

            if (!ModelState.IsValid)
                return BadRequest("Invalid data inputs");

            if (dto is null)
                return BadRequest();

            var record = _mapper.Map<Doctor>(dto);
            await _repo.CreateAsync(record);

            return Ok(record.Id);
        }
        [HttpDelete]
        [Route("api/DeleteById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [LogSensitiveAction]

        public async Task<ActionResult> Delete(int id)
        {
            var record = _repo.GetAsync(x => x.Id == id);
            if (record is null)
                return NotFound();
            await _repo.DeleteAsync(record.Id);

            return Ok();
        }
        [HttpPut]
        [Route("api/GetById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Update(int id, DoctorDTO dto)
        {
            var record = await _repo.GetAsync(x => x.Id == id);
            if (record is null)
            {
                _logger.LogError($"No record found with id {id}");
                return NotFound($"record with id {id} not found");
            }
            var doctor = _mapper.Map<Doctor>(dto);
            await _repo.UpdateAsync(id, doctor);

            return Ok();
        }
    }
}
