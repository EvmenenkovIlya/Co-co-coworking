using System;
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
        Singleton _instance = Singleton.GetInstance();

        CalendarForOrder busyOrFreeRoom = new CalendarForOrder();
        AutoMapper.Mapper mapper = MapperConfigStorage.GetInstance();
        private ICollectionView items;


        public MainWindow()
        {
            InitializeComponent();

            DataGridCustomers.ItemsSource = _instance.Customers;
            DataGridRentPrices.ItemsSource = _instance.RentPrices;

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

        private void PurchaseType_Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PurchaseType_Combobox.SelectedItem is null)
            {
                return;
            }

            Combobox_ChooseWorkplace.Items.Clear();
            Order_Calendar.BlackoutDates.Clear();

            var rooms = modelController.GetAllRoom();

            foreach (var room in rooms)
            {
                if (room.Name == PurchaseType_Combobox.SelectedItem.ToString())
                {
                    for (int i = 1; i <= room.WorkPlaceNumber; i++)
                    {
                        Combobox_ChooseWorkplace.Items.Add($" Worck place number:{i}");
                    }
                    //ForTestCalendar
                    switch (Type_ComboBox.SelectedIndex)
                    {
                        case 0:
                            var date = busyOrFreeRoom.GetStringBusyDateRoom(room.Id);
                            var dateConvert = busyOrFreeRoom.ConvertIntBusyDateRoom(date);

                            for (int i = dateConvert.Count - 1; i > 0; i -= 3)
                            {
                                Order_Calendar.BlackoutDates.Add(new CalendarDateRange(new DateTime(dateConvert[i], dateConvert[i - 1], dateConvert[i - 2])));
                            }
                            date.Clear();
                            dateConvert.Clear();
                            break;
                    }

                }   //

            }

        }
        private void Type_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Combobox_ChooseWorkplace.IsEnabled = false;
            Combobox_ChooseWorkplace.Items.Clear();
            PurchaseType_Combobox.Items.Clear();

            var allService = additionalService.GetAllAdditionalServices();
            var roomName = modelController.GetAllRoom();

            switch (Type_ComboBox.SelectedIndex)
            {
                case 0:
                    for (int i = 0; i < roomName.Count; i++)
                    {
                        PurchaseType_Combobox.Items.Add(roomName[i].Name);
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
                        PurchaseType_Combobox.Items.Add(roomName[i].Name);
                    }
                    break;

                case 5:
                    foreach (var service in allService)
                    {
                        PurchaseType_Combobox.Items.Add(service.Name);
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

            DataGridCustomers.ItemsSource = modelController.GetCustomerWithTheMatchedNumberIsReturned(TextBoxNumberForSearch.Text,_instance.Customers);
           
        }

        private void ButtonSearchByDateForOrder_Click(object sender, RoutedEventArgs e)
        {
            PurchaseType_Combobox.Items.Clear();
            string startDate = DatePicker_Order_StartDate.Text;
            string endDate = DatePicker_Order_EndDate.Text;
            var freeRooms = busyOrFreeRoom.SearchRoomsForDate(startDate, endDate);
            foreach (var room in freeRooms)
            {
                PurchaseType_Combobox.Items.Add(room);
            }
        }

        private void ButtonReset_Customer_Click(object sender, RoutedEventArgs e)
        {
            TextBoxNumberForSearch.Clear();
            DataGridCustomers.ItemsSource = modelController.GetCustomerWithTheMatchedNumberIsReturned(TextBoxNumberForSearch.Text, _instance.Customers);
        }

       
    }
}

    



