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
        List<DateTime> busyDate = new List<DateTime>();
        List <int> DateForCalendar = new List<int>();
        Singleton _instance = Singleton.GetInstance();



        public List <int> ConvertIntBusyDateRoom(List <DateTime> BusyDate)
        {
            for (int j = 0; j < BusyDate.Count; j++)
            {
                var day = BusyDate[j].Day;
                var month = BusyDate[j].Month; 
                var year = BusyDate[j].Year;

                DateForCalendar.Add(day);
                DateForCalendar.Add(month);
                DateForCalendar.Add(year);
            }
            return DateForCalendar;
        }

      
        public List<DateTime> GetStringBusyDate(int? roomId, int? workplaceId)
        {

            foreach (var unit in _instance.OrderUnits)
            {
                if ((((unit.AdditionalServiceId is null && unit.RoomId == roomId && unit.WorkPlaceId is null) ||                    
                                        (unit.WorkPlaceId == workplaceId && unit.WorkPlaceInRoomId == roomId)))) 
                {
                    foreach (DateTime day in EachDay(DateTime.Parse(unit.StartDate), DateTime.Parse(unit.EndDate)))
                    {                        
                        busyDate.Add(day);
                    }
                } 
            }
            return busyDate;
        }


        public List<int> SearchFreeForDate(string startDate, string endDate, bool forWorkplace = false)
        {

            var rooms = _instance.Rooms;
            List<DateTime> allDatesForFree = new List<DateTime>();
            List<int> freeRoom = new List<int>();
            Dictionary<int, List<DateTime>> busyRooms = new Dictionary<int, List<DateTime>>();

            foreach (DateTime day in EachDay(DateTime.Parse(startDate), DateTime.Parse(endDate)))
            {
                allDatesForFree.Add(day);
            }

            foreach (var room in rooms)
            {

                if (!busyRooms.ContainsKey(room.Id))
                {
                    busyRooms[room.Id] = new List<DateTime>();
                }
                var workplaces = GetAllWorkplaceInRoom(room.Id);

                foreach (var workplace in workplaces)
                {
                    int? workplaceId = workplace.Id;
                    if (forWorkplace == true)
                    {
                        workplaceId = null;
                    }
                    var busyDate = GetStringBusyDate(room.Id, workplaceId);
                    foreach (var date in busyDate)
                    {
                        busyRooms[room.Id].Add(date);

                    }
                    busyDate.Clear();
                }
            }

            foreach (var key in busyRooms.Keys)
            {
                var datesForRoom = busyRooms[key];

                foreach (var date in datesForRoom)
                {
                    foreach (var date2 in allDatesForFree)
                    {
                        if (date == date2)
                        {

                            busyRooms.Remove(key);
                            break;
                        }
                    }
                }
            }
            freeRoom = busyRooms.Keys.ToList();
            return freeRoom;
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

   

    

