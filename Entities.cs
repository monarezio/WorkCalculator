namespace WorkCalculator;

public class UserSettings
{
    public string Id { get; set; }
    public string FullName { get; set; }
    public int Wage { get; set; }
}

public class Work
{
    public Guid Id { get; set; }
    public string Note { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public int Wage { get; set; }
}

public class User
{
    public UserSettings Settings { get; set; }
    public List<Work> Works { get; set; }
}

public class UserRepository
{
    public static Dictionary<string, User> Users { get; } = new Dictionary<string, User>();
}