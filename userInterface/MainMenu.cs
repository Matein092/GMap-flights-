using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

using model;
using customExceptions;


namespace userInterface
{
    public partial class MainMenu : Form
    {

        private Country country;

        public MainMenu()
        {
            InitializeComponent();
            this.country = new Country();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            CreateData();

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

            try
            {
                List<Flight> list = country.FlightbyOrigin(originCityField.Text);

                gmap.Overlays.Clear();
                CreateCityMarker(originCityField.Text, list);
            }
            catch (FlightNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (EmptyFieldException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cleanFields_Click(object sender, EventArgs e)
        {
            this.originCityField.Text = "";
            CreateMarkers();

            gmap.Zoom = 4;
            gmap.SetPositionByKeywords("United States");
        }

        private void CreateCityMarker(String city, List<Flight> flights)
        {
            PointLatLng point;
            gmap.GetPositionByKeywords(city, out point);
            GMarkerGoogle marker = new GMarkerGoogle(point, GMarkerGoogleType.orange);

            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            marker.ToolTipText = String.Format("Ubicacion: \n {0}", city);

            GMapOverlay GMapOverlay = new GMapOverlay("Markers");
            GMapOverlay.Markers.Add(marker);
            gmap.Overlays.Add(GMapOverlay);

            ShowCityFlights(flights);
        }

        private void ShowCityFlights(List<Flight> flights)
        {

        }

        private void CreateData()
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

            foreach (String element in list)
            {
                PointLatLng point;
                gmap.GetPositionByKeywords(element, out point);
                GMarkerGoogle marker = new GMarkerGoogle(point, GMarkerGoogleType.orange);

                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                marker.ToolTipText = String.Format("Ubicacion: \n {0}", element);

                GMapOverlay GMapOverlay = new GMapOverlay("Markers");
                GMapOverlay.Markers.Add(marker);
                gmap.Overlays.Add(GMapOverlay);
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