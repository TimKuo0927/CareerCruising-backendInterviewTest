using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        [TestMethod]
        public void TestHasCredits()
        {
            GraduationTracker tracker = new GraduationTracker();

            Diploma diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            Student[] students = new[]
            {
               new Student
               {
                   Id = 1,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                   }
               },
               new Student
               {
                   Id = 2,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                   }
               },
            new Student
            {
                Id = 3,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=50 },
                    new Course{Id = 2, Name = "Science", Mark=50 },
                    new Course{Id = 3, Name = "Literature", Mark=50 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                }
            },
            new Student
            {
                Id = 4,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=40 },
                    new Course{Id = 2, Name = "Science", Mark=40 },
                    new Course{Id = 3, Name = "Literature", Mark=40 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                }
            },
             new Student
            {
                 //FIX:  Student with less than 4 credits
                Id = 5,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=40 },
                    new Course{Id = 2, Name = "Science", Mark=40 },
                    new Course{Id = 3, Name = "Literature", Mark=40 }
                }
            },
            //FIX: Student who dont pass a course
            new Student
            {
                Id = 6,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=100 },
                    new Course{Id = 2, Name = "Science", Mark=40 },
                    new Course{Id = 3, Name = "Literature", Mark=60 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=100 }
                }
            },
            //FIX: Student who has another course that not required for diploma
            new Student
            {
                Id = 7,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=100 },
                    new Course{Id = 2, Name = "Science", Mark=40 },
                    new Course{Id = 3, Name = "Literature", Mark=60 },
                    new Course{Id = 5, Name = "Global Education", Mark=100 }
                }
            }

        };

            List<Tuple<bool, STANDING, int>> graduated = new List<Tuple<bool, STANDING, int>>();

            foreach(Student student in students)
            {
                graduated.Add(tracker.HasGraduated(diploma, student));      
            }

            //check if theres is at least one student that not passed, 
            //since we have one student with all marks under 50
            Assert.IsTrue(graduated.Any(x=>!x.Item1));

            //check if theres is at least one student that passed
            Assert.IsTrue(graduated.Any(x => x.Item1));

            //check if theres is at least one student with MagnaCumLaude standing
            Assert.IsTrue(graduated.Any(x => x.Item2 == STANDING.MagnaCumLaude));

            //check if theres is at least one student with SumaCumLaude standing
            Assert.IsTrue(graduated.Any(x => x.Item2 == STANDING.SumaCumLaude));

            //check if theres is at least one student with Average standing
            Assert.IsTrue(graduated.Any(x => x.Item2 == STANDING.Average));

            //check if theres is at least one student with Remedial standing
            Assert.IsTrue(graduated.Any(x => x.Item2 == STANDING.Remedial));

            //check if no students with None standing
            Assert.IsFalse(graduated.Any(x => x.Item2 == STANDING.None));

            //check if theres is no student pass with less than diploma.Requirements credits
            Assert.IsFalse(graduated.Any(x => x.Item1 && x.Item3 < diploma.Requirements.Length));



        }


    }
}
