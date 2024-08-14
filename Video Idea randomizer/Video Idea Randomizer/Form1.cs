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

namespace Video_Idea_Randomizer
{
    public partial class Form1 : Form
    {
        public string thefile;

        public Form1()
        {

            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string folderPath = @"C:\Scripts"; // Change this to your actual folder path

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Get all text files in the folder
            string[] files = Directory.GetFiles(folderPath, "*.txt");

            // Check if there are any text files in the folder
            if (files.Length > 0)
            {
                // Generate a random index to pick a file
                Random random = new Random();
                int randomIndex = random.Next(files.Length);

                // Load the content of the randomly selected file
                string selectedFilePath = files[randomIndex];
                thefile = selectedFilePath;
                button1.Enabled = true;
                string fileContent = File.ReadAllText(selectedFilePath);

                // Display the content in the RichTextBox
                richTextBox1.Text = fileContent;
                
            }
            else
            {
                // Optional: Notify the user if no text files are found
                //MessageBox.Show("No text files found in the folder.");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //save
            string folderPath = @"C:\Scripts"; // Change this to your actual folder path

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Count the number of text files in the folder
            int fileCount = Directory.GetFiles(folderPath, "*.txt").Length;

            // Generate the file name based on the file count
            string fileName = $"file_{fileCount + 1}.txt";
            string filePath = Path.Combine(folderPath, fileName);

            // Content to write to the file
            string content = richTextBox1.Text;

            // Create and write to the file
            File.WriteAllText(filePath, content);

            button1.Enabled = true;

            // Optional: Notify the user that the file has been saved
            //MessageBox.Show($"File saved as {fileName}");

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(thefile))
            {
                MessageBox.Show("No file selected to move.");
                return;
            }

            string destinationFolderPath = @"C:\Scripts\Done"; // Change this to your actual destination folder path

            // Ensure the destination folder exists
            if (!Directory.Exists(destinationFolderPath))
            {
                Directory.CreateDirectory(destinationFolderPath);
            }

            // Create the full destination path
            string fileName = Path.GetFileName(thefile);
            string destinationFilePath = Path.Combine(destinationFolderPath, fileName);

            try
            {
                // Move the file
                File.Move(thefile, destinationFilePath);
                //MessageBox.Show($"File moved to {destinationFilePath}");
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error moving file: {ex.Message}");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            thefile = "";
            button1.Enabled = false;
        }
    }
}
