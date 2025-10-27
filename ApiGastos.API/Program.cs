//builder.Services.AddOpenApi();
using ApiGastos.Builder;

using ApiGastos.API.Middlewares;
// ejecutar dotnet run --project ApiGastos.API
namespace ApiGastos
{
    public class Program
    {
        static void Main(string[] args)
        {
            BuilderClass builder = new BuilderClass();
            var app = builder.Builder(args);

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            DataBaseConfig.DBConfig(app);


            app.UseRedirect(); // no es request es redirect
            
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
