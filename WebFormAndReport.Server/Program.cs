using Microsoft.EntityFrameworkCore;
using WebFormAndReport.Server.Data;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------------------------------
// 1️⃣ Configure Database Connection
// ---------------------------------------------------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ---------------------------------------------------
// 2️⃣ Enable CORS for Angular (61706)
// ---------------------------------------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("https://127.0.0.1:61706", "https://localhost:61706") // Angular dev ports
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// ---------------------------------------------------
// 3️⃣ Add Controllers, Swagger, etc.
// ---------------------------------------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ---------------------------------------------------
// 4️⃣ Development Middleware
// ---------------------------------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage(); // 🧠 show full exception details
}

// ---------------------------------------------------
// 5️⃣ CORS + HTTPS + Routing
// ---------------------------------------------------
app.UseHttpsRedirection();
app.UseCors("AllowAngularApp"); // must come BEFORE MapControllers()
app.UseAuthorization();
app.MapControllers();

// ---------------------------------------------------
// 6️⃣ Run the Application
// ---------------------------------------------------
app.Run();
