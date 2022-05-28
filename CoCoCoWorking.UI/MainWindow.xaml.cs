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


        private void Office_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ChooseWorkplace_Combobox.IsEnabled = false;
            var roomName = room.GetAllRooms();
            ChooseRoom_Combobox.Items.Clear();
            for (int i = 0; i < roomName.Count; i++)
            {
                ChooseRoom_Combobox.Items.Add(roomName[i].Name);
            }

        }

        private void WorckPlace_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ChooseWorkplace_Combobox.IsEnabled = true;
            var roomName = room.GetAllRooms();
            ChooseRoom_Combobox.Items.Clear();
            for (int i = 0; i < roomName.Count; i++)
            {
                ChooseRoom_Combobox.Items.Add(roomName[i].Name);
            }

        }

        private void ChooseRoom_Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChooseWorkplace_Combobox.Items.Clear();
            if (ChooseRoom_Combobox.SelectedItem == null)
            {
                return;
            }
            string roomName = ChooseRoom_Combobox.SelectedItem.ToString();

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

        private void Service_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Service_ListBox.Items.Clear();
            var allService = additionalService.GetAllAdditionalService();
            foreach (var service in allService)
            {

                Service_ListBox.Items.Add(service.Name);
            }
        }
    }
}
