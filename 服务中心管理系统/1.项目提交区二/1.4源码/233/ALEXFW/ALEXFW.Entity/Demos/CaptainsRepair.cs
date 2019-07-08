using ALEXFW.Entity.UserAndRole;
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
    //角色权限控制
    [EntityAuthentication(AllowAnonymous = false,
        AddRolesRequired = new object[] { AdminGroup.学生服务中心队长 },
        EditRolesRequired = new object[] { AdminGroup.服务中心维修人员 },
        RemoveRolesRequired = new object[] { AdminGroup.学生服务中心队长 },
        ViewRolesRequired = new object[] { AdminGroup.服务中心维修人员 })]
    [DisplayName("维修服务")]
    [DisplayColumn("Name", "CaptainID")]
    public class CaptainsRepair:EntityBase
    {
        //[Hide(IsHiddenOnCreate =false,IsHiddenOnEdit =false)]
        //[Display(Name = "学生报修", Order = 5)]
        //public virtual StudentRepair StudentRepair { get; set; }

        //[PropertyAuthentication(AllowAnonymous = true,
        //   EditRolesRequired = new object[] { AdminGroup.学生服务中心管理员 })]
        //[Hide(IsHiddenOnCreate = false, IsHiddenOnEdit = true)]
        [Distinct(ErrorMessage = "编号不能重复")]
        [Required(ErrorMessage = "维修单号不能为空")]
        [Searchable]
        [Display(Name = "编号", Order = 0)]
        public virtual string CaptainID { get; set; }
        //[Required(ErrorMessage = "编号不能为空")]
        //[Searchable]
        //[Display(Name = "编号", Order = 3)]
        //public virtual DateTime NowDateTime { get; set; }

        // [Hide(IsHiddenOnCreate = false, IsHiddenOnEdit = false)]
        // [Display(Name = "学生报修", Order = 5)]
        //public virtual StudentRepair StudentRepair { get; set; }

        //[Hide(IsHiddenOnView = false, IsHiddenOnDetail = false)]
        [PropertyAuthentication(AllowAnonymous = true,
            EditRolesRequired = new object[] { AdminGroup.学生服务中心队长 })]
        [Required(ErrorMessage = "校区不能为空")]
        [Searchable]
        [Display(Name = "校区", Order = 4)]
        public virtual string Campus { get; set; }

        [PropertyAuthentication(AllowAnonymous = true,
            EditRolesRequired = new object[] { AdminGroup.学生服务中心队长 })]
        [Required(ErrorMessage = "地点不能为空")]
        [Searchable]
        [Display(Name = "地点", Order = 3)]
        public virtual string Place { get; set; }

        [PropertyAuthentication(AllowAnonymous = true,
            EditRolesRequired = new object[] { AdminGroup.学生服务中心队长 })]
        [Required(ErrorMessage = "学号不能为空")]
        [Searchable]
        [Display(Name = "学号", Order = 1)]
        public virtual string StudentID { get; set; }

        [PropertyAuthentication(AllowAnonymous = true,
            EditRolesRequired = new object[] { AdminGroup.学生服务中心队长 })]
        // [Required(ErrorMessage = "姓名不能为空")]
        [Searchable]
        [Display(Name = "姓名", Order = 2)]
        public virtual string Name { get; set; }

        [PropertyAuthentication(AllowAnonymous = true,
            EditRolesRequired = new object[] { AdminGroup.学生服务中心队长 })]
        [Required(ErrorMessage = "宿舍不能为空")]
        [Searchable]
        [Display(Name = "宿舍号", Order = 5)]
        public virtual Dorm Dorm { get; set; }

        [PropertyAuthentication(AllowAnonymous = true,
            EditRolesRequired = new object[] {AdminGroup.学生服务中心队长 })]
        [Required(ErrorMessage = "电话不能为空")]
        [Searchable]
        [Display(Name = "电话", Order = 3)]
        public virtual string Tel { get; set; }

        [PropertyAuthentication(AllowAnonymous = true,
            EditRolesRequired = new object[] {AdminGroup.学生服务中心队长 })]
        [Required(ErrorMessage = "部门/班级不能为空")]
        [Searchable]
        [Display(Name = "部门/班级", Order = 6)]
        public virtual string Department { get; set; }

        [PropertyAuthentication(AllowAnonymous = true,
            EditRolesRequired = new object[] { AdminGroup.学生服务中心队长 })]
        [Required(ErrorMessage = "事项不能为空")]
        [Display(Name = "事项", Order = 7)]
        public virtual string Matters { get; set; }

        [PropertyAuthentication(AllowAnonymous = true,
            EditRolesRequired = new object[] {  AdminGroup.学生服务中心队长})]
        [Display(Name = "维修人员", Order = 8)]
        public virtual Admin Admin  { get; set; }

        [PropertyAuthentication(AllowAnonymous = true,
    EditRolesRequired = new object[] { AdminGroup.在校学生 })]
        [Display(Name = "反馈", Order = 11)]
        public virtual string Retroaction { get; set; }

        //[PropertyAuthentication(AllowAnonymous = true,
        // EditRolesRequired = new object[] { AdminGroup.学生服务中心队长 })]
        [Hide(IsHiddenOnCreate = true, IsHiddenOnEdit = false)]
        [Display(Name = "是否处理", Order = 50)]
        public virtual bool Processed { get; set; }

        [PropertyAuthentication(AllowAnonymous = true,
            EditRolesRequired = new object[] { AdminGroup.在校学生 })]
        [Display(Name = "照片", Order = 20)]
        [CustomDataType("SingleImage")]
        [Hide(IsHiddenOnCreate = false, IsHiddenOnEdit = false)]
        public virtual string Avatar { get; set; }

        //[PropertyAuthentication(AllowAnonymous = true,
        // EditRolesRequired = new object[] { AdminGroup.学生服务中心管理员 })]
        //[Display(Name = "开始时间", Order = 99)]
        //public virtual DateTime Time { get; set; }

        //[PropertyAuthentication(AllowAnonymous = true,
        // EditRolesRequired = new object[] { AdminGroup.学生服务中心管理员 })]
        //[Display(Name = "结束时间", Order = 100)]
        //public virtual DateTime Hour { get; set; }
    }
}
