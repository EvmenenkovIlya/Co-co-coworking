using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCoCoWorking.DAL;
using CoCoCoWorking.DAL.DTO;


namespace CoCoCoWorking.BLL
{
    public class ModelController
    {
        public string GetProductName(FinanceReportDTO f)
        {
            string s = "";
            if (f.RoomName != null)
            {
                s = f.RoomName;
            }
            else if (f.WorkPlaceCount != null)
            {
                s = "WorkPlaces";
            }
            else
            {
                s = f.AdditionalServiceName;
            }
            return s;
        }
    }
}
