using AutoMapper;
using HospitalManegementSystem.ActionFilters;
using HospitalManegementSystem.Data.Models;
using HospitalManegementSystem.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManegementSystem.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AppointmentController:ControllerBase
    {
        private readonly IRepository<Appointment> _repo;
        private readonly ILogger<AppointmentController> _logger;
        private readonly IMapper _mapper;

        public AppointmentController(IRepository<Appointment> repo, ILogger<AppointmentController> logger, IMapper mapper)
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
        public async Task<ActionResult<IEnumerable<AppointmentDTO>>> GetAll()
        {
            try
            {
                var records = await _repo.GetAllAsync();
                var recordsDTO = _mapper.Map<HashSet<AppointmentDTO>>(records);
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
        public async Task<ActionResult<AppointmentDTO>> GetById([FromBody] int id)
        {
            try
            {
                var record = await _repo.GetByIdAsync(id);

                var recordDTO = _mapper.Map<AppointmentDTO>(record);
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
        public async Task<ActionResult> Create([FromBody] AppointmentDTO dto)
        {
            
            if (!ModelState.IsValid)
                return BadRequest("Invalid data inputs");

            if (dto is null)
                return BadRequest();

            var record = _mapper.Map<Appointment>(dto);
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
        public async Task<ActionResult> Update(int id, AppointmentDTO dto)
        {
            var record = await _repo.GetAsync(x => x.Id == id);
            if (record is null)
            {
                _logger.LogError($"No record found with id {id}");
                return NotFound($"record with id {id} not found");
            }
            var appointment = _mapper.Map<Appointment>(dto);
            await _repo.UpdateAsync(id, appointment);

            return Ok();
        }
       
    }
}
