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
using FlatRent.Model;
using FlatRent.ViewModel;

namespace FlatRent.View
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        FlatDAO flatDao = new FlatDAO();
        RoomCountDAO roomDao = new RoomCountDAO();
        WallMaterialDAO wallDao = new WallMaterialDAO();
        YearConstructionDAO yearDao = new YearConstructionDAO();
        private int regionId;

        public Window1(int regionId)
        {
            InitializeComponent();
            this.regionId = regionId;
            List<roomcount> roomCountList = roomDao.GetAllRoomCounts();
            
            for (int i = 0; i < roomCountList.Count; i++)
            {               
                this.roomCountCombo.Items.Add(roomCountList[i].roomCount.ToString());               
            }

            List<wallmaterial> wallsList = wallDao.GetAllWallMaterials();            
            for (int i = 0; i < wallsList.Count; i++) {         
                this.wallsCombo.Items.Add(wallsList[i].title.ToString());

            }

            List<yearconstruction> yearsList = yearDao.GetAllYearConstructions();
            for (int i = 0; i < yearsList.Count; i++) {
                this.yearCombo.Items.Add(yearsList[i].yearConstruction.ToString());
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           int roomCountId = roomDao.GetIdRoomCountByCount(Int32.Parse(this.roomCountCombo.SelectedItem.ToString()));
           int wallMaterialId = wallDao.GetIdWallMaterialByTitle(this.wallsCombo.SelectedItem.ToString()); 
           int yearId = yearDao.GetIdYearConstructionByYear(Int32.Parse(this.yearCombo.SelectedItem.ToString()));
           int floor = Int32.Parse(this.floorBox.Text.ToString());
           int numberOfFloors = Int32.Parse(this.floouCountBox.Text);
           int square = Int32.Parse(this.squareBox.Text);
           String streetParam = this.streetBox.Text;
           int houseNo = Int32.Parse(this.houseNumberBox.Text);
           int flatNo = Int32.Parse(this.flatNumberBox.Text);

           flatDao.Create(regionId, roomCountId, wallMaterialId, yearId, floor, numberOfFloors, square, streetParam, houseNo, flatNo);
           this.Close();
           ListOfFlats form = new ListOfFlats(this.regionId);
           form.Show();
        }

       
    }
}
