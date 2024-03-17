using EventsServices.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Cors policy to Allow All Orgins
builder.Services.AddCors(options =>
{
  options.AddDefaultPolicy(
       builder =>
       {
         builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
       });
});

//Inject IEventService
builder.Services.AddScoped<IEventService, EventService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
