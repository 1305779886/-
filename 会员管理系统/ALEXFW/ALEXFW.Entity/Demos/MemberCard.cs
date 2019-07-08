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
    [EntityAuthentication(AllowAnonymous = false)]

    [DisplayName("会员卡")]
    [DisplayColumn("CardNumber", "CardNumber", true)]
    public class MemberCard : EntityBase
    {

        [Required(ErrorMessage = "卡号不能为空")]
        [Searchable]
        [Distinct]
        [Display(Name = "卡号", Order = 0)]
        public virtual string CardNumber { get; set; }

        [Required(ErrorMessage = "卡状态不能为空")]
        [Searchable]
        [Display(Name = "是否激活", Order = 2)]
        public virtual bool IsActivate { get; set; }


    }
}