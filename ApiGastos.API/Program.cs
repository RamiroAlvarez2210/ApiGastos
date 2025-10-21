//builder.Services.AddOpenApi();
using ApiGastos.Builder;


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
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
