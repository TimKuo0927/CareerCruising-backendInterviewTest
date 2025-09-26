using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {   
        public Tuple<bool, STANDING,int>  HasGraduated(Diploma diploma, Student student)
        {
            
            int credits = 0;
            double average = 0;
            //FIX: variable to check if student passed all courses
            bool everyCoursePassed = true;

            //FIX: check if diploma or student are null
            if (diploma == null || student == null)
            {
                return new Tuple<bool, STANDING, int>(false, STANDING.None,0);
            }


            for (int i = 0; i < diploma.Requirements.Length; i++)
            {
                //FIX: less call to GetRequirement
                Requirement requirement = Repository.GetRequirement(diploma.Requirements[i]);

                //FIX: check if requirement is null or something wrong with data
                if (requirement == null)
                {
                    return new Tuple<bool, STANDING,int>(false, STANDING.None,0);
                }

                for (int j = 0; j < student.Courses.Length; j++)
                {

                    for (int k = 0; k < requirement.Courses.Length; k++)
                    {
                        if (requirement.Courses[k] == student.Courses[j].Id)
                        {
                            average += student.Courses[j].Mark;

                            //FIX: get to MinimumMark are supposed to passed
                            if (student.Courses[j].Mark >= requirement.MinimumMark)
                            {
                                credits += requirement.Credits;
                            }
                            else
                            {
                                everyCoursePassed = false;
                            }
                        }
                    }
                }
            }

            //FIX: average should be by number of requirements not by number of courses
            average = average / diploma.Requirements.Length;

            STANDING standing = STANDING.None;

            if (average < 50)
                standing = STANDING.Remedial;
            else if (average < 80)
                standing = STANDING.Average;
            else if (average < 95)
                standing = STANDING.MagnaCumLaude;
            else
                //FIX: logic error NO SumaCumLaude
                //standing = STANDING.MagnaCumLaude;
                standing = STANDING.SumaCumLaude;

            //FIX: check if student has enough credits to graduate
            if (credits < diploma.Credits || !everyCoursePassed)
            {
                standing = STANDING.Remedial;
            }
                

            switch (standing)
            {
                case STANDING.Remedial:
                    return new Tuple<bool, STANDING,int>(false, standing,credits);
                case STANDING.Average:
                    return new Tuple<bool, STANDING, int>(true, standing, credits);
                case STANDING.SumaCumLaude:
                    return new Tuple<bool, STANDING, int>(true, standing, credits);
                case STANDING.MagnaCumLaude:
                    return new Tuple<bool, STANDING, int>(true, standing, credits);

                default:
                    return new Tuple<bool, STANDING, int>(false, standing, credits);
            } 
        }
    }
}
