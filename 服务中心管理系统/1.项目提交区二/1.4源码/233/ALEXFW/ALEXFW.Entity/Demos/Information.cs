using ALEXFW.Entity.UserAndRole;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace ALEXFW.Entity.Demos 
{
    [EntityAuthentication(AllowAnonymous = false,
       AddRolesRequired = new object[] { AdminGroup.在校学生  },
       EditRolesRequired = new object[] { AdminGroup.在校学生 },
       RemoveRolesRequired = new object[] { AdminGroup.在校学生 })]
    [DisplayName("信息反馈")]
    public class Information : EntityBase 
    {
        //[Required(ErrorMessage = "维修单号不能为空")]
        //[Searchable]
        //[Display(Name = "维修单号", Order = 0)]
        //public virtual CaptainsRepair CaptainID { get; set; }

        [Required(ErrorMessage = "信息反馈不能为空")]
        [Display(Name = "信息反馈", Order = 2)]
        [Searchable]
        public virtual string Feedback { get; set; }

       

    }
}
