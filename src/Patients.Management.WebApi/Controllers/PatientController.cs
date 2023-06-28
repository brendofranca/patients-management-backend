using Microsoft.AspNetCore.Mvc;
using Patients.Management.Application.Requests;
using Patients.Management.Application.Services;

namespace Patients.Management.WebApi.Controllers
{
    [ApiController]
    [Route(RouteTemplate)]
    [Produces("application/json")]
    public class PatientController : ControllerBase
    {
        private const string RouteTemplate = "api/v1/patients";
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService) =>
            _patientService = patientService;

        [HttpGet]
        public async Task<IActionResult> GetAllPatients(CancellationToken cancellationToken) =>
            Ok(await _patientService.GetAllPatientsAsync(cancellationToken));

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPatient(Guid id, CancellationToken cancellationToken)
        {
            var patient = await _patientService.GetPatientByIdAsync(id, cancellationToken);

            return patient != null ? Ok(patient) : NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient(PatientRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _patientService.RegisterPatientAsync(request, cancellationToken);

            return result ? Ok(request) : BadRequest();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<PatientRequest>> UpdatePatient(Guid id, PatientRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.Id)
            {
                return BadRequest("Id parameter is not equal Id from request body.");
            }

            var result = await _patientService.RegisterPatientAsync(request, cancellationToken);

            return result ? Ok(request) : BadRequest();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletePatient(Guid id, CancellationToken cancellationToken)
        {
            var result = await _patientService.DeletePatientAsync(id, cancellationToken);

            return result ? Ok(id) : BadRequest();
        }
    }
}