using System.Web.Mvc;
using System.ServiceModel;
using General;
using WCF_Member_SelfHost;

namespace ClientApp.Controllers
{
    public class HomeController : Controller
    {
        IMemberService Service;

        public HomeController()
        {
            WSHttpBinding binding = new WSHttpBinding();
            EndpointAddress address = new EndpointAddress("http://localhost:8888/Product");
            ChannelFactory<IMemberService> ch = new ChannelFactory<IMemberService>(binding, address);

            Service = ch.CreateChannel();
        }
        // GET: Home
        public ActionResult Index(string name)
        {
            if (name == "" || name == null)
            {
                return View(Service.GetAllMember());
            }
            return View(Service.GetMemberByName(name));
        }
        
        
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(Member newMember)
        {
            if (ModelState.IsValid)
            {
                Member member = new Member { Name = newMember.Name, Email = newMember.Email, Gender = newMember.Gender, Password = newMember.Password };
                Service.Insert(member);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var re = Service.GetMemberByID(id);
            return View(re);
        }
        [HttpPost]
        public ActionResult Edit(Member editMember)
        {

            if (ModelState.IsValid)
            {

                Member member = new Member { ID = editMember.ID, Name = editMember.Name, Email = editMember.Email, Gender = editMember.Gender, Password = editMember.Password };
                Service.Update(member);

                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Edit faile");
            return View();
        }
        public ActionResult Delete(int id)
        {
            Service.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var re = Service.GetMemberByID(id);
            return View(re);
        }
    }
}