using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MetadataDemo
{
	/// <summary>
	/// Summary description for CustomTag.
	/// </summary>
	public class CustomTag : System.Windows.Forms.Form
	{
		public System.Windows.Forms.TextBox ID;
		public System.Windows.Forms.TextBox Data;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button OKbutton;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label lblData;
		private System.Windows.Forms.Button btnLoadImage;
		public System.Windows.Forms.ComboBox cmbIFD;
		public System.Windows.Forms.Label lblIFD;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CustomTag()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

	
			this.cmbIFD.DataSource = Enum.GetValues(typeof(Atalasoft.Imaging.Metadata.ExifTagIfd));

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.ID = new System.Windows.Forms.TextBox();
			this.Data = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblData = new System.Windows.Forms.Label();
			this.btnLoadImage = new System.Windows.Forms.Button();
			this.OKbutton = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.cmbIFD = new System.Windows.Forms.ComboBox();
			this.lblIFD = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// ID
			// 
			this.ID.Location = new System.Drawing.Point(88, 24);
			this.ID.Name = "ID";
			this.ID.Size = new System.Drawing.Size(184, 20);
			this.ID.TabIndex = 0;
			this.ID.Text = "";
			this.ID.Validating += new System.ComponentModel.CancelEventHandler(this.ID_Validating);
			// 
			// Data
			// 
			this.Data.Location = new System.Drawing.Point(88, 64);
			this.Data.Name = "Data";
			this.Data.Size = new System.Drawing.Size(320, 20);
			this.Data.TabIndex = 1;
			this.Data.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Tag ID:";
			// 
			// lblData
			// 
			this.lblData.AutoSize = true;
			this.lblData.Location = new System.Drawing.Point(16, 64);
			this.lblData.Name = "lblData";
			this.lblData.Size = new System.Drawing.Size(31, 16);
			this.lblData.TabIndex = 3;
			this.lblData.Text = "Data:";
			// 
			// btnLoadImage
			// 
			this.btnLoadImage.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnLoadImage.Location = new System.Drawing.Point(424, 64);
			this.btnLoadImage.Name = "btnLoadImage";
			this.btnLoadImage.TabIndex = 4;
			this.btnLoadImage.Text = "Browse ...";
			this.btnLoadImage.Visible = false;
			this.btnLoadImage.Click += new System.EventHandler(this.button1_Click);
			// 
			// OKbutton
			// 
			this.OKbutton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKbutton.Location = new System.Drawing.Point(128, 96);
			this.OKbutton.Name = "OKbutton";
			this.OKbutton.TabIndex = 5;
			this.OKbutton.Text = "OK";
			// 
			// CancelBtn
			// 
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(248, 96);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.TabIndex = 6;
			this.CancelBtn.Text = "Cancel";
			// 
			// cmbIFD
			// 
			this.cmbIFD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbIFD.Location = new System.Drawing.Point(336, 24);
			this.cmbIFD.Name = "cmbIFD";
			this.cmbIFD.Size = new System.Drawing.Size(121, 21);
			this.cmbIFD.TabIndex = 7;
			this.cmbIFD.Visible = false;
			// 
			// lblIFD
			// 
			this.lblIFD.AutoSize = true;
			this.lblIFD.Location = new System.Drawing.Point(304, 24);
			this.lblIFD.Name = "lblIFD";
			this.lblIFD.Size = new System.Drawing.Size(22, 16);
			this.lblIFD.TabIndex = 8;
			this.lblIFD.Text = "IFD";
			this.lblIFD.Visible = false;
			// 
			// CustomTag
			// 
			this.AcceptButton = this.OKbutton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(512, 134);
			this.Controls.Add(this.lblIFD);
			this.Controls.Add(this.cmbIFD);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKbutton);
			this.Controls.Add(this.btnLoadImage);
			this.Controls.Add(this.lblData);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Data);
			this.Controls.Add(this.ID);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CustomTag";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Create Custom Tag";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.CustomTag_Closing);
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				this.Data.Text = this.openFileDialog1.FileName;
				this.DialogResult = DialogResult.OK;
			}
		}

		private void CustomTag_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if ((this.Data.Text == "" || this.ID.Text == "") && this.DialogResult == DialogResult.OK)
				e.Cancel = true;
		}

		private void ID_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		}

		public string Label
		{
			get { return this.lblData.Text; }
			set { this.lblData.Text = value; }
		}

		public bool BrowseVisible
		{
			get { return this.btnLoadImage.Visible; }
			set { this.btnLoadImage.Visible = value; }
		}

	}
}
