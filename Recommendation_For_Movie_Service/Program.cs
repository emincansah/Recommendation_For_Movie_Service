using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RFM.Data.Context;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Hangfire;
using Recommendation_For_Movie_Service.Hangfire;
using RFM.Entities.Conrete;
using Business.DiContainer;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

// For Entity Framework
builder.Services.AddHangfire(options => options.UseSqlServerStorage(configuration.GetValue<string>("HangfireDbConn"))); 
// For Identity
builder.Services.AddHangfireServer();
//emailconfiguration
var emailConfig = builder.Configuration
       .GetSection("EmailConfiguration")
       .Get<EmailConfiguration>();

builder.Services.AddSingleton(emailConfig);
builder.Services.AddContainerWithDependencies();
// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
   


// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard();

RecurringJob.AddOrUpdate(() => Hangfirehelper.ProcessRecurringMovieJob(), Cron.Hourly);

RecurringJob.AddOrUpdate(() => Hangfirehelper.ProcessRecurringMailJob(emailConfig), Cron.Minutely);
app.UseHttpsRedirection();

// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

