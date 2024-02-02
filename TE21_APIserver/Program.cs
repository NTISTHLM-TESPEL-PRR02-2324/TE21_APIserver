using TE21_APIserver;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

app.MapGet("/", GetSomething);
app.MapGet("/hello", () => "Goodbye!");
app.MapGet("/teachers/{number}", GetTeacher);

app.Run();

static string GetSomething()
{
  return "Hello TE21A";
}

static Teacher GetTeacher(int number)
{
  List<Teacher> teachers = new() {
    new Teacher() {Name = "Micke", HitPoints = 100},
    new Teacher() {Name = "Martin", HitPoints = 3}
  };

  return teachers[number];
}