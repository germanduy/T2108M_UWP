using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2108M_UWP.Models1;
using T2108M_UWP.Helpers;
using SQLitePCL;
namespace T2108M_UWP.Services
{
     interface IStudentService
    {
        List<Student> All();
        void Create(Student s);
        void Update(Student s);
        void Delete(Student s);

    }
    class StudentService : IStudentService
    {
        public List<Student> All()
        {
            string sql_txt = "select * from Students";
            SQLiteHelper helper = SQLiteHelper.GetInstance();
            var stament = helper.SQLiteConnection.Prepare(sql_txt);
            var list = new List<Student>();
            while(SQLiteResult.ROW == stament.Step())
            {
                Student s = new Student()
                {
                    Id = Convert.ToInt32(stament[0]),
                    Name = stament[1] as string,
                    Age = Convert.ToInt32(stament[2]),
                    Address = stament[3] as string,
                };
                list.Add(s);
            }
            return list;

        }
        public void Create(Student s)
        {
            string sql_txt = "insert into Student(Id,Name,Age,Address) values(?,?,?,?)";
            SQLiteHelper helper = SQLiteHelper.GetInstance();
            var stament = helper.SQLiteConnection.Prepare(sql_txt);
            stament.Bind(1, s.Id);
            stament.Bind(2, s.Name);
            stament.Bind(3, s.Age);
            stament.Bind(4, s.Address);
            stament.Step();
        }
        public void Update(Student s)
        {
            string sql_txt = "update Student set Name=?, Age=?, Address=? where Id= ?";
            SQLiteHelper helper = SQLiteHelper.GetInstance();
            var stament = helper.SQLiteConnection.Prepare(sql_txt);
            stament.Bind(1, s.Id);
            stament.Bind(2, s.Name);
            stament.Bind(3, s.Age);
            stament.Bind(4, s.Address);
            stament.Step();
        }
        public void Delete(Student s)
        {
            string sql_txt = "delete from student where Id=? ";
            SQLiteHelper helper = SQLiteHelper.GetInstance();
            var stament = helper.SQLiteConnection.Prepare(sql_txt);
            stament.Bind(1, s.Id);
            stament.Step();
        }
    }
}
