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
    [DisplayName("员工")]
    [DisplayColumn("Name", "Name")]
    public class Employee : EntityBase
    {
        [Display(Name = "员工名称", Order = 0)]
        [Required]
        public virtual string Name { get; set; }

        [Display(Name = "性别", Order = 10)]
        [CustomDataType(CustomDataType.Sex)]
        public virtual bool Sex { get; set; }

        [Required]
        [Display(Name = "员工工号", Order = 20)]
        public virtual string JobNumber { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "出生日期", Order = 30)]
        public virtual DateTime Birth { get; set; }

        [Display(Name = "婚否", Order = 40)]
        public virtual bool Marital { get; set; }

        [Display(Name = "部门", Order = 50)]
        public virtual EmployeeGroup Group { get; set; }

        [Display(Name = "联系电话", Order = 60)]
        public virtual string Tel { get; set; }

        [Display(Name = "电子邮件", Order = 70)]
        public virtual string Email { get; set; }

        [Display(Name = "QQ", Order = 80)]
        public virtual string QQ { get; set; }
    }
}
