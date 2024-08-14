using System.Runtime.CompilerServices;

namespace talabatyyyy.test.Extentions
{
    public static class SwaggerServicesExtention
    {
        public static  WebApplication AddServicesSwagger(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }
    }
}
