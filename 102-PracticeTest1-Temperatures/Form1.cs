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

namespace _102_PracticeTest1_Temperatures
{
    public partial class Form1 : Form
    {
        //Name:
        //ID:
        const int BAR_HEIGHT = 10;
        const int MAX_TEMP = 50;
        const int GAP = 5;

        List<Reading> temperaturesList = new List<Reading>();
        public Form1()
        {
            InitializeComponent();
        }

        public void UdateListBox()
        {
            listBoxData.Items.Clear();

            //for (int i = 0; i < temperaturesList.Count; i++)
            //{
            //    listBoxData.Items.Add(temperaturesList[i]);
            //}

            // the object 'r' is pointing to the temperaturesList<> (reference variable)
            foreach(Reading r in temperaturesList)
            {
                // you can change values in a list 
                //r.High = 100;
                //r.Low = 100;
                listBoxData.Items.Add(r);
            }
        }

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // get the file reader
            StreamReader reader;
            // variable to read a line
            string line = "";
            // array to handle the splitting of values from the csv
            string[] csvArray;

            string date = "";
            double high = 0;
            double low = 0;

            // opens the file
            openFileDialog1.Filter = "CSV Files|*.csv|ALL Files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                reader = File.OpenText(openFileDialog1.FileName);
                while (!reader.EndOfStream)
                {
                    try
                    {
                        // read a line from the file
                        line = reader.ReadLine();
                        // split the line using an array
                        csvArray = line.Split(',');
                        // check if the array has the correct number of elements in that line
                        if (csvArray.Length == 3)
                        {
                            // extract the values out
                            date = csvArray[0];
                            high = double.Parse(csvArray[1]);
                            low = double.Parse(csvArray[2]);

                            // create an object and add to the temperatureList
                            Reading r = new Reading(date, high, low);
                            temperaturesList.Add(r);
                            // another way of creating an object an adding it to the List
                            //temperaturesList.Add(new Reading(date, high, low));

                        }
                        else
                        {
                            Console.WriteLine("Error: " + line);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Error: " + line);
                    }
                }
                reader.Close();
                MessageBox.Show(temperaturesList.Count.ToString());

                UdateListBox();
            }
        }

        private void graphAverageTemperaturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // drawing objects
            Graphics paper = pictureBoxDisplay.CreateGraphics();
            SolidBrush br = new SolidBrush(Color.Orange);
            Pen pen1 = new Pen(Color.Black, 1);

            double aveTemp = 0;
            int barWidth;
            int x = 0;
            int y = 0;
            foreach(Reading r in temperaturesList)
            {
                // aveTemp variable getting access to the Reading r object
                // and pointing to the property AveTemp
                aveTemp = r.AveTemp;
                barWidth = (int)((aveTemp / 50) * pictureBoxDisplay.Width);
                paper.FillRectangle(br, x, y, barWidth, BAR_HEIGHT);
                paper.DrawRectangle(pen1, x, y, barWidth, BAR_HEIGHT);
                y += BAR_HEIGHT + GAP;
                
            }
        }

        private void showMaxAverageTempToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // drawing objects
            Graphics paper = pictureBoxDisplay.CreateGraphics();
            SolidBrush br = new SolidBrush(Color.Green);
            Pen pen1 = new Pen(Color.Black, 1);
            int barWidth = 0;
            int index = 0;
            double max = temperaturesList[0].AveTemp;
            
            for(int i = 1; i < temperaturesList.Count; i++)
            {
                // check if whats in the list is greater than what is in the max variable 
                if (temperaturesList[i].AveTemp > max)
                {
                    max = temperaturesList[i].AveTemp;
                    index = i;
                }
            }
            barWidth = (int)((max / 50) * pictureBoxDisplay.Width);
            paper.FillRectangle(br, 0, index * (BAR_HEIGHT + GAP), barWidth, BAR_HEIGHT);
           
        }

        private void buttonFindTemp_Click(object sender, EventArgs e)
        {
            foreach(Reading r in temperaturesList)
            {
                if (r.Date == textBoxDate.Text)
                {
                    MessageBox.Show(r.ToString());
                }
            }
        }

        private void buttonCount_Click(object sender, EventArgs e)
        {

        }
    }
}
