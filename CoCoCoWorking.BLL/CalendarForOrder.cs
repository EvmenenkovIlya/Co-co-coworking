using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCoCoWorking.DAL;
using CoCoCoWorking.DAL.DTO;



namespace CoCoCoWorking.BLL
{
    public class CalendarForOrder
    {
        OrderUnitManager orderUnitManager = new OrderUnitManager();
        List<string> BusyDate = new List<string>();
        List <int> DateForCalendar = new List<int>();



        public List <int> ConvertIntBusyDateRoom(List <string> BusyDate)
        {
            for (int j = 0; j < BusyDate.Count; j++)
            {
                string busy = BusyDate[j];
                string[] ss = busy.Split('.');
                var day = Convert.ToInt32(ss[0]);
                var month = Convert.ToInt32(ss[1]);
                var year = Convert.ToInt32(ss[2]);

                DateForCalendar.Add(day);
                DateForCalendar.Add(month);
                DateForCalendar.Add(year);
            }

            return DateForCalendar;
        }

        


        public List<string> GetStringBusyDateRoom(int RoomId)
        {
            var orderUnits = orderUnitManager.GetAllOrderUnits();

            foreach (var unit in orderUnits)
            {
                if (unit.WorkPlaceId == null && unit.WorkPlaceInRoomId == null && unit.RoomId == RoomId)
                {
                    foreach (DateTime day in EachDay(DateTime.Parse(unit.StartDate), DateTime.Parse(unit.EndDate)))
                    {
                        
                        BusyDate.Add(day.ToShortDateString());
                    }
                }
            }

            return BusyDate;
        }

        IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;

        }

    }
}

   

    

