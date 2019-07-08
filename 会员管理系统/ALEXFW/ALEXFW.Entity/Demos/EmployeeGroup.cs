using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALEXFW.Entity.Demos
{
    [DisplayName("员工分组")]
    [DisplayColumn("GroupName", "GroupName")]
    public class EmployeeGroup : EntityBase
    {
        [Required]
        [Display(Name = "员工组名称", Order = 0)]
        public virtual string GroupName { get; set; }

        //包含  该组包含的员工集合
        [Hide]
        public virtual ICollection<Employee> Employees { get; set; }
    }

}
