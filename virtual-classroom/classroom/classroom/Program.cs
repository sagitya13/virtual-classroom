
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using classroom.Repository;
using classroom.Repository.Interface;
using classroom.services;
using classroom.services.Interface;
using Microsoft.Extensions.Options;
using System.Text;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = config["Jwt:Issuer"],
            ValidAudience = config["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
        };
    });
builder.Services.AddControllers();
builder.Services.AddScoped<IcourseRepo, courseRepo>();
builder.Services.AddTransient<courseService>();

builder.Services.AddScoped<IUsersRepo, UsersRepo>();
builder.Services.AddTransient<UsersService>();

builder.Services.AddScoped<IMaterialsRepo, MaterialsRepo>();
builder.Services.AddTransient<MaterialsService>();

builder.Services.AddScoped<IQuestionRepo, QuestionRepo>();
builder.Services.AddTransient<QuestionService>();
 

builder.Services.AddScoped<IMessageRepo, MessageRepo>();
builder.Services.AddTransient<MessageServices>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors((o) =>
{
    o.AddPolicy("corspolicy", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("corspolicy");

app.Run();
