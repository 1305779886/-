using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Metadata;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ALEXFW.CommonUtility;
using ALEXFW.Entity.Demos;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    public class ProductController : EntityController<Product>
    {
        public ProductController(IEntityContextBuilder builder) : base(builder)
        {
        }

        //处理图片上传到网站
        protected override async Task UpdateProperty(Product entity, IPropertyMetadata propertyMetadata)
        {
            if (propertyMetadata.CustomType == "SingleImage")
            {
                var oldImage = this.UpSingleImage(entity);
                if(oldImage!=entity.ImageUrl)
                    propertyMetadata.SetValue(entity,oldImage);
            }
            else
            {
                await  base.UpdateProperty(entity, propertyMetadata);
            }
        }
    }
}