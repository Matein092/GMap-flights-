namespace userInterface
{
    partial class MainMenu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.originCityField = new System.Windows.Forms.TextBox();
            this.searchFlight = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cleanFields = new System.Windows.Forms.Button();
            this.dataView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.SuspendLayout();
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemory = 5;
            this.gmap.Location = new System.Drawing.Point(12, 12);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 18;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomEnabled = true;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(650, 512);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 13D;
            // 
            // originCityField
            // 
            this.originCityField.Location = new System.Drawing.Point(812, 37);
            this.originCityField.Margin = new System.Windows.Forms.Padding(50);
            this.originCityField.Name = "originCityField";
            this.originCityField.Size = new System.Drawing.Size(175, 20);
            this.originCityField.TabIndex = 1;
            // 
            // searchFlight
            // 
            this.searchFlight.Location = new System.Drawing.Point(812, 79);
            this.searchFlight.Margin = new System.Windows.Forms.Padding(50);
            this.searchFlight.Name = "searchFlight";
            this.searchFlight.Size = new System.Drawing.Size(85, 23);
            this.searchFlight.TabIndex = 2;
            this.searchFlight.Text = "Buscar Vuelo";
            this.searchFlight.UseVisualStyleBackColor = true;
            this.searchFlight.Click += new System.EventHandler(this.searchCity_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(809, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ciudad de origen del vuelo";
            // 
            // cleanFields
            // 
            this.cleanFields.Location = new System.Drawing.Point(902, 79);
            this.cleanFields.Margin = new System.Windows.Forms.Padding(50);
            this.cleanFields.Name = "cleanFields";
            this.cleanFields.Size = new System.Drawing.Size(85, 23);
            this.cleanFields.TabIndex = 6;
            this.cleanFields.Text = "Limpiar";
            this.cleanFields.UseVisualStyleBackColor = true;
            this.cleanFields.Click += new System.EventHandler(this.cleanFields_Click);
            // 
            // dataView
            // 
            this.dataView.AllowUserToAddRows = false;
            this.dataView.AllowUserToDeleteRows = false;
            this.dataView.AllowUserToOrderColumns = true;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Location = new System.Drawing.Point(678, 157);
            this.dataView.Name = "dataView";
            this.dataView.ReadOnly = true;
            this.dataView.Size = new System.Drawing.Size(427, 387);
            this.dataView.TabIndex = 7;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 556);
            this.Controls.Add(this.dataView);
            this.Controls.Add(this.cleanFields);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchFlight);
            this.Controls.Add(this.originCityField);
            this.Controls.Add(this.gmap);
            this.Name = "MainMenu";
            this.Text = "GMap Flights";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.TextBox originCityField;
        private System.Windows.Forms.Button searchFlight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cleanFields;
        private System.Windows.Forms.DataGridView dataView;
    }
}

