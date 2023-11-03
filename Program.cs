using BookReviewApp.Backend.Core.AutoMapperConfig;
using BookReviewApp.Backend.Core.Context;
using BookReviewApp.Backend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookCategoryService, BookCategoryService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IReviewService, ReviewService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});

// Auto Mapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfigProfile));

// Json Serializer
builder.Services.AddControllers()
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:7277/", "https://localhost:7277/")
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials()
                                .SetIsOriginAllowed((host) => true)
                                .WithMethods();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "PathImages", "ProfileImages")),
    RequestPath = "/ProfileImages"
});

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "PathImages", "BookCoverImages")),
    RequestPath = "/BookCoverImages"
});

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
