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
    [DisplayName("礼品管理")]
    [DisplayColumn("Name", "SortCode", false)]
    public class Gift:EntityBase
    {
        [Required(ErrorMessage = "礼品名称不能为空")]
        [Display(Name = "礼品名称", Order = 2)]
        public virtual string Name { get; set; }

        [Required(ErrorMessage = "礼品编号不能为空")]
        [Display(Name = "礼品编号", Order = 1)]
        [Searchable]

        public virtual string SortCode { get; set; }

        [Display(Name = "礼品分类", Order = 4)]
        [Required(ErrorMessage = "礼品分类不能为空")]
        public virtual Present Present { get; set; }


        [Display(Name = "备注", Order = 10)]
        [Hide(IsHiddenOnCreate = false, IsHiddenOnEdit = false)]
        public virtual string Description { get; set; }

    }
}
