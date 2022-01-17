static class DrugHandler
{
	private static int _idTracker = 1;
	private static List<Drug> _drugs = new List<Drug>();

	public static IResult GetDrugs()
	{
		return Results.Ok(_drugs);
	}

	public static IResult GetDrug(int id)
	{
		var drug = _drugs.FirstOrDefault(d => d.Id == id);
		if (drug is null)
		{
			return Results.NotFound();
		}

		return Results.Ok(drug);
	}

	public static IResult AddDrug(Drug drug)
	{
		drug = drug with { Id = _idTracker };
		_drugs.Add(drug);

		_idTracker += 1;
		return Results.Created("", drug);
	}

	public static IResult UpdateDrug(int id, Drug drug)
	{
		var drugIndex = _drugs.FindIndex(d => d.Id == id);
		if (drugIndex == -1)
		{
			return Results.BadRequest("Drug cannot be recognized.");
		}

		_drugs[drugIndex] = drug with { Id = id };

		return Results.NoContent();
	}

	public static IResult DeleteDrug(int id)
	{
		var drugIndex = _drugs.FindIndex(d => d.Id == id);
		if (drugIndex == -1)
		{
			return Results.BadRequest("Drug could not be recognized.");
		}

		_drugs.RemoveAt(drugIndex);

		return Results.NoContent();
	}
}
