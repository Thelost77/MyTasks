using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTasks.Core;
using MyTasks.Core.Models.Domains;
using MyTasks.Core.Repositories;
using MyTasks.Core.Service;
using MyTasks.Core.ViewModels;
using MyTasks.Persistence;
using MyTasks.Persistence.Extensions;
using MyTasks.Persistence.Repositories;
using MyTasks.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MyTasks.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService; 
        }

        public IActionResult Tasks()
        {

            var userId = User.GetUserId();

            var vm = new TasksViewModel
            {
                FilterTask = new Core.Models.FilterTask(),
                Tasks = _taskService.Get(userId),
                Categories = _taskService.GetCategories(userId)
            };

            return View(vm);
        }
        [HttpPost]
        public IActionResult Tasks(TasksViewModel viewModel)
        {

            var userId = User.GetUserId();

            var tasks = _taskService.Get(userId,
                viewModel.FilterTask.IsExecuted,
                viewModel.FilterTask.CategoryId,
                viewModel.FilterTask.Title);

            return PartialView("_TasksTable", tasks);
        }
        public IActionResult Task(int id = 0)
        {

            var userId = User.GetUserId();

            var task = id == 0 ?
                new Task { Id = 0, UserId = userId, Term = DateTime.Today } :
                _taskService.Get(id, userId);

            if (!_taskService.GetCategories(userId).Any())
            {
                var category = new Category
                {
                    Name = "Ogólna",
                    UserId = userId
                };
                _taskService.Add(category);
            }

            var vm = new TaskViewModel
            {
                Task = task,
                Heading = id == 0 ?
                "Dodawanie nowego zadania" : "Edytowanie zadania",
                Categories = _taskService.GetCategories(userId)
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Task(Task task)
        {
            var userId = User.GetUserId();

            task.UserId = userId;

            if (!ModelState.IsValid)
            {
                var vm = new TaskViewModel
                {
                    Task = task,
                    Heading = task.Id == 0 ?
                    "Dodawanie nowego zadania" : "Edytowanie zadania",
                    Categories = _taskService.GetCategories(userId)
                };

                return View("Task", vm);
            }

            if (task.Id == 0)
                _taskService.Add(task);

            else
                _taskService.Update(task);


            return RedirectToAction("Tasks");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var userId = User.GetUserId();

            try
            {
                _taskService.Delete(id, userId);

            }
            catch (Exception e)
            {

                //logowanie do pliku
                return Json(new { success = false, message = e.Message });
            }

            return Json(new { success = true });
        }


        [HttpPost]
        public IActionResult Finish(int id)
        {
            var userId = User.GetUserId();

            try
            {
                _taskService.Finish(id, userId);
            }
            catch (Exception e)
            {

                //logowanie do pliku
                return Json(new { success = false, message = e.Message });
            }

            return Json(new { success = true });
        }
        public IActionResult Category()
        {

            var userId = User.GetUserId();

            if (!_taskService.GetCategories(userId).Any())
            {
                var category = new Category
                {
                    Name = "Ogólna",
                    UserId = userId
                };

                _taskService.Add(category);
            }

            return View(_taskService.GetCategories(userId));
        }

        public IActionResult AddCategory(int id = 0)
        {

            var userId = User.GetUserId();

            var category = id == 0 ? new Category() : _taskService.GetCategory(id, userId);

            var vm = new CategoryViewModel
            {
                Heading = id == 0 ?
                "Dodawanie nowej kategorii" : "Edycja kategorii",
                Category = category
            };

            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(Category category)
        {
            var userId = User.GetUserId();

            category.UserId = userId;

            if (!ModelState.IsValid)
            {
                var vm = new CategoryViewModel
                {
                    Heading = category.Id == 0 ?
                    "Dodawanie nowej kategorii" : "Edycja kategorii",
                    Category = category
                };

                return View("AddCategory", vm);
            }

            if (category.Id == 0)
                _taskService.Add(category);

            else
                _taskService.Update(category);


            return RedirectToAction("Category");
        }
        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            var userId = User.GetUserId();

            try
            {
                _taskService.DeleteCategory(id, userId);

            }
            catch (Exception e)
            {

                //logowanie do pliku
                return Json(new { success = false, message = e.Message });
            }

            return Json(new { success = true });
        }
    }

}
