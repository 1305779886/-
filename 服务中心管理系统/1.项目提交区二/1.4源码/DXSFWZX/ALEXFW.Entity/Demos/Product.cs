using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ALEXFW.Entity.Demos
{
    [DisplayName("商品")]
    [DisplayColumn("Name","SortCode",false)]
    //树型筛选
    [Parent(typeof(Category), "Category")]

    public class Product: EntityBase

    {
        [Required(ErrorMessage ="商品名称不能为空")]
        [Display(Name="商品名称",Order=2)]
        public virtual string Name { get; set; }

        [Required(ErrorMessage = "商品编号不能为空")]
        [Display(Name = "商品编号", Order = 1)]
        public virtual string SortCode { get; set; }

        [Required(ErrorMessage = "商品说明不能为空")]
        [Display(Name = "商品说明", Order = 10)]
        public virtual string Description{ get; set; }

        [Required(ErrorMessage = "商品价格不能为空")]
        [Display(Name = "商品价格", Order = 4)]
        public virtual decimal Price { get; set; } = 0.00M;
        //与分类关联
        [Required(ErrorMessage = "商品分类不能为空")]
        [Display(Name = "商品分类", Order = 4)]
        public virtual Category Category { get; set; }
        //单张图片显示的字段
        [Display(Name = "商品封面", Order = 100)]
        [CustomDataType("SingleImage")]
        [Hide(IsHiddenOnCreate =false,IsHiddenOnEdit =false)]
        public virtual string ImageUrl { get; set; }
        public override void OnCreateCompleted()
        {
            base.OnCreateCompleted();
            //在此对象被创建时，保存当前时间
            CreateDate = DateTime.Now;

        }

    }
}
