using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class Discipline
    {
        public string Predmet {  get; set; }
        public int AvgMonth {  get; set; }

        
    }

    public static class Value
    {
        public static ObservableCollection<Discipline> disciplines;
    }
}
