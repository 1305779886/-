using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ALEXFW.Entity.UserAndRole;

namespace ALEXFW.Entity.Demos
{/// <summary>
/// 商品分类的实体
/// </summary>
[DisplayName("商品分类")]
//实列缺省显示字段，缺省排序字段，缺省排序方式
//false是顺序排序，Order是排序的一个属性
[DisplayColumn("Name","SortCode",false)]
//实体的权限控制
[EntityAuthentication(AllowAnonymous =false,//拒绝匿名用户访问实体
        AddRolesRequired =new object[]{AdminGroup.管理员},//只有管理员权限可以添加
        EditRolesRequired =new object[]{AdminGroup.管理员},//只有管理员权限可以编辑
        RemoveRolesRequired =new object[]{ AdminGroup.管理员})]//只有管理员可以删除
        //ViewRolesRequired =new object[]{ AdminGroup.管理员 }
    public class Category:EntityBase

    {
        //ef中要求属性需要的virtual
        //分类的名称，字段排序权值order
        [Display(Name="分类名称",Order =1)]
        //显示错误信息
        [Required(ErrorMessage ="分类名称不能为空")]
        public virtual string Name { get; set; }

        [Display(Name = "分类编号",Order=0)]
        public virtual string SortCode { get; set; }
        [Display(Name = "说明",Order =10)]
        //字段的隐藏，按需求在不同的视图下显示
        [Hide(IsHiddenOnCreate =false,IsHiddenOnDetail =false,IsHiddenOnEdit =false)]
        public virtual string Description { get; set; }
        //希望能自动记录每条数据添加的时间
        public override void OnCreateCompleted()
        {
            base.OnCreateCompleted();
            //在此对象被创建时，保存当前时间
            CreateDate = DateTime.Now;
        }
    }
}
