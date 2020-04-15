using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ALEXFW.Entity.Demos;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    public class SalesmenController : EntityController<Salesman>
    {
        public SalesmenController(IEntityContextBuilder builder) : base(builder)
        {
        }
    }
}