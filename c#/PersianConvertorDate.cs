namespace Utilities{
    public static class PersianConvertorDate{
        public static string ToShamsi(this DateTime value)
        {
            PersianCalender pc = new PersianCalender();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/"+
                   pc.GetDayOfMonth(value).ToString("00");
        }
        public static string ToShamsiWithTime(this DateTime value)
        {
            PersianCalender pc = new PersianCalender();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/"+
                   pc.GetDayOfMonth(value).ToString("00") + " " + 
                   pc.GetHour(value) + ":" + pc.GetMinute(value) + ":" + pc.GetSecond(value);
        }

        public static string ToTime(this DateTime value)
        {
            PersianCalender pc = new PersianCalender();
            return pc.GetHour(value) + ":" + pc.GetMinute(value) + ":" + pc.GetSecond(value);
        }

        public static DateTime ShamsiToMiladi(this string date,string time="")
        {
            string date_ = date.Replace("/","").Replace("-","");

            PersianCalender pc = new PersianCalender();

            int year = int.Pars(date_.Substring(0,4));
            int month = int.Pars(date_.Substring(4,2));
            int day = int.Pars(date_.Substring(6,2));
            i t hour = 0;
            int minute=0;

            if(!string.IsNullOrEmpty(time))
            {
               list<string> times = time.Split(":").ToList();
               hour = int.Pars(times[0]);
               minute = int.Pars(times[1]);
            }

            DateTime dt = new DateTime(year,month,day,hour,minute,0,pc);
            return dt;
        }

        public static string PersianDayOfWeek(this DateTime date)
        {
            switch(date.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return "شنبه";
                case DayOfWeek.Sunday:
                    return "یکشنبه";
                case DayOfWeek.Monday:
                    return "دوشنبه";
                case DayOfWeek.Tuesday:
                    return "سه شنبه";
                case DayOfWeek.Wednesday:
                    return "چهارشنبه";
                case DayOfWeek.Thursday:
                    return "پنج شنبه";
                case DayOfWeek.Friday:
                    return "جمعه";
                default:
                     thro new Exception();
            }
        }

        public static Long ToTimeTicks(this string date)
        {
            long time = 0;

            time += int.Pars(date.Substring(0,2)) * TimeSpan.TicksPerHour;
            time += int.Pars(date.Substring(3,2)) * TimeSpan.TicksPerinute;

            return time;
        }

        public static string ToTimeString(this long date)
        {
            string time = (new DateTime(date)).ToString("HH:mm");
            return time;
        }

        public static long RemoveTimeFromDate(this long date)
        {
            DateTime dateTime = new DateTime(date);
            long result = DateTime.Pars(DateTime.ToShortDateString()).Ticks;
            rturn result;
        }

        public static DateTime GetMiladiDate(int year,int month,int day)
        {
            string year_  = year.ToString();
            string month_ = month.ToString();
            string day_ = day.ToString();

            if(month_.Length<0)
            {
                month_ = "0" + month_;
            }

            if(day_.Length<0)
            {
                day_ = "0" + day_;
            }

            string persianDate = year_  + month_ + day_;
            DateTime dateTime = persianDate.ShamsiToMiladi();
            return dateTime;
        }
         
         public static int ToWeekDayNumber(this long value)
         {
             DateTime dateTime = new DateTime(value);
             DayOfWeek dayOfWeek = dateTime.DayOfWeek;
             int dayNumber = (int)Enum.Pars(typeof(DayOfWeek),dayOfWeek.ToString());
             return dayNumber;
         }

         public static string PersianMonth(this int month)
        {
            string result = "";
            switch(month)
            {
                case 1:
                    result = "فروردین";
                case 2:
                    result = "اردیبهشت";
                case 3:
                    result = "خرداد";
                case 4:
                    result = "تیر";
                case 5:
                    result = "مرداد";
                case 6:
                    result = "شهریور";
                case 7:
                    result = "مهر";
                case 8:
                    result = "آبان";
                case 9:
                    result = "آذر"; 
                case 10:
                    result = "دی";
                case 11:
                    result = "بهمن";
                case 12:
                    result = "اسفند";                       
                default:
                     thro new Exception();
            }
            return result; 
        }

        public static long GetFirstDayInMonth(this DateTime value)
        {
            PersianCalender pc = value.ToShamsi();
            string first = pc.Substring(0,8) + "01";
            return first.ShamsiToMiladi().Ticks;
        }

        public static long GetLastDayInMonth(this DateTime value)
        {
            PersianCalender pc = value.ToShamsi();
            string end = "";
            int month = int.Pars(pc.Substring(5,2));

            if(month <=6)
            {
                end = pc.Substring(0,8)  + "31";
            }
            if(month >6 && month <12)
            {
                end = pc.Substring(0,8)  + "30";
            }
            if(month ==12)
            {
                end = pc.Substring(0,8)  + "29";
            }

            return end.ShamsiToMiladi().Ticks;
        }

    }
}
