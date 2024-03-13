using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeight) : base(name, isWeight)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            List<double> average = new List<double>();
            int count = 0;
            for(int i=0;i<Students.Count;i++)
            {
               average.Add(Students[i].AverageGrade);
            }
            average.Sort();
            if(Students.Count<5)
            {
                throw new InvalidOperationException();
            }         
                for (int i = 0; i < Students.Count; i++)
                {
                    if (averageGrade >= average[i])
                    {
                        count++;
                    }
                }                    
            double percent = ((double)count / Students.Count);                      
            if (percent > 0.80)
            {
                return 'A';
            }
            if (percent <= 0.80 && percent >0.60)
            {
                return 'B';
            }
            if (percent <= 0.60 && percent > 0.40)
            {
                return 'C';
            }
            if (percent <= 0.40 && percent > 0.20)
            {
                return 'D';
            }           
            return 'F';
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students.");
            }else if(Students.Count >= 5) 
            {
                base.CalculateStatistics();
            }           
        }
        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students.");
            }
            else if (Students.Count >= 5)
            {
                base.CalculateStudentStatistics(name);
            }
           
        }
    }
}
