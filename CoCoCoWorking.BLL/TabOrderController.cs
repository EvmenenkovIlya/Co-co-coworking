using CoCoCoWorking.BLL.Models;

namespace CoCoCoWorking.BLL
{
    public class TabOrderController
    {

        ModelController modelController = new ModelController();
        List<DateTime> busyDate = new List<DateTime>();
        List <int> DateForCalendar = new List<int>();
        Singleton _instance = Singleton.GetInstance();

        public int ConvertRentalDaysInHour(DateTime startDate, DateTime endDate)
        {
            int allHours = Convert.ToInt32(((endDate - startDate).TotalHours));
            return allHours;
        }

        public List<RentPriceModel> SearchRentPricesById(int selectedIndexType, int modelId)
        {
            List<RentPriceModel> result = new List<RentPriceModel> ();
            switch (selectedIndexType)
            {
                case 0:
                case 1:
                case 2:
                    result = _instance.RentPrices.Where(r => r.RoomId == modelId).ToList();          
                    break;
                case 3:
                case 4:
                    result = _instance.RentPrices.Where(r => r.WorkPlaceInRoomId == modelId).ToList();
                    break;
                case 5:
                    result = _instance.RentPrices.Where(r => r.AdditionalServiceId == modelId).ToList();
                    break;
            }
            return result;
        }


        public decimal GetPriceForCustomer(RentPriceModel model, CustomerModel customer, int typeIndex)
        {
            
            decimal price = model.RegularPrice;
            if (customer.Subscribe)
            {
                price = (decimal)model.ResidentPrice;
            }
            else if(typeIndex == 4)
            {
                price = (decimal) model.FixedPrice;
            }
            return price;

        }


        public decimal GetOrderPriceSum(List<OrderUnitModel> unitOrdersToOrder)
        {
            decimal orderSum =0;
            foreach (var unitOrder in unitOrdersToOrder)
            {
                var unitPrice = (decimal)unitOrder.OrderUnitCost;
                orderSum += unitPrice;
            }

            return orderSum;
        }


        public RentPriceModel GetRequiredRentPrice(List<RentPriceModel> list, int hours)
        {
            list.Sort((n1, n2) => n1.Hours.CompareTo(n2.Hours));
            int requiredIndex= list.FindIndex(r => r.Hours > hours)-1;

            if(requiredIndex == -2)
            {
                requiredIndex= list.Count - 1;
            }
            return list[requiredIndex];
        }


        public List<int> GetAllWorkplaceInRoom(int id)
        {
            List<int> workPlaceIdInRoom = new List<int>();
            var allWorkplace = modelController.GetAllWorkplace();
            var rooms = modelController.GetAllRoom();

            foreach (var room in rooms)
            {
                if (room.Id == id)
                {
                    foreach (var workplace in allWorkplace)
                    {
                        if (workplace.RoomId == room.Id)
                        {
                            workPlaceIdInRoom.Add(workplace.Id);
                        }
                    }
                }
            }
            return workPlaceIdInRoom;
        }


        public IEnumerable<DateTime> GetEveryDayInRange(DateTime start, DateTime end)
        {
            for (var day = start.Date; day.Date <= end.Date; day = day.AddDays(1))
                yield return day;
        }


        public List<DateTime> GetStringBusyDate(int? roomId, int? workplaceId)
        {
            foreach (var unit in _instance.OrderUnits)
            {
                if ((((unit.AdditionalServiceId is null && unit.RoomId == roomId && unit.WorkPlaceId is null) ||
                                        (unit.WorkPlaceId == workplaceId && unit.WorkPlaceInRoomId == roomId))))
                {
                    foreach (DateTime day in GetEveryDayInRange(DateTime.Parse(unit.StartDate), DateTime.Parse(unit.EndDate)))
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

            foreach (DateTime day in GetEveryDayInRange(DateTime.Parse(startDate), DateTime.Parse(endDate)))
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
                    int? workplaceId = workplace;
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

        public List<int> ConvertIntBusyDateRoom(List<DateTime> BusyDate)
        {    
            foreach (var date in BusyDate)
            {
                DateForCalendar.Add(date.Day);
                DateForCalendar.Add(date.Month);
                DateForCalendar.Add(date.Year);
            }
            return DateForCalendar;
        }

        public void FillId(OrderUnitModel orderUnit, int indexType, RoomModel room = null, AdditionalServiceModel additionalService = null, WorkPlaceModel workplace = null)
        {
            if (indexType == 3)
            {
                orderUnit.WorkPlaceInRoomId = room.Id;                             
            }
            if (room != null && indexType == 0)
            {
                orderUnit.RoomId = room.Id;               
            }
            if (additionalService != null)
            {
                orderUnit.AdditionalServiceId = additionalService.Id;               
            }
            if (workplace != null)
            {
                orderUnit.WorkPlaceId= workplace.Id;
                orderUnit.WorkPlaceInRoomId = room.Id;
            }
        }
    }
}

   

    

