using Microsoft.AspNetCore.Mvc;
using Web2.Models;
using Web3.Data;
using Web3.Data.EFCore;
using Web3.Data.Services;

namespace Web3.Controllers
{
    public class MessageController : Controller
    {
        private IRepository<Message> repo;
        private MsgService service;
        public MessageController(MessageContext context, MsgService service)
        {
            this.repo = new MsgRepository(context);
            this.service = service;
        }
        // GET: /<controller>/
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Message message)
        {
            if(ModelState.IsValid)
            {
                repo.Create(message);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return View();
        }

        public ActionResult Update(int id)
        {
            Message m = repo.Get(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult Update(Message message)
        {
            if (ModelState.IsValid)
            {
                repo.Update(message);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        [HttpGet]
        public ActionResult CountHours(int id)
        {
            Message m = repo.Get(id);
            return View(service.Count(m));
        }
    }
}
