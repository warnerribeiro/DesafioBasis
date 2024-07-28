using Backend.Model;
using Core.Repository;
using Core.Repository.Implementation;
using Microsoft.EntityFrameworkCore;
using Web.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer("name=ConnectionStrings:SqlServerDev"));
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IBookAutorRepository, BookAuthorRepository>();
builder.Services.AddScoped<IBookSubjectRepository, BookSubjectRepository>();
builder.Services.AddScoped<IBookValueRepository, BookValueRepository>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.IgnoreNullValues = true;
});

//builder.Services.AddProblemDetails();

var app = builder.Build();

//app.UseExceptionHandler();
//app.UseStatusCodePages();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //app.UseExceptionHandler("/error-development");
    //app.UseDeveloperExceptionPage();
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<DataContext>();
        db.Database.Migrate();
    }
}
//else
//{
//    app.UseExceptionHandler("/error");
//}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
