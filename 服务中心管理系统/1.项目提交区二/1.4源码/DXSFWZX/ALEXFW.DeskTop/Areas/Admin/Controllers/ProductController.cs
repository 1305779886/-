using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ALEXFW.Entity.Demos;
using System.Data.Entity.Metadata;
using System.Threading.Tasks;
using ALEXFW.CommonUtility;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    public class ProductController : EntityController<Product>
    {
        public ProductController(IEntityContextBuilder builder) : base(builder)
        {

        }
        //处理图片上传到网上
        protected override async Task UpdateProperty(Product entity, IPropertyMetadata propertyMetadata)
        {
            //return base.UpdateProperty(entity, propertyMetadata);
            if(propertyMetadata.CustomType=="SingleImage")
            {
                var oldImage = this.UpSingleImage(entity);
                if (oldImage != entity.ImageUrl)
                    propertyMetadata.SetValue(entity,oldImage);
            }
            else
            {
                await base.UpdateProperty(entity,propertyMetadata);
            }
        }
    }
}