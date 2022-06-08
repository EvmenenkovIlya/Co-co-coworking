﻿using System;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using CoCoCoWorking.DAL;
using CoCoCoWorking.BLL;
using CoCoCoWorking.BLL.Models;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

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

        List<OrderUnitModel> unitOrdersList = new List<OrderUnitModel>();
        List<OrderUnitModel> unitOrdersToOrder = new List<OrderUnitModel>();


        TabOrderController orderController = new TabOrderController();
        private ICollectionView items;
        

        public MainWindow()
        {
            _instance.UpdateInstance();
            InitializeComponent();

            DataGridCustomers.ItemsSource = _instance.CustomersToEdit;
            DataGridRentPrices.ItemsSource = _instance.RentPrices;
            DataGridAdministrationTest.ItemsSource = _instance.AdditionalServices;
            ComboBoxOrderStatus.ItemsSource = new List<string>() { "Paid", "Unpaid", "Cancelled" }; 
        }

        private void ButtonCreateNewOrder_Click(object sender, RoutedEventArgs e)
        {           
            if (DataGridCustomers.SelectedItem != null)
            {
                MainTabControl.SelectedItem = TabItem_Orders;
                CustomerModel customerSelected = DataGridCustomers.SelectedItem as CustomerModel;         
                DataGrid_Order.ItemsSource = modelController.GetOrderByCustomerID(customerSelected.Id);
                DataGrid_Order.Items.Refresh();
                TextBlockChoosenCustomer.Text = customerSelected.ToString();
            }

        }

        private void ButtonCreateNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            modelController.AddCustomerToBase(TextBoxFirstName.Text, TextBoxLastName.Text, TextBoxNumber.Text, TextBoxEmail.Text);
            _instance.UpdateInstance();
            DataGridCustomers.ItemsSource = _instance.CustomersToEdit;          
        }


        private void Combobox_PurchaseType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Combobox_PurchaseType.SelectedItem is null)
            {
                return;
            }
            Order_Calendar.BlackoutDates.Clear();
            var room = Combobox_PurchaseType.SelectedItem as RoomModel;
            var workPlaceIdInRoom = orderController.GetAllWorkplaceInRoom(room.Id);
            
            Combobox_ChooseWorkplace.ItemsSource = _instance.WorkPlaces.Where(r => workPlaceIdInRoom.Contains(r.Id));

            switch (ComboBox_Type.SelectedIndex)
            {

                case 0:
                    foreach (var workplaceId in workPlaceIdInRoom)
                    {
                        var date = orderController.GetStringBusyDate(room.Id, workplaceId);
                        var dateConvert = orderController.ConvertIntBusyDateRoom(date);
                        for (int i = dateConvert.Count - 1; i > 0; i -= 3)
                        {
                            Order_Calendar.BlackoutDates.Add(new CalendarDateRange(new DateTime(dateConvert[i], dateConvert[i - 1], dateConvert[i - 2])));
                        }
                        date.Clear();
                        dateConvert.Clear();
                    }
                    break;

                case 4:

                    break;
            }
        }

        private void ComboBox_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Combobox_ChooseWorkplace.IsEnabled = false;

            switch (ComboBox_Type.SelectedIndex)
            {
                case 0:

                    Combobox_PurchaseType.ItemsSource = _instance.Rooms;

                    break;

                case 1:
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    Combobox_ChooseWorkplace.IsEnabled = true;
                    Combobox_PurchaseType.ItemsSource = _instance.Rooms;
                    break;

                case 5:

                    Combobox_PurchaseType.ItemsSource = _instance.AdditionalServices;
                   
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

            string startDate = DatePicker_Order_StartDate.Text;
            string endDate = DatePicker_Order_EndDate.Text;

            switch (ComboBox_Type.SelectedIndex)
            {
                case 0:
                    var freeRoomsId = orderController.SearchFreeForDate(startDate, endDate);
                    var freeRooms = _instance.Rooms.Where(r => freeRoomsId.Contains(r.Id));
                    Combobox_PurchaseType.ItemsSource = freeRooms;
                    break;
                case 4:
                    var freeRoomsIdForWorkplace = orderController.SearchFreeForDate(startDate, endDate, true);
                    var freeRoomsForWorkplace = _instance.Rooms.Where(r => freeRoomsIdForWorkplace.Contains(r.Id));
                    Combobox_PurchaseType.ItemsSource = freeRoomsForWorkplace;
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
            var roomName= Combobox_PurchaseType.SelectedItem ;
            var rooms = modelController.GetAllRoom();
        
            
            
            foreach (var room in rooms)
            {
                if (room.Name == Convert.ToString(roomName))
                {
                    var workPlaceIdInRoom = orderController.GetAllWorkplaceInRoom(room.Id);
                    var workPlaceRoom = _instance.WorkPlaces.Where(r => workPlaceIdInRoom.Contains(r.Id));
                    foreach (var workplace in workPlaceRoom)
                    {
                        if (workplace.Number ==Combobox_ChooseWorkplace.SelectedIndex+1)
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

        private void ButtonSaveProduct_Click(object sender, RoutedEventArgs e)
        {
            switch (ComboBoxChooseAddOrEdit.SelectedIndex)
            {
                case 0:
                    if (ComboBoxTypeAdministration.SelectedIndex == 0)
                    {
                        RoomModel newRoom = new RoomModel();
                        newRoom.Name = TextBoxProductName.Text;
                        newRoom.Type = TypeOfProduct.MiniOffice;
                        if (ComboBoxTypeOfRoom.SelectedIndex == 0)
                        {
                            newRoom.WorkPlaceNumber = Int32.Parse(TextBoxProductCount.Text);
                        }
                        modelController.AddRoom(newRoom);
                        _instance.UpdateInstance();
                        DataGridAdministrationTest.ItemsSource = _instance.Rooms;
                    }                   
                    
                    break;
                case 1:                    
                    break;                  
            }
        }

        private void ComboBoxTypeAdministration_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
        private void ButtonAddToOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderUnitModel orderUnit = new OrderUnitModel()
            {
                StartDate = DatePicker_Order_StartDate.Text,
                EndDate = DatePicker_Order_EndDate.Text,       
                TypeForUi =ComboBox_Type.Text,
                NameOfficeForUi = Combobox_PurchaseType.Text,
                NumberWorkplaceForUi = Combobox_ChooseWorkplace.Text

            };
            orderController.FillId(orderUnit, ComboBox_Type.SelectedIndex, Combobox_PurchaseType.SelectedItem as RoomModel, Combobox_PurchaseType.SelectedItem as AdditionalServiceModel, Combobox_ChooseWorkplace.SelectedItem as WorkPlaceModel);
            orderUnit.OrderUnitCost = 10; // Method which get customer and choose rentprice by data
            unitOrdersToOrder.Add(orderUnit);
            DataGrid_UnitOrder.ItemsSource = unitOrdersToOrder;
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
            CustomerModel customerSelected = DataGridCustomers.SelectedItem as CustomerModel;
            decimal orderCost = modelController.GetSumOrderUnits(unitOrdersToOrder); 
            OrderModel order = new OrderModel() { CustomerId = customerSelected.Id, OrderCost = orderCost, OrderStatus=ComboBoxOrderStatus.SelectedItem.ToString(), PaidDate=DateTime.Now.ToString() };
            var orderId = modelController.AddOrderInBase(order); 
            foreach(OrderUnitModel orderUnit in unitOrdersToOrder)
            {
                orderUnit.OrderId = Int32.Parse( orderId);
                modelController.AddUnitOrdertoBase(orderUnit); 
            }
            DataGrid_UnitOrder.ItemsSource = null;
            unitOrdersToOrder.Clear();
            DataGrid_Order.Items.Refresh();
        }

        private void ButtonResetCustomer_Click(object sender, RoutedEventArgs e)
        {
            TextBlockChoosenCustomer.Text = "";
            DataGridCustomers.SelectedIndex = -1;
        }
    }
}
