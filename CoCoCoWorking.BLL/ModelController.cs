using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCoCoWorking.DAL;
using CoCoCoWorking.DAL.DTO;
using CoCoCoWorking.BLL.Models;


namespace CoCoCoWorking.BLL
{
    public class ModelController
    {
        private FinanceReportManager financeReportManager = new FinanceReportManager();
        private RoomManager roomManager = new RoomManager();
        private OrderUnitManager orderUnitManager = new OrderUnitManager();
        private WorkplaceManager workplaceManager = new WorkplaceManager();

        private AutoMapper.Mapper mapper = MapperConfigStorage.GetInstance();

        public string GetProductName(FinanceReportDTO f)
        {
            string s = "";
            if (f.RoomName != null)
            {
                s = f.RoomName;
            }
            else if (f.AdditionalServiceName != null)
            {
                s = f.AdditionalServiceName;
            }
            else
            {
                s = "WorkPlaces";
            }
            return s;
        }

        public int GetProductCount(FinanceReportDTO f)
        {
            int i = 0;
            if (f.RoomCount != 0)
            {
                i = (int)f.RoomCount;
            }
            else if (f.AdditionalServiceCount != 0)
            {
                i = (int)f.AdditionalServiceCount;
            }
            else if (f.WorkPlaceCount != 0)
            {
                i = (int)f.WorkPlaceCount;
            }
            return i;
        }

        public List<FinanceReportModel> GetFinanceReportModels(DateTime startDate, DateTime endDate)
        {
            List<FinanceReportModel> list = new List<FinanceReportModel>();
            List<FinanceReportDTO> listDto = financeReportManager.GetFinanceReport(startDate, endDate);
            list = mapper.Map<List<FinanceReportModel>>(listDto);
            return list;
        }

        public List<FinanceReportByCustomerModel> GetFinanceReportByCustomerModels(DateTime startDate, DateTime endDate)
        {
            List<FinanceReportByCustomerModel> list = new List<FinanceReportByCustomerModel>();
            List<FinanceReportByCustomerDTO> listDto = financeReportManager.GetFinanceReportByCustomer(startDate, endDate);
            list = mapper.Map<List<FinanceReportByCustomerModel>>(listDto);
            return list;
        }

        public List<RoomModel> GetAllRoom()
        {
            List<RoomModel> list = new List<RoomModel>();
            List<RoomDTO> listDto = roomManager.GetAllRooms();
            list = mapper.Map<List<RoomModel>>(listDto);
            return list;
        }
        public List<OrderUnitModel> GetAllOrderUnit()
        {
            List<OrderUnitModel> list = new List<OrderUnitModel>();
            List<OrderUnitDTO> listDto = orderUnitManager.GetAllOrderUnits();
            list = mapper.Map<List<OrderUnitModel>>(listDto);
            return list;
        }

        public List<WorkPlaceModel> GetAllWorkplace()
        {
            List<WorkPlaceModel> list = new List<WorkPlaceModel>();
            List<WorkplaceDTO> listDto = workplaceManager.GetAllWorkplaces();
            list = mapper.Map<List<WorkPlaceModel>>(listDto);
            return list;
        }

       
    }
}
