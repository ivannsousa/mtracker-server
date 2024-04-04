using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddSingleton(_ => new MongoClient());
builder.Services.AddSingleton(
    provider => provider.GetRequiredService<MongoClient>().GetDatabase("mtracker"));
builder.Services.AddSingleton(
    provider => provider.GetRequiredService<IMongoDatabase>().GetCollection<Position>("tracker"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapHub<TrackerHub>("/tracker");
app.Run();
