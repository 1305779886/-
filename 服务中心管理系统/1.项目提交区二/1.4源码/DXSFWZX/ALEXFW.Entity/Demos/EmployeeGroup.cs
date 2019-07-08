using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ALEXFW.DeskTop.Areas.Admin.Models
{
    [DisplayName("员工组")]
    [DisplayColumn("GroupName", "GroupName")]
    public class EmployeeGroup : EntityBase
    {
        [Required]
        [Display(Name = "员工组名称", Order = 0)]
        public virtual string GroupName { get; set; }
        [Hide]
        public virtual ICollection<Employee> Employees { get; set; }

    }
}