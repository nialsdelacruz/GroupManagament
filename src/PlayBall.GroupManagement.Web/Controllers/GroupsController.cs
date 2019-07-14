//using Coding.PlayBall.GroupManagement.Web.Demo;
using PlayBall.GroupManagement.Web.Models;
using PlayBall.GroupManagement.Web.Mappings;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PlayBall.GroupManagement.Business.Services;

namespace GroupManagement.Web.Controllers
{
    //localhost:5000/groups
    [Route("groups")]
    public class GroupsController : Controller
    {
        private static List<GroupViewModel> groups = new List<GroupViewModel>
        {
            new GroupViewModel { Id = 1, Name = "Group 1" }
        };

        private readonly IGroupsService _groupService;
        
        public GroupsController(IGroupsService groupService)
        {
            _groupService = groupService;
        }

        // Index
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View(_groupService.GetAll().ToViewModel());
        }

        // Details
        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(long id)
        {
            var group = _groupService.GetById(id);

            if (group == null)
            {
                return NotFound();
            }

            return View(group.ToViewModel());
        }

        // Update 
        [HttpPost]
        [Route("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, GroupViewModel model)
        {
            var group = _groupService.Update(model.ToServiceModel());

            if (group == null)
            {
                return NotFound();
            }

            group.Name = model.Name;
            return RedirectToAction("Index");
        }

        // Create (Get View)
        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        // Create (Insert action)
        [HttpPost]
        [Route("")]
        public IActionResult CreateRecord(GroupViewModel model)
        {
            _groupService.Add(model.ToServiceModel());
            return RedirectToAction("Index");
        }

    }
}
