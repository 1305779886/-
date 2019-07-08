using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALEXFW.Entity.UserAndRole;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ALEXFW.Entity.UserAndRole
{
    [DisplayName("维修小队")]
    [DisplayColumn("TeamName")]
    [Parent(typeof(GroupTeam), "ParentDepartment")]
    public class GroupTeam : EntityBase
    {
        [Searchable]
        [Display(Name = "维修小队队伍编号", Order = 0)]
        [Required(ErrorMessage = "队伍编号不得为空")]
        public virtual string TeamID { get; set; }

        [Searchable]
        [Display(Name = "维修小队队伍名称", Order = 0)]
        [Required(ErrorMessage = "队伍名称不得为空")]
        public virtual string TeamName { get; set; }

        [Hide]
        [Display(Name = "维修小队人员")]
        public virtual ICollection<Admin> Admins { get; set; } //维修小队人员

        //public override void OnCreateCompleted()
        //{
        //    base.OnCreateCompleted();
        //    CreateDate = DateTime.Now;
        //}
    }
}
