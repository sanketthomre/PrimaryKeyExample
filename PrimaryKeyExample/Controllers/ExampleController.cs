using PrimaryKeyExample.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimaryKeyExample.Controllers
{
    public class ExampleController : Controller
    {
        
        // GET: Example
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DynamicExample()
        {
            //List<Student> StudentList = new List<Student>()
            //{
            //    new Student{FullName = "Sanket" ,City = "Jalgaon"},
            //    new Student{FullName = "Sushant" ,City = "Ahemdabad"},
            //    new Student{FullName = "Akash" ,City = "Gujrat"},
            //    new Student{FullName = "Pankaj" ,City = "YawatMal"},
            //    new Student{FullName = "Karan" ,City = "Jamner"},
            //    new Student {FullName = "Aishali" ,City = "Pune"}
            //};
            //List<Details> Details = new List<Details>()
            //{
            //    new Details{ DepartmentName = "Computer", SubjectName = "Java"},
            //    new Details{DepartmentName = "Civil", SubjectName = "Cement" }
            //};
            //var temp = StudentList.Where(x => x.City == "Pune").Select(x => x.FullName);

            //List<StudentDetails> StudentDetails = new List<StudentDetails>()
            //{
            //    new StudentDetails { FullName = StudentList.Single(x=>x.FullName == "Sanket Thomre").FullName,
            //                                SubjectName = Details.Single(x=>x.SubjectName == "Cement").SubjectName
            //                        }
            //};
            //IEnumerable<Student> student = StudentList;
            //Student students = student.Where(x => x.City == "Jalgaon").FirstOrDefault();
            return View();
        }
        public ActionResult Marks()
        {
            dynamic expando = new ExpandoObject();
            var marksModel = expando as IDictionary<string, object>;
            
            string studentName = "Sanket";
            marksModel.Add("Name", studentName);
            marksModel.Add("Physics", 24);
            marksModel.Add("Chemistry", 45);
            marksModel.Add("Biology", 31);
            return View(marksModel);

        }
        public ActionResult SubmitMarks()
        {

            return View();
        }
    }
}