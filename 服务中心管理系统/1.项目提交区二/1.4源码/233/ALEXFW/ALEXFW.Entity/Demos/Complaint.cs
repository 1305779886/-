using ALEXFW.Entity.UserAndRole;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ALEXFW.Entity.Demos
{
    [EntityAuthentication(AllowAnonymous = false,
      AddRolesRequired = new object[] { AdminGroup.在校学生 },
     // EditRolesRequired = new object[] { AdminGroup.学生服务中心队长| AdminGroup.在校学生 },
      RemoveRolesRequired = new object[] { AdminGroup.在校学生 })]
    [DisplayName("投诉信息")]
    public class Complaint : EntityBase
    {
        [PropertyAuthentication(AllowAnonymous = true,
       EditRolesRequired = new object[] { AdminGroup.在校学生 })]
        
        [Required(ErrorMessage = "投诉信息不能为空")]
        [Display(Name = "投诉信息", Order = 2)]
        [Searchable]
        public virtual string ComInformation { get; set; }


        // [Hide(IsHiddenOnCreate = false, IsHiddenOnEdit = true)]
        [PropertyAuthentication(AllowAnonymous = true,
          EditRolesRequired = new object[] { AdminGroup.学生服务中心队长 })]
        [Display(Name = "投诉信息的反馈", Order = 3)]
        [Searchable]
        public virtual string Feedback { get; set; }

    }
}
