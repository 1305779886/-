using ALEXFW.Entity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{

    public class MemberCardController : EntityController
    {
        // GET: Admin/MemberCard
        public MemberCardController(IEntityContextBuilder builder) : base(builder)
        {

        }
        [EntityAuthorize]
        public ActionResult Index(Guid id)
        {
            var memberContext = EntityBuilder.GetContext<Member>();
            //var memberCardContext = EntityBuilder.GetContext<MemberCard>();
            var member = memberContext.GetEntity(id);
            Session["member"] = member;
            return View("_MemberCardTable");
        }
        [EntityAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        [EntityAuthorize]
        [HttpPost]
        public async Task<ActionResult> Create(MemberCard model)
        {
            if (model.CardNumber == null)
            {
                Response.StatusCode = 400;
                return new ContentResult
                {
                    Content = "会员卡号为必填项"
                };
            }

            var memberCardcontext = EntityBuilder.GetContext<MemberCard>();
            var memberCard = new Entity.UserAndRole.MemberCard();


            var memberContext = EntityBuilder.GetContext<Member>();
            var memberSession = (Session["member"] as Entity.UserAndRole.Member);
            var member = await memberContext.GetEntityAsync(memberSession.Index);

            foreach (var item in member.MemberCards)
            {
                if (item.IsActivate == true)
                {
                    Response.StatusCode = 400;
                    return new ContentResult
                    {
                        Content = "会员：" + member.PersonName + "已有会员卡处于激活状态"
                    };
                }
            }

            if (memberCardcontext.Query().Any(mc => mc.CardNumber == model.CardNumber))
            {
                Response.StatusCode = 400;
                return new ContentResult
                {
                    Content = "已存在会员卡号：" + model.CardNumber
                };
            }

            memberCard.CardNumber = model.CardNumber;
            memberCard.IsActivate = model.IsActivate;
            await memberCardcontext.AddAsync(memberCard);

            member.MemberCards.Add(memberCard);
            await memberContext.EditAsync(member);
            return RedirectToAction("index", new { id = memberSession.Index });
        }

        [EntityAuthorize]
        //[HttpPost]
        public async Task<ActionResult> NotActivated(Guid id)
        {
            var memberCardcontext = EntityBuilder.GetContext<MemberCard>();
            var memberCard = await memberCardcontext.GetEntityAsync(id);
            memberCard.IsActivate = false;
            await memberCardcontext.EditAsync(memberCard);
            var memberSession = (Session["member"] as Entity.UserAndRole.Member);
            return RedirectToAction("index", new { id = memberSession.Index });
        }
    }
}
