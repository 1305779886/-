﻿using ALEXFW.Entity.Demos;
using ALEXFW.Entity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    public class GradeController : EntityController<Grade>
    {
        public GradeController(IEntityContextBuilder builder) : base(builder)
        {

        }

    }

}