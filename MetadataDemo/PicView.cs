using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MetadataDemo
{
	/// <summary>
	/// Summary description for PicView.
	/// </summary>
	public class PicView : System.Windows.Forms.Form
	{
		public Atalasoft.Imaging.WinControls.WorkspaceViewer workspaceViewer1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PicView(Atalasoft.Imaging.AtalaImage image)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.workspaceViewer1.Image = image;
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
			this.workspaceViewer1 = new Atalasoft.Imaging.WinControls.WorkspaceViewer();
			this.SuspendLayout();
			// 
			// workspaceViewer1
			// 
			this.workspaceViewer1.DisplayProfile = null;
			this.workspaceViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.workspaceViewer1.Location = new System.Drawing.Point(0, 0);
			this.workspaceViewer1.Magnifier.BackColor = System.Drawing.Color.White;
			this.workspaceViewer1.Magnifier.BorderColor = System.Drawing.Color.Black;
			this.workspaceViewer1.Magnifier.Size = new System.Drawing.Size(100, 100);
			this.workspaceViewer1.Name = "workspaceViewer1";
			this.workspaceViewer1.OutputProfile = null;
			this.workspaceViewer1.Selection = null;
			this.workspaceViewer1.Size = new System.Drawing.Size(292, 266);
			this.workspaceViewer1.TabIndex = 0;
			this.workspaceViewer1.Text = "workspaceViewer1";
			// 
			// PicView
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.workspaceViewer1);
			this.Name = "PicView";
			this.Text = "PicView";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
