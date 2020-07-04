using System;
using System.Collections.Generic;
using System.Globalization;

using System.Text;


namespace MeetingInfraStructure
{
    public class Utilities
    {
        public static string GetPersianDate(DateTime? date)
        {
            if (!date.HasValue)
                return string.Empty;
            if (date.Value == DateTime.MaxValue || date.Value == DateTime.MinValue)
                return string.Empty;
            PersianCalendar pc = new PersianCalendar();
            var month = pc.GetMonth(date.Value) < 10 ? "0" + pc.GetMonth(date.Value).ToString() : pc.GetMonth(date.Value).ToString();
            var day = pc.GetDayOfMonth(date.Value) < 10 ? "0" + pc.GetDayOfMonth(date.Value).ToString() : pc.GetDayOfMonth(date.Value).ToString();
            return pc.GetYear(date.Value) + "/" + month + "/" + day;
        }
        public static int GetPersianDayOfMonth(DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetDayOfMonth(date);
        }
        public static List<string> GetCalenderOfMounth(DateTime date)
        {
            List<string> calender = new List<string>();

            PersianCalendar pc = new PersianCalendar();
            var s = pc.GetMonth(date);

            if (pc.GetMonth(date) <= 6)
            {
                for (int i = 1; i <= 31; i++)
                {
                    calender.Add(pc.GetYear(date) + "/" + pc.GetMonth(date) + "/" + i);
                }
            }
            if (pc.GetMonth(date) >= 7 && pc.GetMonth(date) <= 11)
            {
                for (int i = 1; i <= 30; i++)
                {
                    calender.Add(pc.GetYear(date) + "/" + pc.GetMonth(date) + "/" + i);
                }

            }
            if (pc.GetMonth(date) == 12 && pc.IsLeapYear(pc.GetYear(date)))
            {
                for (int i = 1; i <= 30; i++)
                {
                    calender.Add(pc.GetYear(date) + "/" + pc.GetMonth(date) + "/" + i);
                }
            }
            if (pc.GetMonth(date) == 12 && !pc.IsLeapYear(pc.GetYear(date)))
            {
                for (int i = 1; i <= 29; i++)
                {
                    calender.Add(pc.GetYear(date) + "/" + pc.GetMonth(date) + "/" + i);
                }
            }
            return calender;

        }
        public static DateTime GetMiladiDate(string date)
        {
            PersianCalendar pc = new PersianCalendar();
            string[] splitedDate = date.Split('/');
            int year = Convert.ToInt32(splitedDate[0]);
            int month = Convert.ToInt32(splitedDate[1]);
            int DDLDay = Convert.ToInt32(splitedDate[2]);
            return pc.ToDateTime(year, month, DDLDay, 0, 0, 0, 0);
        }
        public static string GetStageObjectTypeText(StageObjectType type)
        {
            var result = string.Empty;
            if (type == StageObjectType.CustomField)
                result = "نقش در PWA";
            else if (type == StageObjectType.Group)
                result = "گروه در PWA";
            else if (type == StageObjectType.Owner)
                result = "مالک";
            else if (type == StageObjectType.Resource)
                result = "منبع";
            else if (type == StageObjectType.SelectiveApprover)
                result = "انتخاب دستی";
            return result;
        }
    }

    public class Utilities_EN
    {
        public static string GetPersianDate(DateTime? date)
        {
            return date.Value.Year.ToString() + "/" + (date.Value.Month < 10 ? "0" + date.Value.Month.ToString() : date.Value.Month.ToString()) + "/" + (date.Value.Day < 10 ? "0" + date.Value.Day.ToString() : date.Value.Day.ToString());
        }
        public static int GetPersianDayOfMonth(DateTime date)
        {
            return date.Day;
        }
        public static List<string> GetCalenderOfMounth(DateTime date)
        {
            List<string> calender = new List<string>();
            for (int i = 1; i <= DateTime.DaysInMonth(date.Year, date.Month); i++)
            {
                calender.Add(date.Year.ToString() + "/" + date.Month.ToString() + "/" + i);
            }
            return calender;
        }
        public static DateTime GetMiladiDate(string date)
        {
            return Convert.ToDateTime(date);
        }
        public static string GetStageObjectTypeText(StageObjectType type)
        {
            var result = string.Empty;
            if (type == StageObjectType.CustomField)
                result = "نقش در PWA";
            else if (type == StageObjectType.Group)
                result = "گروه در PWA";
            else if (type == StageObjectType.Owner)
                result = "مالک";
            else if (type == StageObjectType.Resource)
                result = "منبع";
            else if (type == StageObjectType.SelectiveApprover)
                result = "انتخاب دستی";
            return result;
        }
    }
    public class DateTimeUtil
    {
        public static double ConvertStringTimeTopercent(DateTime time)
        {

            string value = "";
            value += time.Hour.ToString();
            if (time.Minute == 0)
            {
                value += "." + "0";
            }
            if (time.Minute == 15)
            {
                value += "." + "25";
            }
            if (time.Minute == 30)
            {
                value += "." + "50";
            }
            if (time.Minute == 45)
            {
                value += "." + "75";
            }
            return double.Parse(value);
        }

        public static double ConvertStringTopercent(string time)
        {

            string value = "";
            value += time.Substring(0, 2);
            if (int.Parse(time.Substring(3, 2)) == 0)
            {
                value += "." + "0";
            }
            if (int.Parse(time.Substring(3, 2)) == 15)
            {
                value += "." + "25";
            }
            if (int.Parse(time.Substring(3, 2)) == 30)
            {
                value += "." + "50";
            }
            if (int.Parse(time.Substring(3, 2)) == 45)
            {
                value += "." + "75";
            }
            return double.Parse(value);
        }
        public static DateTime GetPersianDateTime(string datetime)
        {
            string[] spilitDateTime = datetime.Split(' ');
            string[] splitedTime = spilitDateTime[1].Split(':');
            string[] splitedDate = spilitDateTime[0].Split('/');
            int year = Convert.ToInt32(splitedDate[0]);
            int month = Convert.ToInt32(splitedDate[1]);
            int day = Convert.ToInt32(splitedDate[2]);
            int Hour = Convert.ToInt32(splitedTime[0]);
            int Minute = Convert.ToInt32(splitedTime[1]);
            PersianCalendar persian = new PersianCalendar();
            DateTime dateT = persian.ToDateTime(year, month, day, Hour, Minute, 0, 0);

            return dateT;
        }
        public static DateTime CombDateAndTime(string date, string time)
        {
            string[] splitedDate = date.Split('/');
            int year = Convert.ToInt32(splitedDate[0]);
            int month = Convert.ToInt32(splitedDate[1]);
            int day = Convert.ToInt32(splitedDate[2]);
            var tim = time.Split(':');
            int Hour = Convert.ToInt32(tim[0]);// int.Parse(pesiandate.Substring(0, 4));
            int Minute = Convert.ToInt32(tim[1]);//int.Parse(pesiandate.Substring(5, 2));
            PersianCalendar persian = new PersianCalendar();
            DateTime dateT = persian.ToDateTime(year, month, day, Hour, Minute, 0, 0);
            return dateT;
        }
        public DateTime PersiantoMiladi(DateTime persiandate)
        {
            PersianCalendar persian = new PersianCalendar();
            DateTime dateT = persian.ToDateTime(persiandate.Year, persiandate.Month, persiandate.Day, persiandate.Hour, persiandate.Minute, persiandate.Second, persiandate.Millisecond);

            return dateT;
        }
        public DateTime PersiantoMiladi(int year, int month, int day)
        {
            PersianCalendar persian = new PersianCalendar();
            DateTime dateT = persian.ToDateTime(year, month, day, 0, 0, 0, 0);

            return dateT;
        }
        public static DateTime TimeToDateTime(string pesiandate)
        {
            var tim = pesiandate.Split(':');
            int Hour = int.Parse(tim[0]);// int.Parse(pesiandate.Substring(0, 4));
            int Minute = int.Parse(tim[1]);//int.Parse(pesiandate.Substring(5, 2));
            PersianCalendar persian = new PersianCalendar();
            DateTime dateT = persian.ToDateTime(1111, 11, 11, Hour, Minute, 0, 0);
            return dateT;
        }
        public static DateTime TimeToDateTime(DateTime meetingdate, string pesiandate)
        {
            var tim = pesiandate.Split(':');
            int Hour = int.Parse(tim[0]);// int.Parse(pesiandate.Substring(0, 4));
            int Minute = int.Parse(tim[1]);//int.Parse(pesiandate.Substring(5, 2));
            //PersianCalendar persian = new PersianCalendar();
            DateTime dateT = new DateTime(meetingdate.Year, meetingdate.Month, meetingdate.Day, Hour, Minute, 0, 0);
            return dateT;
        }
        public static DateTime PersiantoMiladi(string pesiandate)
        {
            var str = pesiandate.Split('/');
            int year = int.Parse(str[0]);// int.Parse(pesiandate.Substring(0, 4));
            int month = int.Parse(str[1]);//int.Parse(pesiandate.Substring(5, 2));
            int DDLDay = int.Parse(str[2]); //int.Parse(pesiandate.Substring(8, 2));
            PersianCalendar persian = new PersianCalendar();
            DateTime dateT = persian.ToDateTime(year, month, DDLDay, 0, 0, 0, 0);

            return dateT;
        }
        public static string MiladitoPersian(DateTime miladidate)
        {

            return Utilities.GetPersianDate(miladidate);

        }

        public static DateTime GetCurrentDateTime()
        {
            try
            {
                DateTime c = DateTime.Now.AddSeconds(1);

                PersianCalendar pc = new PersianCalendar();

                int year = pc.GetYear(c);
                int month = pc.GetMonth(c);
                int day = pc.GetDayOfMonth(c);
                int hour = pc.GetHour(c);
                int minute = pc.GetMinute(c);
                int second = pc.GetSecond(c);

                DateTime returndate = Convert.ToDateTime(year.ToString() + "-" + (month < 10 ? "0" + month.ToString() : month.ToString()) + "-" + (day < 10 ? "0" + day.ToString() : day.ToString()) + " " + (hour < 10 ? "0" + hour.ToString() : hour.ToString()) + ":" + (minute < 10 ? "0" + minute.ToString() : minute.ToString()) + ":" + (second < 10 ? "0" + second.ToString() : second.ToString()));

                return returndate;
            }
            catch
            {
                return DateTime.Now;
            }
        }
    }

    public class DateTimeUtil_EN
    {
        public static double ConvertStringTimeTopercent(DateTime time)
        {

            string value = "";
            value += time.Hour.ToString();
            if (time.Minute == 0)
            {
                value += "." + "0";
            }
            if (time.Minute == 15)
            {
                value += "." + "25";
            }
            if (time.Minute == 30)
            {
                value += "." + "50";
            }
            if (time.Minute == 45)
            {
                value += "." + "75";
            }
            return double.Parse(value);
        }
        public static DateTime GetPersianDateTime(string datetime)
        {
            return Convert.ToDateTime(datetime);
        }
        public static DateTime CombDateAndTime(string date, string time)
        {
            return DateTime.ParseExact(date + " " + time, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        }
        public DateTime PersiantoMiladi(DateTime persiandate)
        {
            return persiandate;
        }
        public DateTime PersiantoMiladi(int year, int month, int day)
        {
            return new DateTime(year, month, day);
        }
        public static DateTime TimeToDateTime(string pesiandate)
        {
            var tim = pesiandate.Split(':');
            int Hour = int.Parse(tim[0]);// int.Parse(pesiandate.Substring(0, 4));
            int Minute = int.Parse(tim[1]);//int.Parse(pesiandate.Substring(5, 2));
            PersianCalendar persian = new PersianCalendar();
            DateTime dateT = persian.ToDateTime(1111, 11, 11, Hour, Minute, 0, 0);
            return dateT;
        }
        public static DateTime TimeToDateTime(DateTime meetingdate, string pesiandate)
        {
            var tim = pesiandate.Split(':');
            int Hour = int.Parse(tim[0]);// int.Parse(pesiandate.Substring(0, 4));
            int Minute = int.Parse(tim[1]);//int.Parse(pesiandate.Substring(5, 2));
            //PersianCalendar persian = new PersianCalendar();
            DateTime dateT = new DateTime(meetingdate.Year, meetingdate.Month, meetingdate.Day, Hour, Minute, 0, 0);
            return dateT;
        }
        public static DateTime PersiantoMiladi(string pesiandate)
        {
            var str = pesiandate.Split('/');
            int year = int.Parse(str[0]);// int.Parse(pesiandate.Substring(0, 4));
            int month = int.Parse(str[1]);//int.Parse(pesiandate.Substring(5, 2));
            int DDLDay = int.Parse(str[2]); //int.Parse(pesiandate.Substring(8, 2));

            if (year > 2000)
                return new DateTime(year, month, DDLDay, 0, 0, 0, 0);
            else
                return new DateTime(DDLDay, month, year, 0, 0, 0, 0);
        }
        public static string MiladitoPersian(DateTime miladidate)
        {
            return Utilities_EN.GetPersianDate(miladidate);
        }
    }
}
