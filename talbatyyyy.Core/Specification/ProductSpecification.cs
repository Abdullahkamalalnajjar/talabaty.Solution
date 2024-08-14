using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using talabatyyyy.Core.Entities;
using talabatyyyy.Core.ParamOfQuery;

namespace talabatyyyy.Core.Specification
{
    public class ProductSpecification:BaseSpecification<Product>
    {
       
        public ProductSpecification(ProductParamQuery productParam)
        //:base(p=> (!brandid.HasValue || p.ProductBrand.Id==brandid) && (!typeid.HasValue || p.ProductType.Id == typeid))
        {
            if (productParam.BrandId.HasValue)
            {
                Criteria = p => p.ProductBrand.Id== productParam.BrandId;
            }
            else if(productParam.TypeId.HasValue)
            {
                Criteria = p => p.ProductType.Id == productParam.TypeId;

            }

            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductType);
            if (!string.IsNullOrEmpty(productParam.Sort))
            {
                switch (productParam.Sort)
                {
                    case "PriceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "PriceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
       

              AddPagination((productParam.PageSize * (productParam.PageIndex - 1)), productParam.PageSize);


        }
        public ProductSpecification(int id):base(p=>p.Id.Equals(id)) 
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductType);
        }

      
    }
}
