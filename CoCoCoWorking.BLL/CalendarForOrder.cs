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
        OrderUnitManager orderUnitManager = new OrderUnitManager();//test
        RoomManager room = new RoomManager();                      //test
        List<string> busyDate = new List<string>();
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

      
        public List<string> GetStringBusyDateRoom(int roomId)
        {
            List <OrderUnitDTO> orderUnits = orderUnitManager.GetAllOrderUnits();//test

            foreach (var unit in orderUnits)
            {
                if (unit.AdditionalServiceId == null && unit.RoomId == roomId || unit.WorkPlaceInRoomId == roomId)
                {
                    foreach (DateTime day in EachDay(DateTime.Parse(unit.StartDate), DateTime.Parse(unit.EndDate)))
                    {
                        
                        busyDate.Add(day.ToShortDateString());
                    }
                }
                
            }
            return busyDate;
        }


        public List<string> SearchRoomsForDate(string startDate, string endDate)
        {         
            var rooms = room.GetAllRooms();//test

            List<string> searchDate = new List<string>();
            List<string> freeRoom = new List<string>();
            Dictionary<int, List<string>> busyRoom = new Dictionary<int, List<string>>();
          
            foreach (DateTime day in EachDay(DateTime.Parse(startDate), DateTime.Parse(endDate)))
            {

                searchDate.Add(day.ToShortDateString());
            }

            foreach (var room in rooms)
            {
                List<string> asdd = GetStringBusyDateRoom(room.Id);
                var key = room.Id;
                if (!busyRoom.ContainsKey(key))
                {
                    busyRoom[key] = new List<string>();
                }

                foreach(var item in asdd)
                {

                    busyRoom[room.Id].Add($"{item}");
                }
                 asdd.Clear();
            }

            foreach(var room in rooms)
            {
               List<string> busyDate = busyRoom[room.Id];

                var intersecting = busyDate.Intersect(searchDate);

                bool isEqual = intersecting.Any();

                 if (isEqual== false)
                 {
                     freeRoom.Add(room.Name);
                 }
            }

            return freeRoom;

        }


        IEnumerable<DateTime> EachDay(DateTime start, DateTime end)
        {
            for (var day = start.Date; day.Date <= end.Date; day = day.AddDays(1))
                yield return day;
        }


    }
}

   

    

