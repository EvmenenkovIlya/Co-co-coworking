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
    public partial class MainWindow : Window
    {
        RoomManager room = new RoomManager();
        AdditionalServiceManager additionalService = new AdditionalServiceManager();
        OrderManager order = new OrderManager();
        FinanceReportManager financeReportManager = new FinanceReportManager();
        AllCustomerWhithOrderWithOrderUnitManager CustomerManager = new AllCustomerWhithOrderWithOrderUnitManager();

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
            ChooseWorkplace_Combobox.Items.Clear();
            if (PurchaseType_Combobox.SelectedItem == null)
            {
                return;
            }
            string roomName = PurchaseType_Combobox.SelectedItem.ToString();

            var rooms = room.GetAllRooms();

            foreach (var room in rooms)
            {
                if (room.Name == roomName)
                {
                    for (int i = 1; i < room.WorkPlaceNumber; i++)
                    {
                        ChooseWorkplace_Combobox.Items.Add($" Worck place number:{i}");
                    }
                }
            }

        }            
        private void Type_ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ChooseWorkplace_Combobox.IsEnabled = false;
            ChooseWorkplace_Combobox.Items.Clear ();
            var allService = additionalService.GetAllAdditionalServices();
            var roomName = room.GetAllRooms();

            if (Type_ComboBox.SelectedIndex == 5)
            {
                PurchaseType_Combobox.Items.Clear();
                foreach (var service in allService)
                {
                    PurchaseType_Combobox.Items.Add(service.Name);
                }

            }
            if (Type_ComboBox.SelectedIndex == 0 || Type_ComboBox.SelectedIndex == 2)
            {
                PurchaseType_Combobox.Items.Clear();
                for (int i = 0; i < roomName.Count; i++)
                {
                    PurchaseType_Combobox.Items.Add(roomName[i].Name);
                }
            }
            if (Type_ComboBox.SelectedIndex == 4)
            {
                PurchaseType_Combobox.Items.Clear();
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

            switch (ComboBox_TypeOfReport.SelectedIndex)
            {
                case 0:
                    List<FinanceReportDTO> financeReportDTOs = financeReportManager.GetFinanceReport(new DateTime(2022, 5, 1), new DateTime(2022, 5, 31));
                    List<FinanceReportModel> financeReportModels = mapper.Map<List<FinanceReportModel>>(financeReportDTOs);
                    DataGrid_Report.ItemsSource = financeReportModels;
                    break;
                case 1:
                    break;


            }


            }
    }
}
