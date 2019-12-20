using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDateTimeApp
{
   public class Year
    {
        public Year(int year):this()
        {
            CurrentYear = year;
        }

        public Year()
        {
            Months = InitializeMonths();
        }

        //we are emulating db here...
        private IEnumerable<Month> InitializeMonths()
        {
            return new List<Month>
            {
                new Month(){ DayCount=31,MonthType = MonthType.January},
                new Month(){DayCount=28,MonthType = MonthType.February},
                new Month(){ DayCount=31,MonthType = MonthType.March},
                new Month(){DayCount=30,MonthType = MonthType.April},
                new Month(){ DayCount=31,MonthType = MonthType.May},
                new Month(){DayCount=30,MonthType = MonthType.June},
                new Month(){ DayCount=31,MonthType = MonthType.July},
                new Month(){DayCount=31,MonthType = MonthType.August},
                new Month(){ DayCount=30,MonthType = MonthType.September},
                new Month(){DayCount=31,MonthType = MonthType.October},
                new Month(){ DayCount=30,MonthType = MonthType.November},
                new Month(){DayCount=31,MonthType = MonthType.December},
            };
        }
        public int CurrentYear { get; private set; }
        public IEnumerable<Month> Months { get; }

        internal void AddYear(int year)
        {
            CurrentYear += year;
        }
    }
}
