using System;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using CoCoCoWorking.DAL;
using CoCoCoWorking.BLL;
using CoCoCoWorking.BLL.Models;
using System.ComponentModel;
using System.Collections.Generic;

namespace CoCoCoWorking.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        
        AdditionalServiceManager additionalService = new AdditionalServiceManager();//test
        ModelController modelController = new ModelController();
        Singleton _instance = Singleton.GetInstance();

        List<AllUnitOrdersFromSpecificOrderModel> unitOrdersList = new List<AllUnitOrdersFromSpecificOrderModel>();


        TabOrderController orderController = new TabOrderController();
        private ICollectionView items;
        

        public MainWindow()
        {
            _instance.UpdateInstance();
            InitializeComponent();

            DataGridCustomers.ItemsSource = _instance.CustomersToEdit;
            DataGridRentPrices.ItemsSource = _instance.RentPrices;
        }

        private void ButtonCreateNewOrder_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedItem = TabItem_Orders;

            var customerSelected = DataGridCustomers.SelectedItems;
            var customer = customerSelected[0] as CustomerModel;
            DataGrid_Order.ItemsSource=modelController.GetOrderByCustomerID(customer.Id);
            DataGrid_Order.Items.Refresh();
        }

        private void ButtonCreateNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            modelController.AddCustomerToBase(TextBoxFirstName.Text, TextBoxLastName.Text, TextBoxNumber.Text, TextBoxEmail.Text);
            _instance.UpdateInstance();
            DataGridCustomers.ItemsSource = _instance.CustomersToEdit;
           
        }
       

        private void Combobox_PurchaseType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Combobox_ChooseWorkplace.Items.Clear();
            Order_Calendar.BlackoutDates.Clear();
            var rooms = modelController.GetAllRoom();

            if (Combobox_PurchaseType.SelectedItem is null)
            {
                return;
            }

            foreach (var room in rooms)
            {
                if (room.Name == Combobox_PurchaseType.SelectedItem.ToString())
                {
                    var workPlaceInRoom = orderController.GetAllWorkplaceInRoom(room.Id);

                    foreach (var workplace in workPlaceInRoom)
                    {
                        Combobox_ChooseWorkplace.Items.Add(workplace.Number);

                        switch (ComboBox_Type.SelectedIndex)
                        {
                            case 0:
                                var date = orderController.GetStringBusyDate(room.Id, workplace.Id);
                                var dateConvert = orderController.ConvertIntBusyDateRoom(date);

                                for (int i = dateConvert.Count - 1; i > 0; i -= 3)
                                {
                                    Order_Calendar.BlackoutDates.Add(new CalendarDateRange(new DateTime(dateConvert[i], dateConvert[i - 1], dateConvert[i - 2])));
                                }
                                date.Clear();
                                dateConvert.Clear();
                                break;

                            case 4:

                                break;
                        }
                    }
                }   
            }
        }
        private void ComboBox_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Combobox_ChooseWorkplace.IsEnabled = false;
            Combobox_ChooseWorkplace.Items.Clear();
            Combobox_PurchaseType.Items.Clear();

            var allService = modelController.GetAllAdditionalService();
            var roomName = modelController.GetAllRoom();

            switch (ComboBox_Type.SelectedIndex)
            {
                case 0:
                    for (int i = 0; i < roomName.Count; i++)
                    {
                        Combobox_PurchaseType.Items.Add(roomName[i].Name);
                    }
                    break;

                case 1:
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    Combobox_ChooseWorkplace.IsEnabled = true;
                    for (int i = 0; i < roomName.Count; i++)
                    {
                        Combobox_PurchaseType.Items.Add(roomName[i].Name);
                    }
                    break;

                case 5:
                    foreach (var service in allService)
                    {
                        Combobox_PurchaseType.Items.Add(service.Name);
                    }
                    break;
            }
        }
        private void Button_GetReport_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox_TypeOfReport.SelectedIndex == -1
                || DataPicker_Finance_StartDate.SelectedDate == null
                || DataPicker_Finance_EndDate.SelectedDate == null)
            {
                popup1.IsOpen = true;
            }

            else
            {
                double sum = 0;
                switch (ComboBox_TypeOfReport.SelectedIndex)
                {
                    case 0:
                        DataGrid_ReportByCustomer.Visibility = Visibility.Hidden;
                        DataGrid_Report.Visibility = Visibility.Visible;
                        DataGrid_Report.ItemsSource = modelController.GetFinanceReportModels(
                            DataPicker_Finance_StartDate.SelectedDate.Value,
                            DataPicker_Finance_EndDate.SelectedDate.Value);
                        foreach (FinanceReportModel a in DataGrid_Report.ItemsSource)
                        {
                            sum += a.Summ;
                        }
                        TextBox_Total.Text = "" + sum;
                        break;
                    case 1:
                        DataGrid_Report.Visibility = Visibility.Hidden;
                        DataGrid_ReportByCustomer.Visibility = Visibility.Visible;
                        DataGrid_ReportByCustomer.ItemsSource = modelController.GetFinanceReportByCustomerModels(
                            DataPicker_Finance_StartDate.SelectedDate.Value,
                            DataPicker_Finance_EndDate.SelectedDate.Value);
                        foreach (FinanceReportByCustomerModel a in DataGrid_ReportByCustomer.ItemsSource)
                        {
                            sum += a.OrderSum;
                        }
                        TextBox_Total.Text = "" + sum;
                        break;
                }

            }
        }

        private void ButtonSearchByNumber_Click(object sender, RoutedEventArgs e)
        {

            DataGridCustomers.ItemsSource = modelController.GetCustomerWithTheMatchedNumberIsReturned(TextBoxNumberForSearch.Text,_instance.CustomersToEdit);
           
        }

        private void ButtonSearchByDateForOrder_Click(object sender, RoutedEventArgs e)
        {
            Combobox_PurchaseType.Items.Clear();
            string startDate = DatePicker_Order_StartDate.Text;
            string endDate = DatePicker_Order_EndDate.Text;
            var freeRooms = orderController.SearchFreeRoomForDate(startDate, endDate);
            var freeWorkplace = orderController.SearchFreeWorkplaceForDate(startDate, endDate);

            switch  (ComboBox_Type.SelectedIndex)
            {
                case 0:
                    foreach (var room in freeRooms)
                    {
                        Combobox_PurchaseType.Items.Add(room);
                    } 
                    break;
                case 4:
                    foreach (var workplace in freeWorkplace)
                    {
                        Combobox_PurchaseType.Items.Add(workplace);
                    }
                    break;
               
            }
        }

        private void ButtonReset_Customer_Click(object sender, RoutedEventArgs e)
        {
            TextBoxNumberForSearch.Clear();
            DataGridCustomers.ItemsSource = modelController.GetCustomerWithTheMatchedNumberIsReturned(TextBoxNumberForSearch.Text, _instance.CustomersToEdit);
        }      
        private void Combobox_ChooseWorkplace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Combobox_ChooseWorkplace.SelectedItem is null)
            {
                return;
            }

            Order_Calendar.BlackoutDates.Clear();
            var roomName = Combobox_PurchaseType.SelectedItem as string;
            var rooms = modelController.GetAllRoom();

            foreach (var room in rooms)
            {
                if (room.Name == roomName)
                {
                    var workPlaceInRoom = orderController.GetAllWorkplaceInRoom(room.Id);

                    foreach (var workplace in workPlaceInRoom)
                    {
                        if (workplace.Number == (int)Combobox_ChooseWorkplace.SelectedItem)
                        {

                            var date = orderController.GetStringBusyDate(room.Id, workplace.Id);

                            var dateConvert = orderController.ConvertIntBusyDateRoom(date);

                            for (int i = dateConvert.Count - 1; i > 0; i -= 3)
                            {
                                Order_Calendar.BlackoutDates.Add(new CalendarDateRange(new DateTime(dateConvert[i], dateConvert[i - 1], dateConvert[i - 2])));
                            }
                            date.Clear();
                            dateConvert.Clear();
                        }
                    }
                }
            }
        }

        // to test the procedure and output information to DataGrids
        private void DataGridCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //List<CustomersWithOrdersDTO> customers = customerManager.GetAllCustomerWhithOrderWithOrderUnit();

            //List<OrderDTO> customerOrders = order.OrderGetByCustomerId(customers[DataGridCustomers.SelectedIndex].Id);

            //List<OrderModel> customerOrdersModel = mapper.Map<List<OrderModel>>(customerOrders);

            //DataGrid_Order.ItemsSource = customerOrdersModel;

        }
        private void DataGrid_Order_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }

        private void DataGridCustomers_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            CustomerModel customer = e.Row.Item as CustomerModel;
            modelController.UpdateCustomerInBase(customer);          
        }

        private void ButtonRefreshBase_Click(object sender, RoutedEventArgs e)
        {
            _instance.UpdateInstance();
            DataGridCustomers.ItemsSource = _instance.CustomersToEdit;
        }

        private void ButtonAddToOrder_Click(object sender, RoutedEventArgs e)
        {
            AllUnitOrdersFromSpecificOrderModel unitOrders = new AllUnitOrdersFromSpecificOrderModel();
            unitOrders.StartDate = DatePicker_Order_StartDate.Text;
            unitOrders.EndDate=DatePicker_Order_EndDate.Text;
            unitOrders.EndDate = DatePicker_Order_EndDate.Text;
            unitOrders.Type = ComboBox_Type.Text;
            unitOrders.Name = Combobox_PurchaseType.Text;
            if(Combobox_ChooseWorkplace.IsEnabled is true)
            {
                unitOrders.Number =int.Parse( Combobox_ChooseWorkplace.Text);
            }
            unitOrdersList.Add(unitOrders);
            DataGrid_UnitOrder.ItemsSource= unitOrdersList;
            DataGrid_UnitOrder.Items.Refresh();

        }
        private void ContextMenuOrderUnit_ClickDelete(object sender, RoutedEventArgs e)
        {
            if(DataGrid_UnitOrder.SelectedIndex == null)
            {
                return;
            }
            unitOrdersList.RemoveAt(DataGrid_UnitOrder.SelectedIndex);
            DataGrid_UnitOrder.Items.Refresh();

        }

        private void ButtonCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderModel order = new OrderModel();
            order.Id = 2009;
            order.OrderCost = 1;
            order.OrderStatus = "done";
            order.PaidDate = DatePicker_Order_StartDate.Text;
            order.CustomerId = 1;
            modelController.AddOrderInBase(order); //----------??????? order unit model list ?????????
        }
    }
}
