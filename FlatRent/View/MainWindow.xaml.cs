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
using FlatRent.ViewModel;
using FlatRent.Model;

namespace FlatRent.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        public RegionDAO regionDao;

        public MainWindow()
        {
            regionDao = new RegionDAO();
            InitializeComponent();
            List<region> regionList = regionDao.GetAllRegions();
            List<String> namesOfRegionsList = new List<string>();
            for (int i = 0; i < regionList.Count; i++) {
                namesOfRegionsList.Add(regionList[i].title.ToString());
                combo_regions.Items.Add(regionList[i].title.ToString());
                Console.WriteLine(regionList[i].title.ToString());
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void okRegionButton_Click(object sender, RoutedEventArgs e)
        {
            string selected = this.combo_regions.SelectedItem.ToString();
            int id = regionDao.GetIdRegionByTitle(selected);
            ListOfFlats flatForm = new ListOfFlats(id);
            flatForm.Show();
            this.Close();
        }
    }
}
