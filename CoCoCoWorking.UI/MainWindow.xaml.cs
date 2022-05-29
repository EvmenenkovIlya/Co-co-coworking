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
using CoCoCoWorking.DAL;
using CoCoCoWorking.DAL.DTO;

namespace CoCoCoWorking.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RoomManager room = new RoomManager();
        AdditionalServiceManager additionalService = new AdditionalServiceManager();

        
        public MainWindow()
        {
            InitializeComponent();

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
            var allService = additionalService.GetAllAdditionalService();
            var roomName = room.GetAllRooms();

            if (Type_ComboBox.SelectedIndex == 5)
            {
                PurchaseType_Combobox.Items.Clear();
                foreach (var service in allService)
                {

                    PurchaseType_Combobox.Items.Add(service.Name);
                }

            }

            if (Type_ComboBox.SelectedIndex == 0)
            {
                PurchaseType_Combobox.Items.Clear();
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

        }

        private void Order_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            Order_DataGrid.Items.Refresh();
           

        }
    }
}
