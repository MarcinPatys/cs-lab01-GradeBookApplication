using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    internal class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            List<double> average = new List<double>();
            for(int i=0;i<Students.Count;i++)
            {
               average[i] = Students[i].AverageGrade;
            }
            average.Sort();
            if(Students.Count<5)
            {
                throw new InvalidOperationException();
            }
            int liczbaTop20Procent = (int)(average.Count * 0.2);
            if (average.Take(liczbaTop20Procent).Contains(averageGrade))
                return 'A';
            else if (average.Skip(liczbaTop20Procent).Take(liczbaTop20Procent).Contains(averageGrade))
                return 'B';
            else if (average.Skip(liczbaTop20Procent * 2).Take(liczbaTop20Procent).Contains(averageGrade))
                return 'C';
            else if (average.Skip(liczbaTop20Procent * 3).Take(liczbaTop20Procent).Contains(averageGrade))
                return 'D';
            else
                return 'F';           
        }
    }
}
