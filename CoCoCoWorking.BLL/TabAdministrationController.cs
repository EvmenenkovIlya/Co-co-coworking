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
    public class TabAdministrationController
    {
        Singleton _instance = Singleton.GetInstance();

        public List<string> GetRoomsTypes()
        {
            List<string> roomsTypes = new List<string>();
            roomsTypes.Add(TypeOfProduct.MiniOffice.ToString());
            roomsTypes.Add(TypeOfProduct.MeetingRoom.ToString());
            roomsTypes.Add(TypeOfProduct.ConferenceHall.ToString());
            return roomsTypes;
        }


        public List<string> GetPeriodTypesForWorkPlace()
        {
            List<string> workplacePeriodTypes = new List<string>();
            workplacePeriodTypes.Add(TypeOfPeriod.OneDay.ToString());
            workplacePeriodTypes.Add(TypeOfPeriod.OneWeek.ToString());
            return workplacePeriodTypes;
        }

        public List<RentPriceModel> GetRentPrices(int selectedIndexType, int modelId)
        {
            List<RentPriceModel> result = new List<RentPriceModel>();
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

        public int GetTypeOfPeriod(TypeOfPeriod typeEnum)
        {
            int type = 0;
            switch (typeEnum)
            {
                case TypeOfPeriod.OneHour:
                    type = 1;
                    break;
                case TypeOfPeriod.EightHours:
                    type = 8;
                    break;
                case TypeOfPeriod.OneDay:
                    type = 24;
                    break;
                case TypeOfPeriod.OneWeek:
                    type = 168;
                    break;
                case TypeOfPeriod.OneMonth:
                    type = 720;
                    break;
                case TypeOfPeriod.ThreeMonths:
                    type = 2160;
                    break;
                case TypeOfPeriod.SixMonths:
                    type = 4320;
                    break;
                case TypeOfPeriod.EightMonths:
                    type = 4320;
                    break;
                case TypeOfPeriod.OneYear:
                    type = 8640;
                    break;
            }
            return type;
        }
    }
}
