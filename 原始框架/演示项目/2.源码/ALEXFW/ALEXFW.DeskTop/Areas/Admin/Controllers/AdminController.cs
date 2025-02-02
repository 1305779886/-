﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ALEXFW.Entity.UserAndRole;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    public class AdminController : EntityController<Entity.UserAndRole.Admin>
    {
        public AdminController(IEntityContextBuilder builder) : base(builder)
        {
        }

        /// <summary>
        /// 更新实体，需求：在更新前检测一个店铺只能有一名店长
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<ActionResult> Update(Guid id)
        {
            //工号权限设置
            var employeeCode = Request.Form["EmployeeCode"].Trim();
            var EmployeeDB = EntityBuilder.GetContext<Entity.UserAndRole.Admin>();
            if (employeeCode=="0")
            {
                Response.StatusCode = 400;
                return new ContentResult
                {
                    Content = "工号不得为空"
                };
            }
            else if(EmployeeDB.Query().Any(x=>x.EmployeeCode==employeeCode))
            {
                Response.StatusCode = 400;
                return new ContentResult
                {
                    Content = "已存在工号编号为"+employeeCode+"的编号"
                };
            }

            //用户名权限设置
            var username = Request.Form["Username"].Trim();
            var UsernameDB = EntityBuilder.GetContext<Entity.UserAndRole.Admin>();
            if (username == "0")
            {
                Response.StatusCode = 400;
                return new ContentResult
                {
                    Content = "用户名不得为空"
                };
            }
            else if (UsernameDB.Query().Any(x => x.Username == username))
            {
                Response.StatusCode = 400;
                return new ContentResult
                {
                    Content = "已存在用户名为" + username + "的用户"
                };
            }

            //用户角色不得为空
            var loginName = Request.Form["Group"].Trim();
            if(loginName == "0")
            {
                Response.StatusCode = 400;
                return new ContentResult
                {
                    Content = "用户权限不能为空"
                };
            }
            //条件约束
            //查询用户提交的表单中的店铺是否存在店长
            var deptId = Request.Form["Department"].Trim();
            //创建上下文
            var deptContext = EntityBuilder.GetContext<Department>();
            var adminContext = EntityBuilder.GetContext<Entity.UserAndRole.Admin>();

            if (!string.IsNullOrEmpty(deptId))
            {
                //从表单中获得用户输入的店铺
                var department = await deptContext.GetEntityAsync(Guid.Parse(deptId));

                //从用户提交的表单中，获取用户当前输入的用户是否为店长
                var group = (AdminGroup)Enum.Parse(typeof(AdminGroup), Request.Form["Group"]);

                //判断当前店铺是否已经有店长
                if (group.HasFlag(AdminGroup.店长) && adminContext.Query()
                        .Any(x => x.Department.Index == department.Index && x.Group.HasFlag(AdminGroup.店长)))
                {
                    Response.StatusCode = 400;
                    return new ContentResult
                    {
                        Content = department.DepartmentName + "已经有一名店长"
                    };
                }
            }
            else
            {
                //只有管理员可以不关联店铺，店长和业务员必须选择关联一个店铺
                //从用户提交的表单中，获取用户当前输入的角色
                var group = (AdminGroup)Enum.Parse(typeof(AdminGroup), Request.Form["Group"]);
                if (!group.HasFlag(AdminGroup.管理员))
                {
                    Response.StatusCode = 400;
                    return new ContentResult
                    {
                        Content = "除了管理员角色，店长或业务员必须关联一个店铺"
                    };
                }
            }

            //更新实体的父类的方法 ，不要修改
            return await Untils.GetUpdateAction((p, entity) => { return UpdateCore(entity); }, UpdateProperty, id);
        }
    }
}