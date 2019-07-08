using ALEXFW.Entity.UserAndRole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALEXFW.Entity.Demos
{

    [EntityAuthentication(AllowAnonymous = false,
AddRolesRequired = new object[] { AdminGroup.店长 },
EditRolesRequired = new object[] { AdminGroup.店长 },
RemoveRolesRequired = new object[] { AdminGroup.店长 },
ViewRolesRequired = new object[] { AdminGroup.店长 })]
    [DisplayName("业务员")]
    [DisplayColumn("Name", "Name")]

    public class Salesman:EntityBase
    {
        [Display(Name = "业务员名称", Order = 0)]
        [Required]
        public virtual string Name { get; set; }

        [Display(Name = "性别", Order = 10)]
        [CustomDataType(CustomDataType.Sex)]
        public virtual bool Sex { get; set; }

        [Required]
        [Display(Name = "业务员工号", Order = 20)]
        public virtual string JobNumber { get; set; }

        [Display(Name = "联系电话", Order = 60)]
        public virtual string Tel { get; set; }
    }
}
