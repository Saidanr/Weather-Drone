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

namespace ETC423_Capstone_Final_Drone_Code
{
    public partial class Form1 : Form
    {
        // Strings to hold the total data received from the Serial Monitor, temperature data, humidity data, lux data, and flame data, respectively
        string SerMonOut, temp, hum, lux, flame;

        private void buttonSave_Click(object sender, EventArgs e)
        {
        // Saves the received data to the appropriate text file and throws a message to the user if they attempt to save empty data

            if (textBoxTemp.Text != "" && textBoxTemp.Text != null)
            {
                File.AppendAllText("Insert File Path for Temp txt file here. MAKE SURE ALL '\' ARE MADE INTO \\ !!! ", temp + Environment.NewLine);

                File.AppendAllText("C:\\Users\\oreom\\OneDrive\\Desktop\\11-29\\ETC423 Capstone Test 11-29\\ETC423 Capstone Test 11-29\\bin\\Debug\\ETC423 Capstone Data Humidity.txt", hum + Environment.NewLine);


                File.AppendAllText("C:\\Users\\oreom\\OneDrive\\Desktop\\11-29\\ETC423 Capstone Test 11-29\\ETC423 Capstone Test 11-29\\bin\\Debug\\ETC423 Capstone Data Lux.txt", lux + Environment.NewLine);

                File.AppendAllText("C:\\Users\\oreom\\OneDrive\\Desktop\\11-29\\ETC423 Capstone Test 11-29\\ETC423 Capstone Test 11-29\\bin\\Debug\\ETC423 Capstone Data Flame.txt", flame + Environment.NewLine);
            }
            else
            {
                MessageBox.Show("There's no data to save!");
            }
        }

        private void buttonGrab_Click(object sender, EventArgs e)
        {
        // Grabs the data received from the Serial Monitor and displays it to the appropriate text box

            textBoxTemp.Text = temp + " Degrees F";
            textBoxHum.Text = hum + " %";
            textBoxLux.Text = " " + lux + " lux";
            textBoxFlame.Text = " " + flame;
        }

        public Form1()
        {
        // Opens the Serial Port to receive data from the Serial Monitor
            InitializeComponent();
            serialPort1.Open();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Background image taken from Pixabay.com from user GuentherDillingen and is free for commercial use with no attribution required
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
        // Saves the data received from the Serial Monitor as a string, splits it into a string array, then assigns the data to individual variables

            SerMonOut = serialPort1.ReadLine();
            string[] subs = SerMonOut.Split(',');

            flame = subs[0];
            lux = subs[1];
            hum = subs[2];
            temp = subs[3];
        }
    }
}
