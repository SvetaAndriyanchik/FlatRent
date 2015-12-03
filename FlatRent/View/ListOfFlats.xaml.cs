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
using System.Windows.Shapes;
using FlatRent.ViewModel;
using FlatRent.Model;


namespace FlatRent.View
{
    /// <summary>
    /// Логика взаимодействия для ListOfFlats.xaml
    /// </summary>
    public partial class ListOfFlats : Window
    {
        private int regionId;
        public FlatDAO dao = new FlatDAO();
        public ListOfFlats(int regionId)
        {
            InitializeComponent();
            this.regionId = regionId;
            formTable();
            fillInTable(regionId);
        }

        private void fillInTable(int regionId) {
            List<flat> flatList = dao.GetFlatsByIdRegion(regionId);
            ResultDataGrid.Items.Clear();
            
            for (int i = 0; i < flatList.Count; i++)
            {
                ResultDataGrid.Items.Add(new DataItem
                {
                    Id = flatList[i].id.ToString(),
                    Region = flatList[i].region.title.ToString(),
                    RoomCount = flatList[i].roomcount.roomCount.ToString(),
                    WallMaterial = flatList[i].wallmaterial.title.ToString(),
                    Year = flatList[i].yearconstruction.yearConstruction.ToString(),
                    FloorsInHouseCount = flatList[i].numberOfFloors.Value.ToString(),
                    FloorNumber = flatList[i].floor.Value.ToString(),
                    Square = flatList[i].square.Value.ToString(),
                    Street = flatList[i].street.ToString(),
                    HouseNumber = flatList[i].houseNumber.Value.ToString(),

                });
            } 
            
        }

        private void formTable()
        {

            var id = new DataGridTextColumn();
            id.Header = "Id";
            id.Binding = new Binding("Id");
            ResultDataGrid.Columns.Add(id);

            var region = new DataGridTextColumn();
            region.Header = "Region";
            region.Binding = new Binding("Region");
            ResultDataGrid.Columns.Add(region);

            var roomCount = new DataGridTextColumn();
            roomCount.Header = "RoomCount";
            roomCount.Binding = new Binding("RoomCount");
            ResultDataGrid.Columns.Add(roomCount);

            var walls = new DataGridTextColumn();
            walls.Header = "WallMaterial";
            walls.Binding = new Binding("WallMaterial");
            ResultDataGrid.Columns.Add(walls);

            var year = new DataGridTextColumn();
            year.Header = "Year";
            year.Binding = new Binding("Year");
            ResultDataGrid.Columns.Add(year);

            var floorNumber = new DataGridTextColumn();
            floorNumber.Header = "FloorsInHouseCount";
            floorNumber.Binding = new Binding("FloorsInHouseCount");
            ResultDataGrid.Columns.Add(floorNumber);

            var floor = new DataGridTextColumn();
            floor.Header = "Floor #";
            floor.Binding = new Binding("FloorNumber");
            ResultDataGrid.Columns.Add(floor);

            var square = new DataGridTextColumn();
            square.Header = "Square";
            square.Binding = new Binding("Square");
            ResultDataGrid.Columns.Add(square);

            var street = new DataGridTextColumn();
            street.Header = "Street";
            street.Binding = new Binding("Street");
            ResultDataGrid.Columns.Add(street);

            var house = new DataGridTextColumn();
            house.Header = "HouseNumber";
            house.Binding = new Binding("HouseNumber");
            ResultDataGrid.Columns.Add(house);

            



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = (int)ResultDataGrid.SelectedIndex;
            DataItem item = (DataItem)ResultDataGrid.Items[index];
            dao.Delete(Int32.Parse(item.Id));

            fillInTable(regionId);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            Window1 form = new Window1(regionId);
            form.Show();
        }
    }
}
