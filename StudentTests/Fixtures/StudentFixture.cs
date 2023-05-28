using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAPI.Models;

namespace StudentTests.Fixtures
{
    public static class StudentFixture
    {
        public static List<Student> GetStudents() =>
        new(){
            new Student{
                Id = 1,
                Email = "gogh@dgdf.com",
                FirstName = "John",
                LastName = "Gogh"
            },
            new Student{
                Id = 2,
                FirstName = "Peter",
                LastName = "Pan",
                Email = "peter@dgdf.com"
            },
            new Student{
                Id = 3,
                FirstName = "Denise",
                LastName = "Dentist",
                Email = "denise@dgdf.com",
            },
            new Student{
                Id = 4,
                FirstName = "Daniel",
                LastName = "Levy",
                Email = "daniel@dgdf.com",
                
            }
        };

    }
}