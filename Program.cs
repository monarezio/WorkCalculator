using WorkCalculator;

string[] users = File.ReadAllLines("users.csv");
foreach (var user in users)
{
    var item = user.Split(";");
    var mockedData = new List<Work>();
    mockedData.Add(new Work()
    {
        Id = Guid.NewGuid(),
        To = DateTime.Now,
        From = DateTime.Now.AddHours(-8),
        Note = "Work on login",
        Wage = 150
    });
    mockedData.Add(new Work()
    {
        Id = Guid.NewGuid(),
        To = DateTime.Now.AddDays(-1),
        From = DateTime.Now.AddDays(-1).AddHours(-4),
        Note = "Bug fixes 😭",
        Wage = 150
    });
    UserRepository.Users[item[1]] = new User
    {
        Settings = new UserSettings
        {
            Id = item[1],
            FullName = "Jan Novák",
            Wage = 150
        },
        Works = mockedData
    };
}


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

var app = builder.Build();
app.UseCors("MyPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();