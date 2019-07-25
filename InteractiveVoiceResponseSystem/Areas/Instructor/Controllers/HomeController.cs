using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InteractiveVoiceResponseSystem.Areas.Instructor.Models.MLASDB;
using InteractiveVoiceResponseSystem.Areas.Instructor.Models.NewVersionHintsDB;
using InteractiveVoiceResponseSystem.Areas.Instructor.Models.ORCSDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InteractiveVoiceResponseSystem.Areas.Instructor.Controllers
{
    [Area("Instructor")]
    public class HomeController : Controller
    {
        private readonly NewVersionHintsDBContext _newVersionHintsDbContext;
        private readonly MLASDBContext _mlasdbContext;
        private readonly ORCSDBContext _orcsdbContext;
        
        public HomeController(
            NewVersionHintsDBContext newVersionHintsDbContext, 
            MLASDBContext mlasdbContext, 
            ORCSDBContext orcsdbContext)
        {
            _newVersionHintsDbContext = newVersionHintsDbContext;
            _mlasdbContext = mlasdbContext;
            _orcsdbContext = orcsdbContext;
        }
        
        public IActionResult Index()
        {
            const string hardCodedInstructorId = "tea1";

            var courseIds = _orcsdbContext.OrcsMemberCourseTeacher
                .Where(omct => omct.CUserId == hardCodedInstructorId)
                .Select(omct => omct.IGroupId.ToString()).ToArray();
            
            var courses = _mlasdbContext.MlasCourseInfo.Where(mci => courseIds.Contains(mci.CCourseId));

            foreach (var course in courses)
            {
                course.Professions = _newVersionHintsDbContext.Ivrsprofession.Where(ia => ia.CCourseId == course.CCourseId);
            }
            
            return View(courses);
        }
    }
}