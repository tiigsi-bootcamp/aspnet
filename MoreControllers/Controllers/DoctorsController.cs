using Microsoft.AspNetCore.Mvc;

[Route("/doctors")]
[ApiController]
public class DoctorsController : ControllerBase
{
	private static readonly List<Doctor> _doctors = new();
	private static int _idTracker = 1;

	// GET /doctors
	[HttpGet]
	public IActionResult GetDoctors()
	{
		return Ok(_doctors);
	}

	// GET /doctors/5
	[HttpGet("{id}")]
	public IActionResult GetDoctor(int id)
	{
		var doctor = _doctors.FirstOrDefault(d => d.Id == id);
		if (doctor is null)
		{
			return NotFound();
		}

		return Ok(doctor);
	}

	// POST /doctors
	[HttpPost]
	public IActionResult AddDoctor([FromBody]Doctor doctor)
	{
		doctor.Id = _idTracker++;
		_doctors.Add(doctor);

		return Created("", doctor);
	}
}
