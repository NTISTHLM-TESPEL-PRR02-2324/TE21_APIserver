using TE21_APIserver;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

TeacherData data = new();

app.MapGet("/", GetSomething);
app.MapGet("/hello", () => "Goodbye!");
app.MapGet("/teachers/{number}", data.GetTeacher);

app.MapPost("/teachers", data.PostTeacher);

app.Urls.Add("http://*:5281");

app.Run();

static string GetSomething()
{
  return "Hello TE21A";
}

class TeacherData
{
  List<Teacher> teachers = new() {
    new Teacher() {Name = "Micke", HitPoints = 100},
    new Teacher() {Name = "Martin", HitPoints = 3},
    new Teacher() {Name = "Lena", HitPoints = 9000}
  };

  public IResult PostTeacher()
  {
    Console.WriteLine("Yay");
    return Results.Ok();
  }

  public IResult GetTeacher(int number)
  {
    if (number < 0 || number >= teachers.Count)
    {
      return Results.NotFound();
    }
    return Results.Ok(teachers[number]);
  }
}