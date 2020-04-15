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
    [DisplayName("礼品分类")]
    [DisplayColumn("Name", "SortCode")]
    public class Present:EntityBase
    {
        [Display(Name = "分类名称", Order = 0)]
        [Required]
        [Searchable]
        public virtual string Name { get; set; }

        [Display(Name = "分类编号", Order = 0)]
        [Required]
        [Searchable]
        public virtual string SortCode { get; set; }

        [Hide]
        public virtual ICollection<Gift> Gifts { get; set; }
        public override bool IsRemoveAllowed
        {
            get { return Gifts.Count == 0; }
        }
    }
}
