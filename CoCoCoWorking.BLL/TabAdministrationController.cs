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
        DataStorage _instance = DataStorage.GetInstance();

        public List<string> GetRoomsTypes()
        {
            List<string> roomsTypes = new List<string>();
            roomsTypes.Add(TypeOfProduct.MiniOffice.ToString());
            roomsTypes.Add(TypeOfProduct.MeetingRoom.ToString());
            roomsTypes.Add(TypeOfProduct.ConferenceHall.ToString());
            return roomsTypes;
        }

        public List<RentPriceModel> GetRentPrices(int selectedIndex, int Id)
        {
            List<RentPriceModel> result = new List<RentPriceModel>();
            switch (selectedIndex)
            {
                case 0:
                    result = _instance.RentPrices.Where(r => r.RoomId == Id).ToList();
                    break;
                case 1:
                    result = _instance.RentPrices.Where(r => r.AdditionalServiceId == Id).ToList();
                    break;
            }                                 
            return result;
        }

        public int GetHours(string s)
        {
            int a = 0;
            switch (s)
            {
                case "OneHour":
                    a = 1;
                    break;
                case "EightHours":
                    a = 8;
                    break;
                case "OneDay":
                    a = 24;
                    break;
                case "OneWeek":
                    a = 168;
                    break;
                case "OneMonth":
                    a = 720;
                    break;
                case "ThreeMonths":
                    a = 2160;
                    break;
                case "SixMonths":
                    a = 4320;
                    break;
                case "EightMonths":
                    a = 5760;
                    break;
                case "OneYear":
                    a = 8640;
                    break;
            }                
            return a;
        }       
    }
}
