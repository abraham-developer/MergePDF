using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MergePDF
{
    public partial class Form1 : Form
    {
        private string selectedFolder = string.Empty;

        public Form1()
        {
            InitializeComponent();
            
        }

       

        private void BtnSelectFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFolder = folderDialog.SelectedPath;
                    UpdateFileList();
                }
            }
        }

        private void UpdateFileList()
        {
            ListView lvPDFs = (ListView)Controls.Find("lvPDFs", true)[0];
            Label lblStatus = (Label)Controls.Find("lblStatus", true)[0];
            lvPDFs.Items.Clear();

            string[] pdfFiles = Directory.GetFiles(selectedFolder, "*.pdf");
            foreach (string file in pdfFiles)
            {
                lvPDFs.Items.Add(Path.GetFileName(file));
            }

            lblStatus.Text = $"Found {pdfFiles.Length} PDF files";
        }

        private void BtnMerge_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFolder))
            {
                MessageBox.Show("Please select a folder first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] pdfFiles = Directory.GetFiles(selectedFolder, "*.pdf");
            if (pdfFiles.Length == 0)
            {
                MessageBox.Show("No PDF files found in the selected folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveDialog.FilterIndex = 1;
                saveDialog.RestoreDirectory = true;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        MergePDFs(pdfFiles, saveDialog.FileName);
                        MessageBox.Show("PDFs merged successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error merging PDFs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void MergePDFs(string[] pdfFiles, string outputFile)
        {
            using (FileStream stream = new FileStream(outputFile, FileMode.Create))
            using (Document document = new Document())
            using (PdfCopy pdf = new PdfCopy(document, stream))
            {
                document.Open();

                foreach (string file in pdfFiles)
                {
                    using (PdfReader reader = new PdfReader(file))
                    {
                        for (int i = 1; i <= reader.NumberOfPages; i++)
                        {
                            pdf.AddPage(pdf.GetImportedPage(reader, i));
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}