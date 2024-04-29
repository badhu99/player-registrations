using PlayerRegistration;
using PlayerRegistration.Interfaces;
using PlayerRegistration.Services;
using PlayerRegistration.Settings;

try
{
    var builder = WebApplication.CreateBuilder(args);
    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();
    builder.Services.AddLogging();

    builder.Services.AddScoped<IReaderService, XmlReaderService>();
    builder.Services.AddScoped<IBusinessLogicService, BusinessLogicService>();
    builder.Services.AddScoped<IEventService, EventService>();

    builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection(RabbitMQSettings.Section));

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.MapControllers();

    app.Run();
}
catch (Exception e)
{
    // TODO error handling and logging
    Console.WriteLine(e.Message);
}