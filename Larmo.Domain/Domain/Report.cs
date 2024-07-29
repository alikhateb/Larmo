namespace Larmo.Domain.Domain;

public class Report
{
    public string FullName { get; set; }
    public string MotherName { get; set; }
    public Gender Gender { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public string Profession { get; set; }
    public string Employer { get; set; }
    //public bool IsMared { get; set; }
    //public bool IsMared { get; set; }
}

public enum Gender
{
    Male = 1,
    Female
}

public enum MaritalStatus
{
    Single = 1,
    Married
}