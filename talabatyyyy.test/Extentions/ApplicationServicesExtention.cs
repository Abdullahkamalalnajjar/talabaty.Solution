using Microsoft.AspNetCore.Mvc;
using talabatyyy.Repository;
using talabatyyyy.Core.Repository;
using talabatyyyy.test.Errors;
using talabatyyyy.test.Helpers;

namespace talabatyyyy.test.Extentions
{
    public static class ApplicationServicesExtention
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services)
        {


            #region Cfg ResolvePictureUrl
            Services.AddScoped<ProductPictureUrlResolve>();
            #endregion
            #region ConfigurationGenericRepository
            Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            #endregion
            #region Config AutoMapper 
            Services.AddAutoMapper(cfg => cfg.AddProfile(typeof(MappingProfiles)));
            #endregion
            #region Api Behavior to handl validation
            Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(p => p.Value.Errors.Count() > 0)
                    .SelectMany(e => e.Value.Errors)
                    .Select(e => e.ErrorMessage).ToList();
                    var apiValidationResponse = new ApiValidationResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(apiValidationResponse);
                };
            });
            #endregion

            return Services;
        }
    }
}
