using AutoMapper;
using talabatyyyy.Core.Entities;
using talabatyyyy.test.Dtos;

namespace talabatyyyy.test.Helpers
{
    public class ProductPictureUrlResolve : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration configuration;

        public ProductPictureUrlResolve(IConfiguration configuration) {
            this.configuration = configuration;
        }
        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{configuration["ApiBaseUrl"]}{source.PictureUrl}";
            }
            return string.Empty ;
        }
    }
}
