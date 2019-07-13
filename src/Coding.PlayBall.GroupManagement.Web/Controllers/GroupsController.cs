using Coding.PlayBall.GroupManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Coding.PlayBall.GroupManagement.Web.Controllers
{
    //localhost:5000/groups
    [Route("groups")]
    public class GroupsController : Controller
    {
        private static long currentGroupId = 1;

        private static List<GroupViewModel> groups = new List<GroupViewModel>
        {
            new GroupViewModel { Id = 1, Name = "Group 1" }
        };

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View(groups);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(long id)
        {
            var group = groups.SingleOrDefault(g => g.Id == id);

            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        [HttpPost]
        [Route("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, GroupViewModel model)
        {
            var group = groups.SingleOrDefault(g => g.Id == id);

            if (group == null)
            {
                return NotFound();
            }

            group.Name = model.Name;
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateRecord(GroupViewModel model)
        {
            model.Id = ++currentGroupId;
            groups.Add(model);
            return RedirectToAction("Index");
        }

    }
}
