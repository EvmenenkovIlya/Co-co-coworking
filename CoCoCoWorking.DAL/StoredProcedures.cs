namespace CoCoCoWorking.DAL
{
    public class StoredProcedures
    {
        public const string AdditionalService_Add = "AdditionalService_Add";
        public const string AdditionalService_GetAll = "AdditionalService_GetAll";
        public const string AdditionalService_GetById = "AdditionalService_GetById";
        public const string AdditionalService_SoftDelete = "AdditionalService_SoftDelete";
        public const string AdditionalService_Update = "AdditionalService_Update";
        public const string Customer_Add = "Customer_Add";
        public const string Customer_GetAll = "Customer_GetAll";
        public const string Customer_GetById = "Customer_GetById";
        public const string Customer_Update = "Customer_Update";
        public const string Order_Add = "Order_Add";
        public const string Order_GetAll = "Order_GetAll";
        public const string Order_GetById = "Order_GetById";
        public const string Order_Update = "Order_Update";
        public const string OrderUnit_Add = "OrderUnit_Add";
        public const string OrderUnit_GetAll = "OrderUnit_GetAll";
        public const string OrderUnit_GetById = "OrderUnit_GetById";
        public const string OrderUnit_Update = "OrderUnit_Update";
        public const string RentPrice_Add = "RentPrice_Add";
        public const string RentPrice_GetAll = "RentPrice_GetAll";
        public const string RentPrice_GetById = "RentPrice_GetById";
        public const string RentPrice_SoftDelete = "RentPrice_SoftDelete";
        public const string RentPrice_Update = "RentPrice_Update";
        public const string Room_Add = "Room_Add";
        public const string Room_GetAll = "Room_GetAll";
        public const string Room_GetById = "RentPrice_GetById";
        public const string Room_Update = "Room_Update";
        public const string Workplace_Add = "Workplace_Add";
        public const string Workplace_GetAll = "Workplace_GetAll";
        public const string Workplace_GetById = "Workplace_GetById";
        public const string Workplace_Update = "Workplace_Update";

        public const string GetAllAdditionalService = "GetAllAdditionalService";
        public const string GetAllCustomerWhithOrderWithOrderUnit = "GetAllCustomerWhithOrderWithOrderUnit";
        public const string GetAllCustomerWithActiveSubscription = "GetAllCustomerWithActiveSubscription";
        public const string GetAllRoomAndWorkPlaceBusyOrFree = "GetAllRoomAndWorkPlaceBusyOrFree";
        public const string GetFinanceReport = "GetFinancialReport";
    }
}