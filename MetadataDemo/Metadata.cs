using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Atalasoft.Imaging;
using Atalasoft.Imaging.Metadata;
using Atalasoft.Imaging.Codec;
using Atalasoft.Imaging.Codec.Tiff;
using WinDemoHelperMethods;

namespace MetadataDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private string _lastFileName = "";
		// Here are the tag collections which will hold all of the information.
		TiffTagExtendedCollection	_tiffTags = null;
		IptcCollection		_iptcTags = null;
		ComTextCollection	_comTags = null;
		ExifTagExtendedCollection		_exifTags = null;
		
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuOpen;
        private System.Windows.Forms.MenuItem menuSave;
        private IContainer components;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabExif;
		private System.Windows.Forms.TabPage tabIptc;
		private System.Windows.Forms.TabPage tabCom;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuIptc;
		private System.Windows.Forms.MenuItem menuIptcAdd;
		private System.Windows.Forms.MenuItem menuCom;
		private System.Windows.Forms.MenuItem menuComClear;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuComAdd;
		private System.Windows.Forms.MenuItem menuComRemove;
		private System.Windows.Forms.TabPage tabTiff;
		private System.Windows.Forms.Panel panelImageBorder;
		private System.Windows.Forms.Label lblImageInfo;
		private System.Windows.Forms.MenuItem mnuIptcRemove;
		private System.Windows.Forms.MenuItem menuIptcClear;
		private System.Windows.Forms.MenuItem menuItem3;
		private Atalasoft.Imaging.WinControls.ImageViewer thumbnailView;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuTiff;
		private System.Windows.Forms.MenuItem menuTiffClear;
		private System.Windows.Forms.MenuItem menuTiffRemove;
		private System.Windows.Forms.MenuItem menuTiffNothing;
		private System.Windows.Forms.MenuItem menuTiffAdd;
		private System.Windows.Forms.MenuItem menuExif;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.DataGrid dataGrid;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid dataGridIptc;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGrid dataGridCom;
		private System.Windows.Forms.MenuItem menuExifClear;
		private System.Windows.Forms.MenuItem menuExifAdd;
		private System.Windows.Forms.MenuItem menuExifRemove;
		private System.Windows.Forms.MenuItem menuTiffViewBinary;
		private System.Windows.Forms.MenuItem menuAddTagAscii;
		private System.Windows.Forms.MenuItem menuAbout;
		private System.Windows.Forms.MenuItem menuExit;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.TabPage tabXmp;
		private System.Windows.Forms.TextBox textXmp;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuAddThumb;
		private System.Windows.Forms.DataGrid dataGridTiff;

        static Form1()
        {
            HelperMethods.PopulateDecoders(RegisteredDecoders.Decoders);
        }

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			this.tabControl1.TabPages.Remove(tabExif);
			this.tabControl1.TabPages.Remove(tabIptc);
			this.tabControl1.TabPages.Remove(tabCom);
			this.tabControl1.TabPages.Remove(tabTiff);
			this.tabControl1.TabPages.Remove(tabXmp);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuFile = new System.Windows.Forms.MenuItem();
            this.menuOpen = new System.Windows.Forms.MenuItem();
            this.menuSave = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuCom = new System.Windows.Forms.MenuItem();
            this.menuComClear = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuComAdd = new System.Windows.Forms.MenuItem();
            this.menuComRemove = new System.Windows.Forms.MenuItem();
            this.menuIptc = new System.Windows.Forms.MenuItem();
            this.menuIptcClear = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuIptcAdd = new System.Windows.Forms.MenuItem();
            this.mnuIptcRemove = new System.Windows.Forms.MenuItem();
            this.menuTiff = new System.Windows.Forms.MenuItem();
            this.menuTiffClear = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuTiffNothing = new System.Windows.Forms.MenuItem();
            this.menuTiffAdd = new System.Windows.Forms.MenuItem();
            this.menuAddTagAscii = new System.Windows.Forms.MenuItem();
            this.menuTiffRemove = new System.Windows.Forms.MenuItem();
            this.menuTiffViewBinary = new System.Windows.Forms.MenuItem();
            this.menuExif = new System.Windows.Forms.MenuItem();
            this.menuExifClear = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuExifAdd = new System.Windows.Forms.MenuItem();
            this.menuExifRemove = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuAddThumb = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuAbout = new System.Windows.Forms.MenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabExif = new System.Windows.Forms.TabPage();
            this.dataGrid = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tabCom = new System.Windows.Forms.TabPage();
            this.dataGridCom = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle4 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tabIptc = new System.Windows.Forms.TabPage();
            this.dataGridIptc = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tabTiff = new System.Windows.Forms.TabPage();
            this.dataGridTiff = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tabXmp = new System.Windows.Forms.TabPage();
            this.textXmp = new System.Windows.Forms.TextBox();
            this.panelImageBorder = new System.Windows.Forms.Panel();
            this.thumbnailView = new Atalasoft.Imaging.WinControls.ImageViewer();
            this.lblImageInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabExif.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.tabCom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCom)).BeginInit();
            this.tabIptc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIptc)).BeginInit();
            this.tabTiff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTiff)).BeginInit();
            this.tabXmp.SuspendLayout();
            this.panelImageBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFile,
            this.menuItem1,
            this.menuItem6});
            // 
            // menuFile
            // 
            this.menuFile.Index = 0;
            this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuOpen,
            this.menuSave,
            this.menuItem4,
            this.menuExit});
            this.menuFile.Text = "&File";
            // 
            // menuOpen
            // 
            this.menuOpen.Index = 0;
            this.menuOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuOpen.Text = "&Open...";
            this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
            // 
            // menuSave
            // 
            this.menuSave.Index = 1;
            this.menuSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.menuSave.Text = "&Save As...";
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "-";
            // 
            // menuExit
            // 
            this.menuExit.Index = 3;
            this.menuExit.Text = "E&xit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuCom,
            this.menuIptc,
            this.menuTiff,
            this.menuExif});
            this.menuItem1.Text = "&Modify";
            // 
            // menuCom
            // 
            this.menuCom.Index = 0;
            this.menuCom.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuComClear,
            this.menuItem12,
            this.menuComAdd,
            this.menuComRemove});
            this.menuCom.Text = "COM";
            // 
            // menuComClear
            // 
            this.menuComClear.Index = 0;
            this.menuComClear.Text = "Clear";
            this.menuComClear.Click += new System.EventHandler(this.menuComClear_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 1;
            this.menuItem12.Text = "-";
            // 
            // menuComAdd
            // 
            this.menuComAdd.Index = 2;
            this.menuComAdd.Text = "Add...";
            this.menuComAdd.Click += new System.EventHandler(this.menuComAdd_Click);
            // 
            // menuComRemove
            // 
            this.menuComRemove.Index = 3;
            this.menuComRemove.Text = "Remove Selected";
            this.menuComRemove.Click += new System.EventHandler(this.menuComRemove_Click);
            // 
            // menuIptc
            // 
            this.menuIptc.Index = 1;
            this.menuIptc.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuIptcClear,
            this.menuItem3,
            this.menuIptcAdd,
            this.mnuIptcRemove});
            this.menuIptc.Text = "&IPTC";
            // 
            // menuIptcClear
            // 
            this.menuIptcClear.Index = 0;
            this.menuIptcClear.Text = "Clear";
            this.menuIptcClear.Click += new System.EventHandler(this.menuIptcClear_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "-";
            // 
            // menuIptcAdd
            // 
            this.menuIptcAdd.Index = 2;
            this.menuIptcAdd.Text = "Add...";
            this.menuIptcAdd.Click += new System.EventHandler(this.menuIptcAdd_Click);
            // 
            // mnuIptcRemove
            // 
            this.mnuIptcRemove.Index = 3;
            this.mnuIptcRemove.Text = "Remove  Selected";
            this.mnuIptcRemove.Click += new System.EventHandler(this.mnuIptcRemove_Click);
            // 
            // menuTiff
            // 
            this.menuTiff.Index = 2;
            this.menuTiff.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuTiffClear,
            this.menuItem13,
            this.menuTiffNothing,
            this.menuTiffRemove,
            this.menuTiffViewBinary});
            this.menuTiff.Text = "&TIFF";
            // 
            // menuTiffClear
            // 
            this.menuTiffClear.Index = 0;
            this.menuTiffClear.Text = "Clear";
            this.menuTiffClear.Click += new System.EventHandler(this.menuTiffClear_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 1;
            this.menuItem13.Text = "-";
            // 
            // menuTiffNothing
            // 
            this.menuTiffNothing.Index = 2;
            this.menuTiffNothing.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuTiffAdd,
            this.menuAddTagAscii});
            this.menuTiffNothing.Text = "Add";
            // 
            // menuTiffAdd
            // 
            this.menuTiffAdd.Index = 0;
            this.menuTiffAdd.Text = "Image (Binary)...";
            this.menuTiffAdd.Click += new System.EventHandler(this.menuTiffAdd_Click);
            // 
            // menuAddTagAscii
            // 
            this.menuAddTagAscii.Index = 1;
            this.menuAddTagAscii.Text = "ASCII...";
            this.menuAddTagAscii.Click += new System.EventHandler(this.menuTiffAdd_Click);
            // 
            // menuTiffRemove
            // 
            this.menuTiffRemove.Index = 3;
            this.menuTiffRemove.Text = "Remove Selected";
            this.menuTiffRemove.Click += new System.EventHandler(this.menuTiffRemove_Click);
            // 
            // menuTiffViewBinary
            // 
            this.menuTiffViewBinary.Index = 4;
            this.menuTiffViewBinary.Text = "View Binary Image Tag";
            this.menuTiffViewBinary.Click += new System.EventHandler(this.menuTiffViewBinary_Click);
            // 
            // menuExif
            // 
            this.menuExif.Index = 3;
            this.menuExif.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuExifClear,
            this.menuItem9,
            this.menuExifAdd,
            this.menuExifRemove,
            this.menuItem2,
            this.menuAddThumb});
            this.menuExif.Text = "&EXIF";
            // 
            // menuExifClear
            // 
            this.menuExifClear.Index = 0;
            this.menuExifClear.Text = "Clear";
            this.menuExifClear.Click += new System.EventHandler(this.menuExifClear_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 1;
            this.menuItem9.Text = "-";
            // 
            // menuExifAdd
            // 
            this.menuExifAdd.Index = 2;
            this.menuExifAdd.Text = "Add...";
            this.menuExifAdd.Click += new System.EventHandler(this.menuExifAdd_Click);
            // 
            // menuExifRemove
            // 
            this.menuExifRemove.Index = 3;
            this.menuExifRemove.Text = "Remove Selected";
            this.menuExifRemove.Click += new System.EventHandler(this.menuExifRemove_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 4;
            this.menuItem2.Text = "-";
            // 
            // menuAddThumb
            // 
            this.menuAddThumb.Index = 5;
            this.menuAddThumb.Text = "Add Thumbnail...";
            this.menuAddThumb.Click += new System.EventHandler(this.menuAddThumb_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 2;
            this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuAbout});
            this.menuItem6.Text = "&Help";
            // 
            // menuAbout
            // 
            this.menuAbout.Index = 0;
            this.menuAbout.Text = "About ...";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabExif);
            this.tabControl1.Controls.Add(this.tabCom);
            this.tabControl1.Controls.Add(this.tabIptc);
            this.tabControl1.Controls.Add(this.tabTiff);
            this.tabControl1.Controls.Add(this.tabXmp);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(777, 433);
            this.tabControl1.TabIndex = 0;
            // 
            // tabExif
            // 
            this.tabExif.Controls.Add(this.dataGrid);
            this.tabExif.Location = new System.Drawing.Point(4, 22);
            this.tabExif.Name = "tabExif";
            this.tabExif.Size = new System.Drawing.Size(769, 407);
            this.tabExif.TabIndex = 0;
            this.tabExif.Text = "EXIF";
            // 
            // dataGrid
            // 
            this.dataGrid.AlternatingBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid.BackColor = System.Drawing.Color.Silver;
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataGrid.CaptionBackColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGrid.CaptionFont = new System.Drawing.Font("Tahoma", 8F);
            this.dataGrid.CaptionForeColor = System.Drawing.Color.White;
            this.dataGrid.DataMember = "";
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.FlatMode = true;
            this.dataGrid.ForeColor = System.Drawing.Color.Black;
            this.dataGrid.GridLineColor = System.Drawing.Color.White;
            this.dataGrid.HeaderBackColor = System.Drawing.Color.DarkGray;
            this.dataGrid.HeaderForeColor = System.Drawing.Color.Black;
            this.dataGrid.LinkColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ParentRowsBackColor = System.Drawing.Color.Black;
            this.dataGrid.ParentRowsForeColor = System.Drawing.Color.White;
            this.dataGrid.SelectionBackColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGrid.SelectionForeColor = System.Drawing.Color.White;
            this.dataGrid.Size = new System.Drawing.Size(769, 407);
            this.dataGrid.TabIndex = 1;
            this.dataGrid.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.DataGrid = this.dataGrid;
            this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn10});
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle3.MappingName = "ExifTagExtendedCollection";
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "ID";
            this.dataGridTextBoxColumn5.MappingName = "ID";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 50;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "Description";
            this.dataGridTextBoxColumn9.MappingName = "Description";
            this.dataGridTextBoxColumn9.ReadOnly = true;
            this.dataGridTextBoxColumn9.Width = 225;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "IFD";
            this.dataGridTextBoxColumn11.MappingName = "Ifd";
            this.dataGridTextBoxColumn11.ReadOnly = true;
            this.dataGridTextBoxColumn11.Width = 110;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "Type";
            this.dataGridTextBoxColumn12.MappingName = "Type";
            this.dataGridTextBoxColumn12.ReadOnly = true;
            this.dataGridTextBoxColumn12.Width = 75;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "Data";
            this.dataGridTextBoxColumn10.MappingName = "DataString";
            this.dataGridTextBoxColumn10.Width = 250;
            // 
            // tabCom
            // 
            this.tabCom.Controls.Add(this.dataGridCom);
            this.tabCom.Location = new System.Drawing.Point(4, 22);
            this.tabCom.Name = "tabCom";
            this.tabCom.Size = new System.Drawing.Size(761, 407);
            this.tabCom.TabIndex = 2;
            this.tabCom.Text = "COM";
            // 
            // dataGridCom
            // 
            this.dataGridCom.AlternatingBackColor = System.Drawing.Color.Gainsboro;
            this.dataGridCom.BackColor = System.Drawing.Color.Silver;
            this.dataGridCom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataGridCom.CaptionBackColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGridCom.CaptionFont = new System.Drawing.Font("Tahoma", 8F);
            this.dataGridCom.CaptionForeColor = System.Drawing.Color.White;
            this.dataGridCom.DataMember = "";
            this.dataGridCom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridCom.FlatMode = true;
            this.dataGridCom.ForeColor = System.Drawing.Color.Black;
            this.dataGridCom.GridLineColor = System.Drawing.Color.White;
            this.dataGridCom.HeaderBackColor = System.Drawing.Color.DarkGray;
            this.dataGridCom.HeaderForeColor = System.Drawing.Color.Black;
            this.dataGridCom.LinkColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGridCom.Location = new System.Drawing.Point(0, 0);
            this.dataGridCom.Name = "dataGridCom";
            this.dataGridCom.ParentRowsBackColor = System.Drawing.Color.Black;
            this.dataGridCom.ParentRowsForeColor = System.Drawing.Color.White;
            this.dataGridCom.SelectionBackColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGridCom.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridCom.Size = new System.Drawing.Size(761, 407);
            this.dataGridCom.TabIndex = 2;
            this.dataGridCom.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle4});
            // 
            // dataGridTableStyle4
            // 
            this.dataGridTableStyle4.DataGrid = this.dataGridCom;
            this.dataGridTableStyle4.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn14});
            this.dataGridTableStyle4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle4.MappingName = "ComTextCollection";
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "Key (PNG Only)";
            this.dataGridTextBoxColumn13.MappingName = "Key";
            this.dataGridTextBoxColumn13.Width = 75;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "Text";
            this.dataGridTextBoxColumn14.MappingName = "Text";
            this.dataGridTextBoxColumn14.Width = 300;
            // 
            // tabIptc
            // 
            this.tabIptc.Controls.Add(this.dataGridIptc);
            this.tabIptc.Location = new System.Drawing.Point(4, 22);
            this.tabIptc.Name = "tabIptc";
            this.tabIptc.Size = new System.Drawing.Size(761, 407);
            this.tabIptc.TabIndex = 1;
            this.tabIptc.Text = "IPTC";
            // 
            // dataGridIptc
            // 
            this.dataGridIptc.AlternatingBackColor = System.Drawing.Color.Gainsboro;
            this.dataGridIptc.BackColor = System.Drawing.Color.Silver;
            this.dataGridIptc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataGridIptc.CaptionBackColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGridIptc.CaptionFont = new System.Drawing.Font("Tahoma", 8F);
            this.dataGridIptc.CaptionForeColor = System.Drawing.Color.White;
            this.dataGridIptc.DataMember = "";
            this.dataGridIptc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridIptc.FlatMode = true;
            this.dataGridIptc.ForeColor = System.Drawing.Color.Black;
            this.dataGridIptc.GridLineColor = System.Drawing.Color.White;
            this.dataGridIptc.HeaderBackColor = System.Drawing.Color.DarkGray;
            this.dataGridIptc.HeaderForeColor = System.Drawing.Color.Black;
            this.dataGridIptc.LinkColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGridIptc.Location = new System.Drawing.Point(0, 0);
            this.dataGridIptc.Name = "dataGridIptc";
            this.dataGridIptc.ParentRowsBackColor = System.Drawing.Color.Black;
            this.dataGridIptc.ParentRowsForeColor = System.Drawing.Color.White;
            this.dataGridIptc.SelectionBackColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGridIptc.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridIptc.Size = new System.Drawing.Size(761, 407);
            this.dataGridIptc.TabIndex = 3;
            this.dataGridIptc.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dataGridIptc;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "IptcCollection";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "ID";
            this.dataGridTextBoxColumn1.MappingName = "ID";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 75;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Section";
            this.dataGridTextBoxColumn2.MappingName = "Section";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 75;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Index";
            this.dataGridTextBoxColumn3.MappingName = "Index";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Data";
            this.dataGridTextBoxColumn4.MappingName = "Data";
            this.dataGridTextBoxColumn4.Width = 250;
            // 
            // tabTiff
            // 
            this.tabTiff.Controls.Add(this.dataGridTiff);
            this.tabTiff.Location = new System.Drawing.Point(4, 22);
            this.tabTiff.Name = "tabTiff";
            this.tabTiff.Size = new System.Drawing.Size(761, 407);
            this.tabTiff.TabIndex = 3;
            this.tabTiff.Text = "TIFF";
            // 
            // dataGridTiff
            // 
            this.dataGridTiff.AlternatingBackColor = System.Drawing.Color.Gainsboro;
            this.dataGridTiff.BackColor = System.Drawing.Color.Silver;
            this.dataGridTiff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataGridTiff.CaptionBackColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGridTiff.CaptionFont = new System.Drawing.Font("Tahoma", 8F);
            this.dataGridTiff.CaptionForeColor = System.Drawing.Color.White;
            this.dataGridTiff.DataMember = "";
            this.dataGridTiff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridTiff.FlatMode = true;
            this.dataGridTiff.ForeColor = System.Drawing.Color.Black;
            this.dataGridTiff.GridLineColor = System.Drawing.Color.White;
            this.dataGridTiff.HeaderBackColor = System.Drawing.Color.DarkGray;
            this.dataGridTiff.HeaderForeColor = System.Drawing.Color.Black;
            this.dataGridTiff.LinkColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGridTiff.Location = new System.Drawing.Point(0, 0);
            this.dataGridTiff.Name = "dataGridTiff";
            this.dataGridTiff.ParentRowsBackColor = System.Drawing.Color.Black;
            this.dataGridTiff.ParentRowsForeColor = System.Drawing.Color.White;
            this.dataGridTiff.SelectionBackColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGridTiff.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridTiff.Size = new System.Drawing.Size(761, 407);
            this.dataGridTiff.TabIndex = 2;
            this.dataGridTiff.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.dataGridTiff;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.MappingName = "TiffTagExtendedCollection";
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "ID";
            this.dataGridTextBoxColumn6.MappingName = "TagDescription";
            this.dataGridTextBoxColumn6.ReadOnly = true;
            this.dataGridTextBoxColumn6.Width = 75;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "Type";
            this.dataGridTextBoxColumn7.MappingName = "Type";
            this.dataGridTextBoxColumn7.ReadOnly = true;
            this.dataGridTextBoxColumn7.Width = 75;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "Data";
            this.dataGridTextBoxColumn8.MappingName = "DataString";
            this.dataGridTextBoxColumn8.Width = 250;
            // 
            // tabXmp
            // 
            this.tabXmp.Controls.Add(this.textXmp);
            this.tabXmp.Location = new System.Drawing.Point(4, 22);
            this.tabXmp.Name = "tabXmp";
            this.tabXmp.Size = new System.Drawing.Size(761, 407);
            this.tabXmp.TabIndex = 4;
            this.tabXmp.Text = "XMP";
            // 
            // textXmp
            // 
            this.textXmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textXmp.Location = new System.Drawing.Point(0, 0);
            this.textXmp.Multiline = true;
            this.textXmp.Name = "textXmp";
            this.textXmp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textXmp.Size = new System.Drawing.Size(761, 407);
            this.textXmp.TabIndex = 0;
            // 
            // panelImageBorder
            // 
            this.panelImageBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelImageBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelImageBorder.Controls.Add(this.thumbnailView);
            this.panelImageBorder.Location = new System.Drawing.Point(785, 24);
            this.panelImageBorder.Name = "panelImageBorder";
            this.panelImageBorder.Size = new System.Drawing.Size(200, 224);
            this.panelImageBorder.TabIndex = 1;
            // 
            // thumbnailView
            // 
            this.thumbnailView.AntialiasDisplay = Atalasoft.Imaging.WinControls.AntialiasDisplayMode.ReductionOnly;
            this.thumbnailView.BackColor = System.Drawing.Color.White;
            this.thumbnailView.Centered = true;
            this.thumbnailView.DisplayProfile = null;
            this.thumbnailView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thumbnailView.Location = new System.Drawing.Point(0, 0);
            this.thumbnailView.Magnifier.BackColor = System.Drawing.Color.White;
            this.thumbnailView.Magnifier.BorderColor = System.Drawing.Color.Black;
            this.thumbnailView.Magnifier.Size = new System.Drawing.Size(100, 100);
            this.thumbnailView.Name = "thumbnailView";
            this.thumbnailView.OutputProfile = null;
            this.thumbnailView.Selection = null;
            this.thumbnailView.Size = new System.Drawing.Size(198, 222);
            this.thumbnailView.TabIndex = 4;
            // 
            // lblImageInfo
            // 
            this.lblImageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImageInfo.Location = new System.Drawing.Point(793, 264);
            this.lblImageInfo.Name = "lblImageInfo";
            this.lblImageInfo.Size = new System.Drawing.Size(184, 112);
            this.lblImageInfo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(785, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Embedded Thumbnail";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(993, 433);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblImageInfo);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelImageBorder);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Atalasoft dotImage Metadata Demo";
            this.tabControl1.ResumeLayout(false);
            this.tabExif.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.tabCom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCom)).EndInit();
            this.tabIptc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIptc)).EndInit();
            this.tabTiff.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTiff)).EndInit();
            this.tabXmp.ResumeLayout(false);
            this.tabXmp.PerformLayout();
            this.panelImageBorder.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void menuOpen_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = HelperMethods.CreateDialogFilter(true);
			
			// try to locate images folder
			string imagesFolder = Application.ExecutablePath;
			// we assume we are running under the DotImage install folder
			int pos = imagesFolder.IndexOf("DotImage ");
			if (pos != -1)
			{
				imagesFolder = imagesFolder.Substring(0,imagesFolder.IndexOf(@"\",pos)) + @"\Images";
			}

			//use this folder as starting point			
			openFile.InitialDirectory = imagesFolder;

			// Load the image metadata information from the file.
			if (openFile.ShowDialog() == DialogResult.OK) 
			{

				//set the last filename field
				this._lastFileName = openFile.FileName;

                // start lengthy operation
                this.Cursor = Cursors.WaitCursor;
                Application.UseWaitCursor = true;
                Application.DoEvents();

                try
                {

                    //get image information without loading the image
                    RegisteredDecoders.Decoders.Insert(0, new RawDecoder());
                    ImageInfo info = RegisteredDecoders.GetImageInfo(openFile.FileName);

                    //display the image information
                    this.lblImageInfo.Text = System.IO.Path.GetFileName(openFile.FileName) + "\n" +
                        info.Size.Width.ToString() + " x " + info.Size.Height.ToString() + " pixels\n" +
                        info.ColorDepth.ToString() + " bpp";

                    //clear the image
                    this.thumbnailView.Image = null;

                    // Load the data.
                    LoadControls(openFile.FileName);
                    // Display full file path in title bar:
                    this.Text = "Metadata from " + openFile.FileName;

                }
                finally
                {
                    Application.UseWaitCursor = false;
                    this.Cursor = Cursors.Default;
                }
            }

			openFile.Dispose();
			
		}

        private static TiffTag GetTagWithId(int id, TiffTagCollection col)
        {
            foreach (TiffTag tag in col)
            {
                if (tag.ID == id)
                    return tag;
            }
            return null;
        }

		private static bool AreTiffTagsDataEqual(TiffTag tag1, TiffTag tag2)
		{
			if (tag1 == null || tag2 == null)
				return false;
			if (tag1.ID != tag2.ID)
				return false;
			if (tag1.Type != tag2.Type)
				return false;
			if (!tag1.Data.Equals(tag2.Data))
				return false;

			return true;
		}

		private static void MergeTagInto(TiffTag tag, TiffTagCollection col)
		{
			TiffTag foundTag = GetTagWithId(tag.ID, col);
			if (!AreTiffTagsDataEqual(tag, foundTag))
			{
				if (foundTag != null)
					col.Remove(foundTag);
				col.Add(tag);
			}
		}


		private void menuSave_Click(object sender, System.EventArgs e)
		{
			// Make sure there is something to save.
			if (_tiffTags == null && _comTags == null && _iptcTags == null && _exifTags == null) 
			{
				MessageBox.Show("There is no metadata to save.");
				return;
			}
			
			SaveFileDialog saveFile = new SaveFileDialog();
			saveFile.Filter = "JPEG Image|*.jpg|PNG Image|*.png|TIFF Image|*.tif";
			saveFile.AddExtension = true;
			
			if (saveFile.ShowDialog() == DialogResult.OK) 
			{

				//if the source image is a JPEG, then get all the JPEG APP Markers
				JpegMarkerCollection markers = null;
				if (System.IO.Path.GetExtension(_lastFileName) == ".jpg")
				{
					markers = new JpegMarkerCollection(_lastFileName);
				}

				switch(saveFile.FilterIndex) 
				{
					case 1:
						// JPG
						JpegEncoder jpg = new JpegEncoder();
						//Add IPTC Data
						jpg.IptcTags = _iptcTags;
						//Add COM Text Blocks
						jpg.ComText = _comTags;
						//Add EXIF Data
						if (markers != null)
						{
							//if the original image has an APP1 JPEG Marker, then remove it (we don't need 2 copies of the EXIF data)
							foreach (JpegMarker mark in markers)
							{
								if (mark.Type == JpegMarkerTypes.MarkerApp1)
								{
									markers.Remove(mark);
									break;
								}
							}
						}
						//save all the original metadata in the jpeg (with the exception of EXIF we just removed)
						jpg.AppMarkers = markers;
						//EXIF is almost always stored in the APP1 JPEG Marker
						if (_exifTags != null)
						{
							if (jpg.AppMarkers == null)
								jpg.AppMarkers = new JpegMarkerCollection();
							jpg.AppMarkers.Add(new JpegMarker(JpegMarkerTypes.MarkerApp1, _exifTags.ToExifCollection().ToByteArray()));
						}
						if (textXmp.Text.Length > 0)
							jpg.Xmp = System.Text.Encoding.ASCII.GetBytes(textXmp.Text); 

						if (markers != null)
						{
							//save metadata with original compressed JPEG image to prevent introducing lossy artifacts!!
							jpg.CopyJpegWithNewMarkers(_lastFileName, saveFile.FileName);
						}
						else
						{
							//original image was not a JPEG, we need to decode the image file
							AtalaImage jpegImage = new AtalaImage(_lastFileName);
							jpegImage.Save(saveFile.FileName, jpg, null);
							jpegImage.Dispose();
						}
						break;
						
					case 2:
						// PNG ( only COM text can be saved to PNG )
						//load the image
						AtalaImage pngImage = new AtalaImage(_lastFileName);
						PngEncoder png = new PngEncoder();
						png.ComText = _comTags; 
						pngImage.Save(saveFile.FileName, new PngEncoder(), null);
						pngImage.Dispose();
						break;

					case 3:
						//TIFF
						if (_lastFileName == saveFile.FileName)
						{
							MessageBox.Show("Cannot overwrite existing TIFF file in this demo");
						}

						//Save new TiffTags
						FileStream fs = new FileStream(this._lastFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
						FileStream ofs = new FileStream(saveFile.FileName, FileMode.Create, FileAccess.Write, FileShare.Write);

						TiffFile theFile;
						if (System.IO.Path.GetExtension(_lastFileName) == ".tif")
						{
							theFile = new TiffFile();
							theFile.Read(fs);
						}
						else
						{
							theFile = new TiffFile();
							theFile.Images.Add(new TiffDirectory(new AtalaImage(_lastFileName), TiffCompression.Lzw));
						}
						TiffDirectory theImg = theFile.Images[0];
						if (_exifTags != null)
							theImg.ExifTags = _exifTags.ToExifCollection();
						//save IPTC Tags to the RichTextIPTC tag
						if (_iptcTags != null && _iptcTags.Count > 0)
						{
							//save IPTC to the RichTIFFIPTC TIFF Tag, 33723
							if (_tiffTags == null)
								_tiffTags = new TiffTagExtendedCollection(new TiffTagCollection());
							_tiffTags.Add(new TiffTagExtended(new TiffTag(33723, _iptcTags.CreateIptcDataBlock(), TiffTagDataType.Byte)));
							//remove any photoshop resources, as it can cause confusion for IPTC readers.  
							foreach (TiffTagExtended tag in _tiffTags)
							{
								if (tag.ID == (int)TiffTagID.Photoshop)
								{
									_tiffTags.Remove(tag);
									break;
								}
							}
						}
						//save XMP data to the 
						if (this.textXmp.Text.Length > 0)
						{
							_tiffTags.Add(new TiffTagExtended(new TiffTag(700, System.Text.Encoding.ASCII.GetBytes(textXmp.Text), TiffTagDataType.Byte)));
						}

						//add the TIFF Tags back into the collection in case any changes have been made
						if (_tiffTags != null)
						{
							foreach (TiffTag tt in _tiffTags)
							{
                                MergeTagInto(tt, theImg.Tags);
							}
						}
						theFile.Save(ofs);
						fs.Close();
						ofs.Close();
						break;
				}						
			}			
			saveFile.Dispose();
		}

		/// <summary>
		/// Clear all data from the form controls.
		/// </summary>
		private void LoadControls(string fileName)
		{
			this.tabControl1.TabPages.Remove(tabExif);
			this.tabControl1.TabPages.Remove(tabIptc);
			this.tabControl1.TabPages.Remove(tabTiff);
			this.tabControl1.TabPages.Remove(tabCom);
			this.tabControl1.TabPages.Remove(tabXmp);

			if (_exifTags != null)
				_exifTags.Clear();
			if (_iptcTags != null)
				_iptcTags.Clear();
			if (_comTags != null)
				_comTags.Clear();
			if (_tiffTags != null)
				_tiffTags.Clear();

			FileStream st = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
			ImageDecoder dec = RegisteredDecoders.GetDecoder(st);


			Type tp = dec.GetType();

			ExifParser exifParse = new ExifParser();
			ExifCollection tempTags = exifParse.ParseFromImage(fileName);
			if (tempTags != null && tempTags.Count > 0)
			{
				if (tempTags.ThumbnailStream != null)
				{
					this.thumbnailView.Image = new AtalaImage(tempTags.ThumbnailStream, null);
					tempTags.ThumbnailStream.Seek(0, SeekOrigin.Begin);
				}
				this.tabControl1.TabPages.Add(tabExif);
				//loop through each tag and replace the data with the string representation if it's an array (for display purposes)
				_exifTags = new ExifTagExtendedCollection(tempTags);
				dataGrid.DataSource = _exifTags;
			}

	
			IptcParser iptcParse = new IptcParser();
			_iptcTags = iptcParse.ParseFromImage(fileName);
			if (_iptcTags != null && _iptcTags.Count > 0)
			{
				this.tabControl1.TabPages.Add(tabIptc);
				dataGridIptc.DataSource = _iptcTags;
			}
			
			if (tp == typeof(TiffDecoder))
			{
				this.tabControl1.TabPages.Add(tabTiff);
				TiffFile tifffile = new TiffFile();
				tifffile.CodecError += new CodecErrorEventHandler(tifffile_CodecError);
				using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					tifffile.Read(fs);
			
					TiffDirectory tiffImg = tifffile.Images[0];
					_tiffTags = new TiffTagExtendedCollection(tiffImg.Tags); 

					dataGridTiff.DataSource = _tiffTags;
				}
			}

			ComTextParser ComParse = new ComTextParser();
			_comTags = ComParse.ParseFromImage(fileName);
			if (_comTags != null && _comTags.Count > 0)
			{
				this.tabControl1.TabPages.Add(tabCom);
				dataGridCom.DataSource = _comTags;
			}

			XmpParser xmpParse = new XmpParser();
			System.Xml.XmlDocument xml = (System.Xml.XmlDocument)xmpParse.ParseFromImage(fileName);
			if (xml != null)
			{
				this.tabControl1.TabPages.Add(tabXmp);
				StringWriter sw = new StringWriter();
				System.Xml.XmlTextWriter xmlWrite = new System.Xml.XmlTextWriter(sw);
				xmlWrite.Formatting = System.Xml.Formatting.Indented;
				xml.WriteContentTo(xmlWrite);
				this.textXmp.Text = sw.ToString();
			}
			else
				this.textXmp.Text = "";
		
		}

		private void menuAbout_Click(object sender, System.EventArgs e)
		{
			AtalaDemos.AboutBox.About aboutBox = new AtalaDemos.AboutBox.About("About Atalasoft DotImage Metadata Demo",
				"DotImage Metadata Demo");
			aboutBox.Description = @"Demonstrates how to view, edit, and save metadata in image JPEG, TIFF, RAW, and PNG image files.  It includes code that preserves as much metadata as possible when re-saving an image as a TIFF or JPEG.  The TiffFile class gives the ability to view and edit tiff image metadata without the need to open the image into memory and demonstrates working with arbitrary TIFF tags by embedding an image into the tiff tag.  Also demonstrates lossless JPEG features to edit metadata within a JPEG without adding lossy compression artifacts.  These features requires a license of DotImage Photo Pro.";
			aboutBox.ShowDialog();
		}

		private void menuExit_Click(object sender, System.EventArgs e)
		{
			// Exit
			this.Close();
		}


		#region Com code
		
		private void menuComClear_Click(object sender, System.EventArgs e)
		{
			this.tabControl1.TabPages.Remove(tabCom);
			if (_comTags == null) return;
			_comTags.Clear();
			dataGridCom.DataSource = null;
			dataGridCom.DataSource = _comTags;
		}

		private void menuComAdd_Click(object sender, System.EventArgs e)
		{
			// Also make sure the ComTextCollection has been created.
			if (_comTags == null || _comTags.Count == 0)
			{
				_comTags = new ComTextCollection();
				this.tabControl1.TabPages.Add(tabCom);
			}
			
			ComTextTag tag = new ComTextTag();
			MetadataEdit edit = new MetadataEdit();
			edit.LoadObject(tag);
			
			if (edit.ShowDialog() == DialogResult.OK) 
			{
				// Add the tag to the collection and listview.
				_comTags.Add(tag);
			}
			
			edit.Dispose();

			dataGridCom.DataSource = null;
			dataGridCom.DataSource = _comTags;
		}

		private void menuComRemove_Click(object sender, System.EventArgs e)
		{
			if (_comTags == null) return;
			if (dataGridCom.CurrentRowIndex == -1) return;

			// Remove it from the collection.
			_comTags.RemoveAt(dataGridCom.CurrentRowIndex);
			dataGridCom.DataSource = null;
			dataGridCom.DataSource = _comTags;
		}
		
		#endregion
		
		#region Iptc Code
		
		private void menuIptcAdd_Click(object sender, System.EventArgs e)
		{
			
			// Also make sure the IptcCollection has been created.
			if (_iptcTags == null || _iptcTags.Count == 0)
			{
				_iptcTags = new IptcCollection();
				this.tabControl1.TabPages.Add(tabIptc);
			}
			
			IptcTag tag = new IptcTag(2, 0, 0, "");
			MetadataEdit edit = new MetadataEdit();
			edit.LoadObject(tag);
			
			if (edit.ShowDialog() == DialogResult.OK) 
			{
				// Add the tag to the collection and listview.
				_iptcTags.Add(tag);
			}
			
			edit.Dispose();

			dataGridIptc.DataSource = null;
			dataGridIptc.DataSource = _iptcTags;
		}
		private void mnuIptcRemove_Click(object sender, System.EventArgs e)
		{
			if (dataGridIptc.CurrentRowIndex > -1)
			{
				_iptcTags.RemoveAt(dataGridIptc.CurrentRowIndex);
				dataGridIptc.DataSource = null;
				dataGridIptc.DataSource = _iptcTags;
			}

			
		}

		private void menuIptcClear_Click(object sender, System.EventArgs e)
		{
			this.tabControl1.TabPages.Remove(tabIptc);
			_iptcTags.Clear();
			dataGridIptc.DataSource = null;
			dataGridIptc.DataSource = _iptcTags;
		}

		#endregion		
		
		#region TIFF Code
		
		private void menuTiffClear_Click(object sender, System.EventArgs e)
		{
			this.tabControl1.TabPages.Remove(tabTiff);
			if (_tiffTags != null)
				_tiffTags.Clear();
			dataGridTiff.DataSource = null;
			dataGridTiff.DataSource = _tiffTags;
		}
		

		private void menuTiffRemove_Click(object sender, System.EventArgs e)
		{	
			if (_tiffTags == null || dataGridTiff.CurrentRowIndex == -1) return;

			// Remove from the listview
			_tiffTags.RemoveAt(dataGridTiff.CurrentRowIndex);
			dataGridTiff.DataSource = null;
			dataGridTiff.DataSource = _tiffTags;

		}


		private void menuTiffAdd_Click(object sender, System.EventArgs e)
		{
			if (_tiffTags == null) 
			{
				_tiffTags = new TiffTagExtendedCollection(new TiffTagCollection());
				this.tabControl1.TabPages.Add(tabTiff);
			}

			// Display custom tag dialog
			CustomTag ct = new CustomTag();
			MenuItem mnu = (MenuItem)sender;
			
			if (mnu.Text == "Image (Binary)")
			{
				ct.Label = "Browse for Image";
				ct.BrowseVisible = true;
			}
			else
			{
				ct.Label = "Tag Data";
				ct.BrowseVisible = false;
			}

			TiffTag tag;
			if (ct.ShowDialog() == DialogResult.OK)
			{	
				int tagID = int.Parse(ct.ID.Text);

				if (mnu.Text == "Image (Binary)")
				{
					// encode image data to be temporarily stored in list view.
					tag = new TiffTag(tagID, new AtalaImage(ct.Data.Text).ToByteArray(new BmpEncoder()),TiffTagDataType.Byte);
					//add to tiff tag collection
				}
				else
				{
					tag = new TiffTag(tagID, ct.Data.Text, TiffTagDataType.Ascii);
				}
				_tiffTags.Add(new TiffTagExtended(tag));
			}
			ct.Dispose();

			dataGridTiff.DataSource = null;
			dataGridTiff.DataSource = _tiffTags;

		}

		private void menuTiffViewBinary_Click(object sender, System.EventArgs e)
		{
			// If the TiffTag is image data encoded as 64bitString, then display it.
			try
			{
				AtalaImage img = AtalaImage.FromByteArray((byte[])_tiffTags[dataGridTiff.CurrentRowIndex].Data, null);
				
				//display the image in a new window
				PicView pv = new PicView(img);
				pv.ShowDialog();
				pv.Dispose();
			}
			catch(Exception)
			{
				MessageBox.Show("Error reading binary image");
			}
		}

		
		private void tifffile_CodecError(object sender, CodecErrorEventArgs e)
		{
			MessageBox.Show(this, e.Description, "TIFF File Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
				
		#endregion

		#region EXIF Code

		private void menuExifClear_Click(object sender, System.EventArgs e)
		{
			this.tabControl1.TabPages.Remove(tabExif);
			_exifTags = null;
			dataGrid.DataSource = null;
			dataGrid.DataSource = _exifTags;
		}

		private void menuExifRemove_Click(object sender, System.EventArgs e)
		{
			if (_exifTags == null || dataGrid.CurrentRowIndex == -1) return;

			// Remove from the listview
			_exifTags.RemoveAt(dataGrid.CurrentRowIndex);
			dataGridTiff.DataSource = null;
			dataGridTiff.DataSource = _exifTags;
		}

		private void menuExifAdd_Click(object sender, System.EventArgs e)
		{
			if (_exifTags == null) 
			{
				_exifTags = new ExifTagExtendedCollection(new ExifCollection());
				this.tabControl1.TabPages.Add(tabExif);
			}

			// Display custom tag dialog
			CustomTag ct = new CustomTag();
			ct.cmbIFD.Visible = true;
			ct.lblIFD.Visible = true;
			ExifTag tag;
			if (ct.ShowDialog() == DialogResult.OK)
			{	
				int tagID = int.Parse(ct.ID.Text);
				tag = new ExifTag(tagID, (ExifTagIfd)Enum.Parse(typeof(ExifTagIfd), ct.cmbIFD.Text), ct.Data.Text, TiffTagDataType.Ascii);
				_exifTags.Add(new ExifTagExtended(tag));
					}
			ct.Dispose();

			dataGrid.DataSource = null;
			dataGrid.DataSource = _exifTags;
		}

		private void menuAddThumb_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog fd = new OpenFileDialog();
			if (fd.ShowDialog(this) == DialogResult.OK)
			{
				if (_exifTags == null)
					_exifTags = new ExifTagExtendedCollection();
				Atalasoft.Imaging.ImageProcessing.Thumbnail thumb = new Atalasoft.Imaging.ImageProcessing.Thumbnail(new Size(96, 96));
				AtalaImage img = thumb.Create(fd.FileName, 0);
				MemoryStream ms = new MemoryStream(img.ToByteArray(new JpegEncoder(), null));
				_exifTags.ThumbnailStream = ms;
				this.thumbnailView.Image = img;
			}

		}

#endregion

		#region Helper Classes
		//These helper classes let us display Array data.  Otherwise, the output is just System.Byte[], System.UInt32[], etc..
		public class ExifTagExtended : ExifTag
		{
			public ExifTagExtended(ExifTag tag) : base(tag.ID, tag.Ifd, tag.Data, tag.Type) 
			{
							
			}

			public string DataString
			{
				get
				{ 
					string data = "";
					if (base.Data.GetType().IsArray)
					{
						System.Array ar = (System.Array)base.Data;
						int maxlen = Convert.ToInt32(Math.Min(ar.Length, 8));
						for (int i = 0; i < maxlen; i++)
						{
							data += ar.GetValue(i).ToString();
							if (i != maxlen - 1)
								data += ", ";
						}
						if (ar.Length > 8)
							data += "...";
					}
					else
					{
						string dt = base.ToString();
						data = dt.Substring(dt.IndexOf(":", 0) + 2);
					}
					return data;
				}
				set
				{
					if (base.Data.GetType().IsArray)
					{
						throw new NotImplementedException("This demo does not implement editing of array tag items.");
					}
					else
					{
						base.Data = value;
					}
				}
			}
		}

		
		public class ExifTagExtendedCollection : CollectionBase
		{
			public ExifTagExtendedCollection()
			{
				_exifCol = new ExifCollection();
			}
			ExifCollection _exifCol = null;
			public ExifTagExtendedCollection(ExifCollection exifCol)
			{
				_exifCol = exifCol;
				foreach (ExifTag tag in exifCol)
				{
					base.InnerList.Add(new ExifTagExtended(tag));
				}
			}
			public ExifTagExtended this[int index]
			{
				get 
				{ 
					return (ExifTagExtended)base.InnerList[index]; 
				}
			}

			public void CopyTo(ExifTagExtended[] tags, int index)
			{
				for (int i = index; i < this.Count; i++)
					tags[i] = (ExifTagExtended)base.InnerList[i + index];
			}

			public void Add(ExifTagExtended tag)
			{
				base.InnerList.Add(tag);
			}

			public void Remove(ExifTagExtended tag)
			{
				base.InnerList.Remove(tag);
			}

			public int IndexOf(ExifTagExtended tag)
			{
				return base.InnerList.IndexOf(tag);
			}

			public void Insert(int index, ExifTagExtended source)
			{
				base.InnerList.Insert(index, source);
			}

			public bool Contains(ExifTagExtended source)
			{
				return base.InnerList.Contains(source);
			}

			public Stream ThumbnailStream
			{
				get { return _exifCol.ThumbnailStream; }
				set { _exifCol.ThumbnailStream = value; }
			}

			public ExifCollection ToExifCollection()
			{
				ExifCollection exif = new ExifCollection();
				foreach (ExifTagExtended tag in this)
				{
					exif.Add(tag);
				}
				exif.MakernoteHeader = _exifCol.MakernoteHeader;
				exif.ThumbnailStream = _exifCol.ThumbnailStream;
				return exif;
			}
		}

		public class TiffTagExtended : TiffTag
		{
			public TiffTagExtended(TiffTag tag) : base(tag.ID, tag.Data, tag.Type) 
			{
				
			}

			public string TagDescription
			{
				get 
				{ 
					//find english string from ID
					if (System.Enum.IsDefined(typeof(TiffTagID), base.ID))
						return ((TiffTagID)base.ID).ToString();
					else
						return base.ID.ToString();
				}
			}

			public string DataString
			{
				get
				{ 
					string data = "";
					if (base.Data.GetType().IsArray)
					{
						System.Array ar = (System.Array)base.Data;
						int maxlen = Convert.ToInt32(Math.Min(ar.Length, 8));
						for (int i = 0; i < maxlen; i++)
						{
							data += ar.GetValue(i).ToString();
							if (i != maxlen - 1)
								data += ", ";
						}
						if (ar.Length > 8)
							data += "...";
					}
					else
						data = base.Data.ToString();

					return data;
				}
				set
				{
					if (base.Data.GetType().IsArray)
					{
						throw new NotImplementedException("This demo does not implement editing of array tag items.");
					}
					else
					{
						base.Data = value;
					}
				}
			}

		}

		
		public class TiffTagExtendedCollection : CollectionBase
		{
			public TiffTagExtendedCollection()
			{
			}
			public TiffTagExtendedCollection(TiffTagCollection tags)
			{
				foreach (TiffTag tag in tags)
				{
					base.InnerList.Add(new TiffTagExtended(tag));
				}
			}

			public TiffTagExtended this[int index]
			{
				get 
				{ 
					return (TiffTagExtended)base.InnerList[index]; 
				}
			}

			public void CopyTo(TiffTagExtended[] tags, int index)
			{
				for (int i = index; i < this.Count; i++)
					tags[i] = (TiffTagExtended)base.InnerList[i + index];
			}

			public void Add(TiffTagExtended tag)
			{
				base.InnerList.Add(tag);
			}

			public void Remove(TiffTagExtended tag)
			{
				base.InnerList.Remove(tag);
			}

			public int IndexOf(TiffTagExtended tag)
			{
				return base.InnerList.IndexOf(tag);
			}

			public void Insert(int index, TiffTagExtended source)
			{
				base.InnerList.Insert(index, source);
			}

			public bool Contains(TiffTagExtended source)
			{
				return base.InnerList.Contains(source);
			}
		}
		#endregion

	}
}
