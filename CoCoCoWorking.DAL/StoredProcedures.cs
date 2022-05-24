namespace CoCoCoWorking.DAL
{
    static class StoredProcedures
    {
        public static string AdditionalService_Add = "AdditionalService_Add";
        public static string AdditionalService_GetAll = "AdditionalService_GetAll";
        public static string AdditionalService_GetById = "AdditionalService_GetById";
        public static string AdditionalService_SoftDelete = "AdditionalService_SoftDelete";
        public static string AdditionalService_Update = "AdditionalService_Update";
        public static string Customer_Add = "Customer_Add";
        public static string Customer_GetAll = "Customer_GetAll";
        public static string Customer_GetById = "Customer_GetById";
        public static string Customer_Update = "Customer_Update";
        public static string Order_Add = "Order_Add";
        public static string Order_GetAll = "Order_GetAll";
        public static string Order_GetById = "Order_GetById";
        public static string Order_Update = "Order_Update";
        public static string OrderUnit_Add = "OrderUnit_Add";
        public static string OrderUnit_GetAll = "OrderUnit_GetAll";
        public static string OrderUnit_GetById = "OrderUnit_GetById";
        public static string OrderUnit_Update = "OrderUnit_Update";
        public static string RentPrice_Add = "RentPrice_Add";
        public static string RentPrice_GetAll = "RentPrice_GetAll";
        public static string RentPrice_GetById = "RentPrice_GetById";
        public static string RentPrice_SoftDelete = "RentPrice_SoftDelete";
        public static string RentPrice_Update = "RentPrice_Update";
        public static string Room_Add = "Room_Add";
        public static string Room_GetAll = "Room_GetAll";
        public static string Room_GetById = "RentPrice_GetById";
        public static string Room_Update = "Room_Update";
        public static string Workplace_Add = "Workplace_Add";
        public static string Workplace_GetAll = "Workplace_GetAll";
        public static string Workplace_GetById = "Workplace_GetById";
        public static string Workplace_Update = "Workplace_Update";

        public static string GetAllCustomerWhithOrderWithOrderUnit = "GetAllCustomerWhithOrderWithOrderUnit";
    }
}