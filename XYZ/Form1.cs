using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge;
using AForge.Imaging.Filters;
using AForge.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Vision;
using AForge.Vision.Motion;

namespace Goruntuisleme
{
    public partial class Form1 : Form
    {
        private VideoCaptureDevice kameraAygit;
        private FilterInfoCollection webcamAygit;
        int objectX;
        int objectY;

        public Form1()
        {
            InitializeComponent();
        }

        //*****************************************

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (kameraAygit != null && kameraAygit.IsRunning)
            {
                kameraAygit.SignalToStop();
                kameraAygit = null;                
            }
        }

        //*****************************************

        private void Form1_Load(object sender, EventArgs e)
        {
            webcamAygit = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in webcamAygit)
            {
                comboBox1.Items.Add(VideoCaptureDevice.Name); // WebCamleri listele
                comboBox1.SelectedIndex = 0;
            }          
                    
        }

        //*****************************************

        void cam_goruntu_new_frame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            Bitmap image1 = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = image;

            if (radioButton1.Checked == true)
            {
                ColorFiltering filter = new ColorFiltering();
                filter.Red = new IntRange(150, 255);
                filter.Green = new IntRange(0, 75);
                filter.Blue = new IntRange(0, 75);
                filter.ApplyInPlace(image1);
                nesnebul(image1);
            }

            if (radioButton2.Checked == true)
            {
                ColorFiltering filter = new ColorFiltering();
                filter.Red = new IntRange(0, 75);
                filter.Green = new IntRange(0, 75);
                filter.Blue = new IntRange(100, 255);
                filter.ApplyInPlace(image1);
                nesnebul(image1);
            }

            if (radioButton3.Checked == true)
            {
                ColorFiltering filter = new ColorFiltering();
                filter.Red = new IntRange(80  , 255);
                filter.Green = new IntRange(80, 255);
                filter.Blue = new IntRange(30, 80);
                filter.ApplyInPlace(image1);
                nesnebul(image1);
            }
        }
        
        //*****************************************

       public void nesnebul(Bitmap image)
       {
        BlobCounter blobCounter = new BlobCounter();
        blobCounter.MinWidth = 2;
        blobCounter.MinHeight = 2;
        blobCounter.FilterBlobs = true;
        blobCounter.ObjectsOrder = ObjectsOrder.Size;
        Grayscale griFiltre = new Grayscale(0.2125, 0.7154, 0.0721);
        Bitmap griImage = griFiltre.Apply(image);
        blobCounter.ProcessImage(griImage);
        Rectangle[] rects = blobCounter.GetObjectsRectangles();
        pictureBox2.Image = griImage;
        foreach (Rectangle recs in rects)
            {
                if (rects.Length > 0)
                    {
                        Rectangle objectRect = rects[0];
                        //Graphics g = Graphics.FromImage(image);
                        Graphics g = pictureBox1.CreateGraphics();
                        using (Pen pen = new Pen(Color.FromArgb(252, 3, 26), 2))
                            {
                                g.DrawRectangle(pen, objectRect);
                            }
                        //Cizdirilen Dikdörtgenin Koordinatlari aliniyor.
                         objectX = objectRect.X + (objectRect.Width / 2);
                         objectY = objectRect.Y + (objectRect.Height / 2);
                        g.DrawString(objectX.ToString() + "X" + objectY.ToString(), new Font("Arial", 12), Brushes.Red, new System.Drawing.Point(250, 1));
                        g.Dispose();
                    }
            }
        }

       private void button1_Click(object sender, EventArgs e)
       {
           kameraAygit = new VideoCaptureDevice(webcamAygit[comboBox1.SelectedIndex].MonikerString);//webcam listesinden kafadan birinciyi al diyoruz.
           kameraAygit.NewFrame += new NewFrameEventHandler(cam_goruntu_new_frame);
           kameraAygit.DesiredFrameRate = 30;//saniyede kaç görüntü alsın istiyorsanız. FPS
           kameraAygit.DesiredFrameSize = new Size(320, 240);//görüntü boyutları
           kameraAygit.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = objectX.ToString();
            label3.Text = objectY.ToString();

            int X = Convert.ToInt32(label2.Text);
            int Y = Convert.ToInt32(label3.Text);
            if (X<100 && Y<75)
            {
                label1.Text = "1.Ledi Yak";
                serialPort1.Write("A");
            }
            if (X>=100 && X<200 && Y < 75)
            {
                label1.Text = "2.Ledi Yak";
                serialPort1.Write("B");
            }
            if (X >=200 && X < 300 && Y < 75)
            {
                label1.Text = "3.Ledi Yak";
                serialPort1.Write("C");
            }
            if (X < 100 && Y >= 75 && Y < 150)
            {
                label1.Text = "4.Ledi Yak";
                serialPort1.Write("D");
            }
            if (X >= 100 && X < 200 && Y >= 75 && Y < 150)
            {
                label1.Text = "5.Ledi Yak";
                serialPort1.Write("E");
            }
            if (X >= 200 && X < 300 && Y >= 75 && Y < 150)
            {
                label1.Text = "6.Ledi Yak";
                serialPort1.Write("F");
            }
            if (X < 100 && Y >= 150 && Y < 225)
            {
                label1.Text = "7.Ledi Yak";
                serialPort1.Write("G");
            }
            if (X >= 100 && X < 200 && Y >= 150 && Y < 225)
            {
                label1.Text = "8.Ledi Yak";
                serialPort1.Write("H");
            }
            if (X >= 200 && X < 300 && Y >= 150 && Y < 225)
            {
                label1.Text = "9.Ledi Yak";
                serialPort1.Write("I");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = "COM3";
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
                MessageBox.Show("Bağlantı Kuruldu");
            }
            catch
            {
                MessageBox.Show("Bağlantı Kurulmadı");
            }
            timer1.Start();
        }
    }
}


