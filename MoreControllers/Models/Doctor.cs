using System.ComponentModel.DataAnnotations;

public class Doctor
{
	public int Id { get; set; }

	public string Name { get; set; } = "";

	public Gender Gender { get; set; }

	[Required(ErrorMessage = "Email should be valid")]
	[EmailAddress]
	public string Email { get; set; } = "";
}

public enum Gender
{
	None,
	Male,
	Female,
	Other,
	PreferNotToProvide
}