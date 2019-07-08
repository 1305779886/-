using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ALEXFW.CommonUtility;
using ALEXFW.DeskTop.ViewModels;
using ALEXFW.Entity.UserAndRole;

namespace ALEXFW.DeskTop.Areas.Admin.Controllers
{
    public class AdminsController : EntityController<Entity.UserAndRole.Admin>
    {

        public AdminsController(IEntityContextBuilder builder) : base(builder)
        {

        }
    }
}