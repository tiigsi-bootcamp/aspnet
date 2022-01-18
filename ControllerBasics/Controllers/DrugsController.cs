using Microsoft.AspNetCore.Mvc;

[Route("/drugs")]
public class DrugsController
{
	// /drugs/list
	[HttpGet("list")] // Attribute.
	public string GetDrugs()
	{
		return "You will get drugs!";
	}

	// GET /drugs/5
	[HttpGet("{id:int}")]
	public string GetDrug(int id)
	{
		return "Single drug with id of type int " + id;
	}

	[HttpGet("{id}")]
	public string GetDrug(string id) // Method overloading.
	{
		return "Single drug with id " + id;
	}

	[HttpPost]
	public string AddDrug()
	{
		return "Drug will be added!";
	}
}