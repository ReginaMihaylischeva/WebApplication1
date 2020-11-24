using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

using TestsTesk.Context;
using TestsTesk.Models.Requests;
using TestsTesk.Models.Response;
using WebApplication2.Models.Requests;

namespace TestsTesk.Controllers
{
    public class GroupController : Controller
    {

        private readonly PublicDbContext publicDbContext;
        public GroupController(PublicDbContext context)
        {
            this.publicDbContext = context;
        }

        [HttpGet]
        public IActionResult StudyGroups()
        {
            var groups = publicDbContext.Groups
                .Include(x => x.Teachers)
                .Include(x => x.Employes)
                .Select(item => new GroupResponse
                {
                    Name = item.Name,
                    Id = item.GroupId,
                    CountStudents = item.Employes.Count,
                    TeacherName = item.Teachers.Name
                })
                .ToList();
            return View(groups);
        }

        [HttpGet]
        public IActionResult CreateGroup()
        {
            SelectList teachers = new SelectList(publicDbContext.Teachers, "Id", "Name");
            ViewBag.Teachers = teachers;
            return View();
        }

        [HttpPost]
        public IActionResult CreateGroup(AddGroupRequest addGroupRequest)
        {
            if (addGroupRequest.TeacherId == 0 || String.IsNullOrEmpty(addGroupRequest.Name))
                return BadRequest();

            var teacher = publicDbContext.Teachers.FirstOrDefault(x => x.Id == addGroupRequest.TeacherId);

            if (teacher is null)
                return NotFound();

            var group = new Group { Name = addGroupRequest.Name, Teachers = teacher };

            if (group is null)
                return NotFound();

            var AddedGroup = publicDbContext.Groups.Add(group);
            publicDbContext.SaveChangesAsync();

            return RedirectToAction("EditStudyGroup", "Group", new { id = AddedGroup.Entity.GroupId });
        }

        [HttpGet]
        public ActionResult EditStudyGroup(int id)
        {
            var groups = publicDbContext.Groups
                    .Where(x => x.GroupId == id)
                    .Include(x => x.Teachers)
                    .Include(x => x.Employes)
                    .FirstOrDefault();

            return View(groups);
        }

        [HttpPost]
        public ActionResult EditStudyGroup(UpdateGroupRequest updateGroupRequest)
        {
            if (updateGroupRequest.GroupId == 0 || String.IsNullOrEmpty(updateGroupRequest.Name))
                return BadRequest();

            var group = publicDbContext.Groups.FirstOrDefault(x => x.GroupId == updateGroupRequest.GroupId);

            if (group is null)
                return NotFound();

            group.Name = updateGroupRequest.Name;
            publicDbContext.Entry(group).State = EntityState.Modified;
            publicDbContext.SaveChangesAsync();

            return RedirectToAction("EditStudyGroup");
        }

        public ActionResult Delete(int employeeId, int groupId)
        {
            if (employeeId == 0)
                return NotFound();

            var employee = publicDbContext
                        .Employees
                        .FirstOrDefault(x => x.EmployeeId == employeeId);

            if (employee is null)
                return NotFound();

            var group = publicDbContext
                        .Groups
                        .FirstOrDefault(x => x.GroupId == groupId)
                        .Employes
                        .Remove(employee);

            publicDbContext.SaveChangesAsync();
            return RedirectToAction("EditStudyGroup", new { id = groupId });
        }

        [HttpPost]
        public ActionResult AddStudentInGroup(
            int Id,
            int Organisations,
            int Employees)
        {
            var employee = publicDbContext
                        .Employees
                        .FirstOrDefault(x => x.EmployeeId == Employees);

            if (employee is null)
                return NotFound();

            var organisation = publicDbContext
                        .Organisations
                        .FirstOrDefault(x => x.OrganisationId == Organisations);

            if (organisation is null)
                return NotFound();

            var group = publicDbContext
                       .Groups
                       .FirstOrDefault(x => x.GroupId == Id);

            if (group is null)
                return NotFound();

            employee.Organisations = organisation;
            group.Employes.Add(employee);
            publicDbContext.Entry(group).State = EntityState.Modified;
            publicDbContext.SaveChangesAsync();

            return RedirectToAction("EditStudyGroup", new { id = Id });
        }

        [HttpGet]
        public ActionResult AddStudentInGroup(int Id)
        {
            AddStudentInGroupRequest addStudentInGroupRequest = new AddStudentInGroupRequest();
            var group = publicDbContext
                       .Groups
                       .Include(x => x.Teachers)
                       .FirstOrDefault(x => x.GroupId == Id);

            if (group is null)
                return NotFound();

            addStudentInGroupRequest.groupId = group.GroupId;
            addStudentInGroupRequest.groupName = group.Name;
            addStudentInGroupRequest.teacherName = group.Teachers.Name;

            var organisation = publicDbContext
                .Organisations
                .Include(x => x.Teacher)
                .Where(x => x.Teacher.Id == group.Teachers.Id)
                .ToList();

            addStudentInGroupRequest.Organisations = organisation;
            addStudentInGroupRequest.Employees = new System.Collections.Generic.List<Employee>();

            if (organisation.Count != 0)
            {
                var employees = publicDbContext
                    .Employees
                    .Include(x => x.Organisations)
                    .Where(x => x.Organisations.OrganisationId == organisation.FirstOrDefault().OrganisationId);

                addStudentInGroupRequest.Employees = employees.ToList();
            }
            return View(addStudentInGroupRequest);
        }
        public ActionResult GetItems(int id)
        {
            var employees = publicDbContext
               .Employees
               .Include(x => x.Organisations)
               .Where(x => x.Organisations.OrganisationId == id)
               .AsNoTracking()
               .ToList();
            return PartialView(employees);
        }
    }
}
