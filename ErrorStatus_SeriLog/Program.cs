using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((context, configuration) =>
configuration.ReadFrom.Configuration(context.Configuration));


var app = builder.Build();//This is one request pipeLine
////here we need to add/register/configure all middlewares
////Whenevere you need to add middleware request pipeline it will execute orderwise , first,second,third
////middleware naming convetion starts with "use" keyword

//app.Use(async (context, next) => {//app.Use for Inline middlewares
//    await context.Response.WriteAsync("Hello I am From user9");
//    await next.Invoke();//next will call the next middleware
//});
//app.Use(async (context, next) => {//app.Use for Inline middlewares
//    await context.Response.WriteAsync("Hello I am From user1");
//    await next.Invoke();//next will call the next middleware
//});
//app.Use(async (context, next) => {//app.Use for Inline middlewares
//    await context.Response.WriteAsync("Hello I am From user2");
//    await next.Invoke();//next will call the next middleware
//});
//app.Use(async (context, next) => {//app.Use for Inline middlewares
//    await context.Response.WriteAsync("Hello I am From user3");
//    await next.Invoke();//next will call the next middleware
//});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseSerilogRequestLogging();

app.UseAuthorization();

app.MapControllers();

app.Run();//without app.run()method application will not execute
