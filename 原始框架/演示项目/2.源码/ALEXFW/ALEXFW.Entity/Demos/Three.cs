using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using ALEXFW.Entity.UserAndRole;

namespace ALEXFW.Entity.Demos
{
    public class Three:EntityBase
    {
        [Display(Name = "分类名称", Order = 1)]
        [Required(ErrorMessage = "分类名称不能为空")]
        public virtual string Name { get; set; }

        [Display(Name = "说明", Order = 10)]
        //字段的隐藏 按需求在不同的视图显示 
        [Hide(IsHiddenOnCreate = false, IsHiddenOnDetail = false, IsHiddenOnEdit = false)]
        public virtual string Description { get; set; }

        //分类的编号
        [Required(ErrorMessage = "分类编号不能为空")]
        [Display(Name = "分类编号", Order = 0)]
        public virtual string SortCode { get; set; }
    }
}