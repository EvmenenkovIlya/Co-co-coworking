﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.IO;
using CoCoCoWorking.DAL;
using CoCoCoWorking.DAL.DTO;
using System.Data;
using CoCoCoWorking.BLL;
using CoCoCoWorking.BLL.Models;
using System.ComponentModel;

namespace CoCoCoWorking.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        
        AdditionalServiceManager additionalService = new AdditionalServiceManager();//test
        OrderManager order = new OrderManager();
        AllCustomerWhithOrderWithOrderUnitManager CustomerManager = new AllCustomerWhithOrderWithOrderUnitManager();
        ModelController modelController = new ModelController();
       
        TabOrderController orderController = new TabOrderController();
        AutoMapper.Mapper mapper = MapperConfigStorage.GetInstance();
        private ICollectionView items;


        public MainWindow()
        {
            InitializeComponent();
            List<CustomersWithOrdersDTO> customers = CustomerManager.GetAllCustomerWhithOrderWithOrderUnit();
            List<CustomerModel> CustomerModel = mapper.Map<List<CustomerModel>>(customers);
            DataGridCustomers.ItemsSource = CustomerModel;


        }

        private void ButtonCreateNewOrder_Click(object sender, RoutedEventArgs e)
        {
            TextBoxNumberForSearch.Text = DataGridCustomers.SelectedItem.ToString();
        }

        private void ButtonCreateNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            //customers.AddCustomer(TextBoxFirstName.Text, TextBoxLastName.Text, TextBoxNumber.Text, TextBoxEmail.Text);
            //DataGridCustomers.ItemsSource = customers.GetAllCustomers();
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

            var allService = additionalService.GetAllAdditionalServices();
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
            string search = TextBoxNumberForSearch.Text;
            int index = DataGridCustomers.Items.IndexOf(search);
            DataGridCustomers.SelectedIndex = index;
        }

        private void ButtonSearchByDateForOrder_Click(object sender, RoutedEventArgs e)
        {
            Combobox_PurchaseType.Items.Clear();
            string startDate = DatePicker_Order_StartDate.Text;
            string endDate = DatePicker_Order_EndDate.Text;
            var freeRooms = orderController.SearchRoomsForDate(startDate, endDate);
           

            switch  (ComboBox_Type.SelectedIndex)
            {
                case 0:
                    foreach (var room in freeRooms)
                    {
                        Combobox_PurchaseType.Items.Add(room);
                    } 
                    break;
                case 4:
                    
                    break;
               
            }
        }

        private void Combobox_ChooseWorkplace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Combobox_ChooseWorkplace.SelectedItem is null)
            {
                return;
            }

            Order_Calendar.BlackoutDates.Clear();
            var roomName = Combobox_PurchaseType.SelectedItem as string;
            var rooms = modelController.GetAllRoom();

            foreach(var room in rooms)
            {
                if(room.Name == roomName)
                {
                    var workPlaceInRoom = orderController.GetAllWorkplaceInRoom(room.Id);

                    foreach (var workplace in workPlaceInRoom)
                    {
                        if(workplace.Number == (int)Combobox_ChooseWorkplace.SelectedItem )
                        {

                            var date = orderController.GetStringBusyDate(room.Id,workplace.Id);

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
    }
}

    



