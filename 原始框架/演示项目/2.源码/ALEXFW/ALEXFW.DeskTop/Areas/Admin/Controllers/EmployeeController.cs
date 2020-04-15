using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ALEXFW.Entity.Demos;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    public class EmployeeController : EntityController<Employee>
    {
        public EmployeeController(IEntityContextBuilder builder) : base(builder)
        {
        }
    }
}