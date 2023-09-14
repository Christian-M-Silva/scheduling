using Domain.Entites;
using Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SchedulingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        public async Task<ActionResult> Post(PatientsEntity patienty) { 
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _patientService.Post(patienty);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("default", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException error)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, error.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _patientService.Delete(id);
                    if (result)
                    {
                        return Ok();
                    }
                    return NotFound();
                }
                catch (ArgumentException erro)
                {

                    return StatusCode((int)HttpStatusCode.InternalServerError, erro.Message);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _patientService.Get(id);
                    return Ok(result);
                }
                catch (ArgumentException erro)
                {

                    return StatusCode((int)HttpStatusCode.InternalServerError, erro.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpGet("/getWithDate")]
        public async Task<ActionResult> GetAllWithDate(DateTime ConsultationDate)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _patientService.GetAllWithDate(ConsultationDate);
                    return Ok(result);
                }
                catch (ArgumentException erro)
                {

                    return StatusCode((int)HttpStatusCode.InternalServerError, erro.Message);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpGet("/hasVacanancy")]
        public async Task<ActionResult> HasVacanancy(DateTime ConsultationDate)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _patientService.HasVacanancy(ConsultationDate);
                    if (result)
                    {
                        return Ok("Ainda ha vagas para esse dia");
                    }
                    return NotFound("Não há vagas para esse dia");
                }
                catch (ArgumentException erro)
                {

                    return StatusCode((int)HttpStatusCode.InternalServerError, erro.Message);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] PatientsEntity patient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _patientService.Update(patient, id);
                    return Ok(result);
                }
                catch (ArgumentException erro)
                {

                    return StatusCode((int)HttpStatusCode.InternalServerError, erro.Message);
                }
            }
            return BadRequest(ModelState);
        }
    }
}
