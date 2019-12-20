using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDateTimeApp
{
   public class Month
    {
        public Month() { }
        

        public Month(byte monthNumber)
        {
            MonthType monthType = (MonthType)Enum.Parse(typeof(MonthType), monthNumber.ToString());
            Year year = new Year();
            Month current = year.Months.Where(x => x.MonthType == monthType).FirstOrDefault();
            MonthType = current.MonthType;
            DayCount = current.DayCount;
        }

        public MonthType MonthType { get; set; }
        public byte DayCount { get; set; }

        public Month Add(byte v)
        {
            //3
            //5
            int current = (byte)MonthType + v;
            MonthType monthType = (MonthType)Enum.Parse(typeof(MonthType), current.ToString());
            Year year = new Year();
           return year.Months.Where(x => x.MonthType == monthType).FirstOrDefault();
        }
    }
}
