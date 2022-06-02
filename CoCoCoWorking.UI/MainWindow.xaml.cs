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

namespace CoCoCoWorking.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        RoomManager room = new RoomManager();
        AdditionalServiceManager additionalService = new AdditionalServiceManager();
        OrderManager order = new OrderManager();
        FinanceReportManager financeReportManager = new FinanceReportManager();
        AllCustomerWhithOrderWithOrderUnitManager CustomerManager = new AllCustomerWhithOrderWithOrderUnitManager();

        CalendarForOrder busyOrFreeRoom= new CalendarForOrder();
        AutoMapper.Mapper mapper = MapperConfigStorage.GetInstance();


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

        private void PurchaseType_Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           if(PurchaseType_Combobox.SelectedItem is null)
            {
                return;
            }
            ChooseWorkplace_Combobox.Items.Clear();
            Order_Calendar.BlackoutDates.Clear();

            string roomName = PurchaseType_Combobox.SelectedItem.ToString();

            var rooms = room.GetAllRooms();

            foreach (var room in rooms)
            {
                if (room.Name == roomName)
                {
                    for (int i = 1; i <= room.WorkPlaceNumber; i++)
                    {
                        ChooseWorkplace_Combobox.Items.Add($" Worck place number:{i}");
                    }
                    //ForTestCalendar
                    if(Type_ComboBox.SelectedIndex == 0)
                    {
                         var date = busyOrFreeRoom.GetStringBusyDateRoom(room.Id);
                         var dateConvert = busyOrFreeRoom.ConvertIntBusyDateRoom(date);

                         for(int i = dateConvert.Count-1; i>0; i-=3)
                         {
                             Order_Calendar.BlackoutDates.Add(new CalendarDateRange(new DateTime(dateConvert[i], dateConvert[i-1], dateConvert[i-2])));                            
                         }
                        date.Clear();
                        dateConvert.Clear();
                    }                   
                }   //

            }

        }
        private void Type_ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
            ChooseWorkplace_Combobox.IsEnabled = false;
            ChooseWorkplace_Combobox.Items.Clear();
            PurchaseType_Combobox.Items.Clear();
           
            var allService = additionalService.GetAllAdditionalServices();
            var roomName = room.GetAllRooms();

            if (Type_ComboBox.SelectedIndex == 5)
            {
                foreach (var service in allService)
                {
                    PurchaseType_Combobox.Items.Add(service.Name);
                }

            }
            if (Type_ComboBox.SelectedIndex == 0 || Type_ComboBox.SelectedIndex == 2) // test for room free
            {
                
                
                for (int i = 0; i < roomName.Count; i++)
                {
                    PurchaseType_Combobox.Items.Add(roomName[i].Name);


                }


            }
            if (Type_ComboBox.SelectedIndex == 4)
                {
                    
                    ChooseWorkplace_Combobox.IsEnabled = true;
                    for (int i = 0; i < roomName.Count; i++)
                    {
                        PurchaseType_Combobox.Items.Add(roomName[i].Name);
                    

                }

            }

                if (Type_ComboBox.SelectedIndex == 1)
                {
                    PurchaseType_Combobox.Items.Clear();
                }
            }

            private void Button_GetReport_Click(object sender, RoutedEventArgs e)
            {

                //switch (ComboBox_TypeOfReport.SelectedIndex)
                //{
                //    case 0:
                //        DataGrid_Report.Visibility = Visibility.Visible;
                //        List<FinanceReportDTO> financeReportDTOs = financeReportManager.GetFinanceReport(DataPicker_Finance_StartDate.SelectedDate.Value, DataPicker_Finance_EndDate.SelectedDate.Value);
                //        List<FinanceReportModel> financeReportModels = mapper.Map<List<FinanceReportModel>>(financeReportDTOs);
                //        DataGrid_Report.ItemsSource = financeReportModels;
                //        break;
                //    case 1:
                //        DataGrid_ReportByCustomer.Visibility = Visibility.Visible;
                //        List<FinanceReportByCustomerDTO> financeReportByCustomerDTOs = financeReportManager.GetFinanceReportByCustomer(DataPicker_Finance_StartDate.SelectedDate.Value, DataPicker_Finance_EndDate.SelectedDate.Value);
                //        List<FinanceReportByCustomerModel> financeReportByCustomerModels = mapper.Map<List<FinanceReportByCustomerModel>>(financeReportByCustomerDTOs);
                //        DataGrid_ReportByCustomer.ItemsSource = financeReportByCustomerModels;
                //        break;


                //}


            }

            

        private void ChooseWorkplace_Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonSearchByNumber_Click(object sender, RoutedEventArgs e)
        {

    
        }

        private void ButtonSearchByDate_Click(object sender, RoutedEventArgs e)
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
    }
    }   
