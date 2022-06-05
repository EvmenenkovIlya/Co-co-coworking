using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCoCoWorking.BLL.Models;
using CoCoCoWorking.DAL;
using CoCoCoWorking.DAL.DTO;





namespace CoCoCoWorking.BLL
{
    public class TabOrderController
    {

        ModelController modelController = new ModelController();
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

      
        public List<string> GetStringBusyDate(int? roomId, int? workplaceId)
        {
            var orderUnits = modelController.GetAllOrderUnit();

            foreach (var unit in orderUnits)
            {
                if ((((unit.AdditionalServiceId is null && unit.RoomId == roomId && unit.WorkPlaceId is null) ||                    
                                        (unit.WorkPlaceId == workplaceId && unit.WorkPlaceInRoomId == roomId)))) 
                {
                    foreach (DateTime day in EachDay(DateTime.Parse(unit.StartDate), DateTime.Parse(unit.EndDate)))
                    {
                        
                        busyDate.Add(day.ToShortDateString());
                    }
                }

               
            }
            return busyDate;
        }
        

        public List<string> SearcFreeForDate(string startDate, string endDate)
        {
            
            var rooms = modelController.GetAllRoom();
            
            List<string> searchDate = new List<string>();
            List<string> freeRoom = new List<string>();
            Dictionary<int, List<string>> busyRooms = new Dictionary<int, List<string>>();
          
            foreach (DateTime day in EachDay(DateTime.Parse(startDate), DateTime.Parse(endDate)))
            {

                searchDate.Add(day.ToShortDateString());
            }

            foreach (var room in rooms)
            {
                var workplaces = GetAllWorkplaceInRoom(room.Id);
                foreach (var workplace in workplaces)
                {

                    List<string> busyDatesInRooms = GetStringBusyDate(room.Id, workplace.Id);
                    var key = room.Id;
                    if (!busyRooms.ContainsKey(key))
                    {
                        busyRooms[key] = new List<string>();
                    }

                    foreach(var date in busyDatesInRooms)
                    {

                        busyRooms[room.Id].Add($"{date}");
                    }
                    busyDatesInRooms.Clear();

                    var busyDates = busyRooms[room.Id];
                    var intersecting = busyDates.Intersect(searchDate);
                    bool isEqual = intersecting.Any();

                    if (isEqual == false)
                    {
                        freeRoom.Add(room.Name);
                    }
                }
            }
            var freeRoomResult = freeRoom.Distinct().ToList();
            return freeRoomResult;
        }


        
        public List<WorkPlaceModel> GetAllWorkplaceInRoom(int id)
        {
            List<WorkPlaceModel> workPlaceInRoom = new List<WorkPlaceModel>();
            var allWorkplace = modelController.GetAllWorkplace();
            var rooms = modelController.GetAllRoom();

            foreach(var room in rooms)
            {
                if(room.Id == id)
                {
                    foreach(var workplace in allWorkplace)
                    {
                        if(workplace.RoomId == room.Id)
                        {
                            workPlaceInRoom.Add(workplace);
                        }

                    }

                }
            }
            return workPlaceInRoom;

        }


        IEnumerable<DateTime> EachDay(DateTime start, DateTime end)
        {
            for (var day = start.Date; day.Date <= end.Date; day = day.AddDays(1))
                yield return day;
        }


    }
}

   

    

