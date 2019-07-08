using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ALEXFW.CommonUtility;
using ALEXFW.DeskTop.ViewModels;
using ALEXFW.Entity.UserAndRole;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    public class MembersController : EntityController<Member>
    {
        public MembersController(IEntityContextBuilder builder) : base(builder)
        {

        }
    }
}