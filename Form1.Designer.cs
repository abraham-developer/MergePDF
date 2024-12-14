using System.Drawing;
using System.Windows.Forms;

namespace MergePDF
{
    partial class Form1
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
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);


            // Create and configure folder selection button
            Button btnSelectFolder = new Button();
            btnSelectFolder.Text = "Select Folder";
            btnSelectFolder.Location = new Point(20, 20);
            btnSelectFolder.Size = new Size(120, 30);
            btnSelectFolder.Click += BtnSelectFolder_Click;

            // Create and configure merge button
            Button btnMerge = new Button();
            btnMerge.Text = "Merge PDFs";
            btnMerge.Location = new Point(160, 20);
            btnMerge.Size = new Size(120, 30);
            btnMerge.Click += BtnMerge_Click;

            // Create and configure status label
            Label lblStatus = new Label();
            lblStatus.Name = "lblStatus";
            lblStatus.Location = new Point(20, 60);
            lblStatus.Size = new Size(400, 20);
            lblStatus.Text = "Select a folder containing PDF files";

            // Create and configure list view for PDF files
            ListView listView = new ListView();
            listView.Name = "lvPDFs";
            listView.Location = new Point(20, 90);
            listView.Size = new Size(400, 200);
            listView.View = View.Details;
            listView.Columns.Add("PDF Files", 380);

            // Add controls to form
            this.Controls.AddRange(new Control[] { btnSelectFolder, btnMerge, lblStatus, listView });

            // Configure form
            this.Text = "PDF Merger";
            this.Size = new Size(460, 350);

        }

        #endregion
    }
}

