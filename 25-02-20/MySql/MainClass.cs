using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MySql
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            var dbManager = new DBManager("DBConnection");

            Student student = new Student
            {
                _studentName = "swamy",
                _studentGender = "male",
                _studentMarks = 99.99,
               _studentPhone = 77777777777777,
               _studentAddress = "Kadur"
            };
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Student_name",student._studentName,DbType.String));
            parameters.Add(dbManager.CreateParameter("@Student_gender", student._studentGender, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Student_marks", student._studentMarks, DbType.Double));
            parameters.Add(dbManager.CreateParameter("@Student_phone", student._studentPhone, DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@Student_address", student._studentAddress, DbType.String));

            int lastId = 0;
            dbManager.Insert("Student_Proc", CommandType.StoredProcedure, parameters.ToArray(), out lastId);


           
        }
         
    }
}