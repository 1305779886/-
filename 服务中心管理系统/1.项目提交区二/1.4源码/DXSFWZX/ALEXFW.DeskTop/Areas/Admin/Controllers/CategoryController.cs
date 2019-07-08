using ALEXFW.Entity.Demos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    public class CategoryController : EntityController<Category>
    {
        public CategoryController(IEntityContextBuilder builder) : base(builder)
        {

        }
    }
}
