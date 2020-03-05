using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DBLayer;
using System.Data;


namespace BusinessLayer
{
    public class StudentDataAccess
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudentDetails()
        {
            List<Student> student = new List<Student>();

            var dbManager = new DBManager("constr");
            var data = dbManager.GetDataTable("Student_Select", CommandType.StoredProcedure);
            Student s;
            if (data != null)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    s = new Student();

                    s.Id = Convert.ToInt32(data.Rows[i]["student_id"].ToString());
                    s.Name = data.Rows[i]["student_name"].ToString();
                    s.Gender = data.Rows[i]["student_gender"].ToString();
                    s.Marks = Convert.ToDouble(data.Rows[i]["student_marks"].ToString());
                    s.Phone = Convert.ToInt64(data.Rows[i]["student_phone"].ToString());
                    s.Address = data.Rows[i]["student_address"].ToString();
                    student.Add(s);
                }
            }

            return student;
        }
        public Student GetStudentDetailsById(int Id)
        {
            Student s = new Student();

            var dbManager = new DBManager("constr");
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Student_id", Id, DbType.Int32));
            var data = dbManager.GetDataTable("Select_Student", CommandType.StoredProcedure, parameters.ToArray());

            if (data != null)
            {
                s.Id = Convert.ToInt32(data.Rows[0]["student_id"].ToString());
                s.Name = data.Rows[0]["student_name"].ToString();
                s.Gender = data.Rows[0]["student_gender"].ToString();
                s.Marks = Convert.ToDouble(data.Rows[0]["student_marks"].ToString());
                s.Phone = Convert.ToInt64(data.Rows[0]["student_phone"].ToString());
                s.Address = data.Rows[0]["student_address"].ToString();
            }
            return s;
        }
        public void UpdateStudent(Student student)
        {

            var dbManager = new DBManager("constr");
            var parameters = new List<IDbDataParameter>();

            parameters.Add(dbManager.CreateParameter("@Student_id", student.Id, DbType.Int32));
            parameters.Add(dbManager.CreateParameter("@Student_name", student.Name, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Student_gender", student.Gender, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Student_marks", Convert.ToDouble(student.Marks), DbType.Double));
            parameters.Add(dbManager.CreateParameter("@Student_phone", Convert.ToInt64(student.Phone), DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@Student_address", student.Address, DbType.String));
            dbManager.Update("Student_Update", CommandType.StoredProcedure, parameters.ToArray());
        }
        public void DeleteStudent(int id)
        {
            var dbManager = new DBManager("constr");
            var parameters = new List<IDbDataParameter>();

            parameters.Add(dbManager.CreateParameter("@Student_id", id, DbType.Int32));
            dbManager.Delete("Student_Delete", CommandType.StoredProcedure, parameters.ToArray());
        }
        public void InsertStudent(Student student)
        {
            var dbManager = new DBManager("constr");
            var parameters = new List<IDbDataParameter>();

            parameters.Add(dbManager.CreateParameter("@Student_name", student.Name, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Student_gender", student.Gender, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Student_marks", Convert.ToDouble(student.Marks), DbType.Double));
            parameters.Add(dbManager.CreateParameter("@Student_phone", Convert.ToInt64(student.Phone), DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@Student_address", student.Address, DbType.String));
            int lastId = 0;
            dbManager.Insert("Stud_Insert", CommandType.StoredProcedure, parameters.ToArray(), out lastId);

        }
    }
}
