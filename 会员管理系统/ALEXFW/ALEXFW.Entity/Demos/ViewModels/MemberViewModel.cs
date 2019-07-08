using ALEXFW.Entity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ALEXFW.DeskTop.ViewModels
{
    public class MemberViewModel:UserBase
    {
        public List<Member> Members { get; set; }
    }
}