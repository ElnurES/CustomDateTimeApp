using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDateTimeApp
{
    public class CustomDateTime
    {
        public byte Day { get; private set; }
        public Month Month { get; private set; }
        public Year Year { get; }


        private Month ConvertToMonth(string datetime)
        {
            int index = _FirstIndexInFormat(datetime);

            int m = Convert.ToInt32(datetime.Substring(index + 1, datetime.IndexOf('.', index)));

            int month;
            if (!int.TryParse(datetime.Substring(index + 1, datetime.IndexOf('.', index)), out month))
            {
                throw new ArgumentException("Month is not in correct format!!");
            }
            else
                if (month > 12 || month < 1)
            {
                throw new ArgumentException("Month must be between 1 and 12");
            }
            Year y = new Year();
            MonthType currentMonthType = (MonthType)Enum.Parse(typeof(MonthType), month.ToString());

            Month currentMonth = y.Months.Where(x => x.MonthType == currentMonthType).FirstOrDefault();

            return currentMonth;
        }

        public void Subtract(int day)
        {
           
        }

        public void AddDay(int day)
        {
            int newDay = day + Day;

            if (newDay > Month.DayCount)
            {
                //get day ~
                Day = (byte)(newDay % Month.DayCount);

                int currentMonthInNumber = Convert.ToByte(Math.Floor((decimal)(newDay / Month.DayCount)));


                if (currentMonthInNumber > 12)
                {
                    
                    int monthPart = currentMonthInNumber % 12;
                    Month = new Month((byte)monthPart);

                   int _year = Convert.ToInt32(Math.Floor((decimal)(currentMonthInNumber / 12)));
                    Year.AddYear(_year);

                }
                else
                    if (currentMonthInNumber + (int)Month.MonthType > 12)
                {
                    int totalMonth = (currentMonthInNumber + (int)Month.MonthType);

                    int monthPart = totalMonth % 12;

                    Month = new Month((byte)monthPart);

                    int _year = Convert.ToInt32(Math.Floor((decimal)(totalMonth / 12)));

                    Year.AddYear(_year);
                }
                else
                    Month = Month.Add((byte)currentMonthInNumber);
            }
            else
                Day += (byte)day;
        }
    
        private int _FirstIndexInFormat(string datetime)
        {
            int index = datetime.IndexOf(".");
            if (index == -1)
                throw new ArgumentException("Datetime is not in correct format");
            return index;
        }

        private byte ConvertToDay(string datetime)
        {
            int index = _FirstIndexInFormat(datetime);
            byte day;
            if (!byte.TryParse(datetime.Substring(0, index), out day))
            {
                throw new ArgumentException("Day is not in correct format!!");
            }

           Month currentMonth = ConvertToMonth(datetime);

                 if(day<1 || day>currentMonth.DayCount)
                {
                    throw new ArgumentException($"Day must be between 1 and {currentMonth.DayCount}");
                }
            return day;
        }

        private Year ConvertToYear(string datetime)
        {
            int index = _FirstIndexInFormat(datetime);

            int _year;
            if (!int.TryParse(datetime.Substring(datetime.LastIndexOf(".") + 1, 4), out _year))
            {
                throw new ArgumentException("Year is not in correct format!!");
            }
            Year currentYear = new Year(_year);
            return currentYear;

             
        }

        public CustomDateTime(string datetime)
        {
            try
            {
                int index = _FirstIndexInFormat(datetime);

                Day = ConvertToDay(datetime);

                Month = ConvertToMonth(datetime);

                Year = ConvertToYear(datetime);
            }
            catch(ArgumentException exp)
            {
                throw exp;
            }

        }

        public override string ToString()
        {
            return $"{Day}.{Month.MonthType}.{Year.CurrentYear}";
        }

    }

       
    }
