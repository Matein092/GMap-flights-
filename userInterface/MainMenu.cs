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

            filterBox.Items.Add("Numero del Avion");
            filterBox.Items.Add("Fecha Salida");
            filterBox.Items.Add("Tiempo Vuelo");
            filterBox.Items.Add("Ciudad Destino");
            filterBox.Items.Add("Distancia");

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
                dataView.Rows.Clear();
                dataView.Columns.Clear();
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
            dataView.Rows.Clear();
            dataView.Columns.Clear();

            gmap.Overlays.Clear();
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
            dataView.ColumnCount = 9;

            DataGridViewColumn flightNC = dataView.Columns[0];
            flightNC.HeaderText = "Numero Vuelo";
            DataGridViewColumn tailNC = dataView.Columns[1];
            tailNC.HeaderText = "Numero Avion";
            DataGridViewColumn dateC = dataView.Columns[2];
            dateC.HeaderText = "Fecha Salida";
            DataGridViewColumn hourC = dataView.Columns[3];
            hourC.HeaderText = "Hora Salida (hhmm)";
            DataGridViewColumn originCityC = dataView.Columns[4];
            originCityC.HeaderText = "Ciudad Origen";
            DataGridViewColumn destinationCityC = dataView.Columns[5];
            destinationCityC.HeaderText = "Ciudad Destino";
            DataGridViewColumn airTimeC = dataView.Columns[6];
            airTimeC.HeaderText = "Tiempo Vuelo";
            DataGridViewColumn arrvialTimeC = dataView.Columns[7];
            arrvialTimeC.HeaderText = "Tiempo Llegada (hhmm)";
            DataGridViewColumn distanceC = dataView.Columns[8];
            distanceC.HeaderText = "Distancia";

            foreach (Flight element in flights)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataView);
                
                row.Cells[0].Value = element.FlightNumber;
                row.Cells[1].Value = element.TailNumber;
                row.Cells[2].Value = element.Date;
                row.Cells[3].Value = element.Hour;
                row.Cells[4].Value = element.OriginCity;
                row.Cells[5].Value = element.DestinationCity;
                row.Cells[6].Value = element.AirTime;
                row.Cells[7].Value = element.ArivalTime;
                row.Cells[8].Value = element.Distance;

                dataView.Rows.Add(row);
            }
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

        private void FilterByTailNumber(String origin)
        {
            dataView.Rows.Clear();
            dataView.Columns.Clear();

            dataView.ColumnCount = 1;
            List<Flight> list = country.FlightbyOrigin(origin);

            DataGridViewColumn flightNC = dataView.Columns[0];
            flightNC.HeaderText = "Numero Avion";

            foreach (Flight element in list)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataView);

                row.Cells[0].Value = element.TailNumber;
                dataView.Rows.Add(row);
            }
        }

        private void FilterByDate(String origin)
        {
            dataView.Rows.Clear();
            dataView.Columns.Clear();

            dataView.ColumnCount = 1;
            List<Flight> list = country.FlightbyOrigin(origin);

            DataGridViewColumn dateC = dataView.Columns[0];
            dateC.HeaderText = "Fecha Salida";

            foreach (Flight element in list)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataView);

                row.Cells[0].Value = element.Date;
                dataView.Rows.Add(row);
            }
        }

        private void FilterByAirTime(String origin)
        {
            dataView.Rows.Clear();
            dataView.Columns.Clear();

            dataView.ColumnCount = 1;
            List<Flight> list = country.FlightbyOrigin(origin);

            DataGridViewColumn airTimeC = dataView.Columns[0];
            airTimeC.HeaderText = "Tiempo Vuelo";

            foreach (Flight element in list)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataView);

                row.Cells[0].Value = element.AirTime;
                dataView.Rows.Add(row);
            }
        }

        private void FilterByDestination(String origin)
        {
            dataView.Rows.Clear();
            dataView.Columns.Clear();

            dataView.ColumnCount = 1;
            List<Flight> list = country.FlightbyOrigin(origin);

            DataGridViewColumn destinationCityC = dataView.Columns[0];
            destinationCityC.HeaderText = "Ciudad Destino";

            foreach (Flight element in list)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataView);

                row.Cells[0].Value = element.DestinationCity;
                dataView.Rows.Add(row);
            }
        }

        private void FilterByDistance(String origin)
        {
            dataView.Rows.Clear();
            dataView.Columns.Clear();

            dataView.ColumnCount = 1;
            List<Flight> list = country.FlightbyOrigin(origin);

            DataGridViewColumn distanceC = dataView.Columns[0];
            distanceC.HeaderText = "Distancia";

            foreach (Flight element in list)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataView);

                row.Cells[0].Value = element.Distance;
                dataView.Rows.Add(row);
            }
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            if (dataView.Columns.Count > 0)
            {
                if (filterBox.SelectedItem != null)
                {
                    switch (filterBox.SelectedItem)
                    {
                        case "Numero del Avion":
                            FilterByTailNumber(originCityField.Text);
                            break;
                        case "Fecha Salida":
                            FilterByDate(originCityField.Text);
                            break;
                        case "Tiempo Vuelo":
                            FilterByAirTime(originCityField.Text);
                            break;
                        case "Ciudad Destino":
                            FilterByDestination(originCityField.Text);
                            break;
                        case "Distancia":
                            FilterByDistance(originCityField.Text);
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Debe de elegir un campo para filtar la informacion", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe de elegir una ciudad primero para filtar la informacion", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}