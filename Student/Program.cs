using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();

var Course = new Student[] {
    new(1, "Abhay",DateOnly.FromDateTime(DateTime.Parse("2024-03-05")),DateOnly.FromDateTime(DateTime.Parse("2024-03-05")),true),
    new(2, "Abhinav",DateOnly.FromDateTime(DateTime.Parse("2024-03-05")),DateOnly.FromDateTime(DateTime.Parse("2024-03-05")),true),
    new(3, "Arpan",DateOnly.FromDateTime(DateTime.Parse("2024-03-05")),DateOnly.FromDateTime(DateTime.Parse("2024-03-05")),true),
    new(4, "Chaitanya",DateOnly.FromDateTime(DateTime.Parse("2024-03-05")),DateOnly.FromDateTime(DateTime.Parse("2024-03-05")),true),
    new(5, "Rishabh",DateOnly.FromDateTime(DateTime.Parse("2024-03-05")),DateOnly.FromDateTime(DateTime.Parse("2024-03-05")),true)
};

var allStudent = app.MapGroup("/student");
allStudent.MapGet("/", () => Course);

var singleStudent = app.MapGroup("/student");
singleStudent.MapGet("/{id}", (int id) =>
    Course.FirstOrDefault(a => a.prn == id) is { } Student
        ? Results.Ok(Student)
        : Results.NotFound());

app.Run();

public record Student(int prn, string? name, DateOnly? joinDate = null, DateOnly? lastDate = null, bool status = false);

[JsonSerializable(typeof(Student[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
