using Microsoft.EntityFrameworkCore;
using OneToManyRelation.AutoMapping;
using OneToManyRelation.Context;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RelationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

//builder.Services.AddHttpsRedirection(options =>
//{
//    options.HttpsPort = 8080;  
//});
//builder.WebHost.UseUrls("http://0.0.0.0:80");


//builder.Services.AddControllers()
//        .AddJsonOptions(options =>
//        {
//            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//        });
var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
