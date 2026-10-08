
var builder = WebApplication.CreateBuilder(args);

// Read the connection string
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
	?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Example: Registering EF Core DbContext (when configured later)
// builder.Services.AddDbContext<OrderDbContext>(options => 
//     options.UseSqlServer(connectionString));

var app = builder.Build();

app.MapGet("/", () => "NotificationService is running!");
Console.WriteLine("NotificationService is running!");
app.Run();
