using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAPI.Models;

namespace StudentAPI.Repo
{
    public interface IStudentRepo
    {
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        bool AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<Student> DeleteStudent(int id);
        bool StudentExists(int id);
        bool SaveChanges();
        
    }
}