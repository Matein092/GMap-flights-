using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

using model;


namespace userInterface
{
    public partial class MainMenu : Form
    {

        private Country country;
        private GMapOverlay GMapOverlay;

        public MainMenu()
        {
            InitializeComponent();
            this.country = new Country();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

            //Aqui llama a este metodo para leer los datos y crear los vuelos
            createData();

            gmap.DragButton = MouseButtons.Right;
            gmap.CanDragMap = true;
            gmap.MapProvider = GMapProviders.OpenStreetMap;
            gmap.ShowCenter = false;
            gmap.Zoom = 4;
            gmap.SetPositionByKeywords("United States");
            CreateMarkers();
        }

        private void searchCity_Click_1(object sender, EventArgs e)
        {
            gmap.SetPositionByKeywords(originCityField.Text);
            TraceRoute();
        }

        private void cleanFields_Click(object sender, EventArgs e)
        {
            this.originCityField.Text = "";
            this.destinationCityField.Text = "";
            gmap.Zoom = 4;
            gmap.SetPositionByKeywords("United States");
        }


        private void createData()
        {
            try
            {
                country.ReadData();
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DirectoryNotFoundException e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateMarkers()
        {
            List<String> list = country.GetUbicationsFlights();
            this.GMapOverlay = new GMapOverlay("Markers");

            foreach (String element in list)
            {
                PointLatLng point;
                gmap.GetPositionByKeywords(element, out point);
                GMarkerGoogle marker = new GMarkerGoogle(point, GMarkerGoogleType.orange);

                this.GMapOverlay.Markers.Add(marker);
                gmap.Overlays.Add(this.GMapOverlay);
            }
        }

        private void TraceRoute()
        {
            PointLatLng point1;
            gmap.GetPositionByKeywords(this.originCityField.Text, out point1);

            PointLatLng point2;
            gmap.GetPositionByKeywords(this.destinationCityField.Text, out point2);

            GMapOverlay gMapOverlay = new GMapOverlay("Marcador");
            GMarkerGoogle marker1 = new GMarkerGoogle(point1, GMarkerGoogleType.orange);
            GMarkerGoogle marker2 = new GMarkerGoogle(point2, GMarkerGoogleType.orange);

            gMapOverlay.Markers.Add(marker1);
            gMapOverlay.Markers.Add(marker2);

            gmap.Overlays.Add(gMapOverlay);
        }
    }
}