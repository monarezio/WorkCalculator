using System.ComponentModel.DataAnnotations;

namespace WorkCalculator;

public class UserSettingsModel
{
    [MinLength(2)] public string FullName { get; set; }
    [Range(80, Int32.MaxValue)] public int Wage { get; set; }
}

public class WorkModel
{
    [Required] public string Note { get; set; }
    [Required] public DateTime From { get; set; }
    [Required] public DateTime To { get; set; }
}