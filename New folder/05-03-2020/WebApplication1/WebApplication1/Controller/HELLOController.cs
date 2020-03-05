using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using BusinessLayer;


namespace WebApplication1.Controller
{
    public class HELLOController : ApiController
    {
        //public string get()
        //{
        //    return "Neha";
        //}

        [HttpGet]
        public List<Models.Student> Get()
        {
            StudentDataAccess sda = new StudentDataAccess();
            List<Models.Student> result = new List<Models.Student>();
            result = sda.GetStudentDetails();
            return result;

        }
        [HttpGet]
        public Student Get(int id)
        {
            StudentDataAccess sda = new StudentDataAccess();
            Student result = new Student();
            result = sda.GetStudentDetailsById(id);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="student"></param>
        [HttpPut]
        public void UpdateStudent(Student student)
        {
            StudentDataAccess sda = new StudentDataAccess();
            sda.UpdateStudent(student);
        }

        [HttpDelete]
        public void DeleteStudent(int id)
        {
            StudentDataAccess sda = new StudentDataAccess();
            sda.DeleteStudent(id);
        }
        [HttpPost]
        public void Insert(Student student)
        {
            StudentDataAccess sda = new StudentDataAccess();
            sda.InsertStudent(student);
        }

    }
}
