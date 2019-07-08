using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALEXFW.Entity.UserAndRole
{
    [DisplayName("日志")]
    [DisplayColumn("Logs", "CreateDate", true)]
    public class UserLog:EntityBase
    {
        public  virtual string UserName { get; set; }
        public virtual  string RoleName { get; set; }
        public virtual string Logs { get; set; }    //日志内容

        public override void OnCreateCompleted()
        {
            base.OnCreateCompleted();
            CreateDate = DateTime.Now;
        }
    }
}
