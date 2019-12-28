using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Windows.Forms;
using System.Drawing;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Threading;

namespace WindowsFormsApplication3
{
    public  partial class Form1 : Form
    {
        private Capture cap;
        private static HaarCascade haar;
        
        //My code starts from here AR
        public static System.Drawing.Point Position { get; set; }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        //  [DllImport("user32.dll")]
        public static extern void mouse_event
            (MouseEventType dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        //[DllImport("user32")]
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SetCursorPos(int x, int y);

        //My code ends here  AR
        
        public Form1()
        {
            InitializeComponent();
 //           MessageBox.Show("Hi", "There");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            Form1.SetCursorPos(0, 0);
            //  passing 0 gets zeroth webcam
                       cap = new Capture(0);
                       haar = new HaarCascade("haarcascade_frontalface_alt.xml");
               
        }

       private  void button1_Click(object sender, System.EventArgs e)
        {
           
               
            
        }
        //My code starts from here

       private void tracker()
       {

           //curser position strart
           
       }
        
        public enum MouseEventType : int
        {
            LeftDown = 0x02,
            LeftUp = 0x04,
            RightDown = 0x08,
            RightUp = 0x10
        }
       private void button2_Click(object sender, System.EventArgs e)
       {

           Thread T1 = new Thread(t =>
           {
             //  MessageBox.Show("Hi", "There");
               //Console.WriteLine("hello");
               while (true)
               {
                   using (Image<Bgr, byte> nextFrame = cap.QueryFrame())
                   {
                       if (nextFrame != null)
                       {
                           //there's only one channel (greyscale), hence the zero index
                           // var faces = nextFrame.DetectHaarCascade(haar)[0];
                           Image<Gray, byte> grayframe = nextFrame.Convert<Gray, byte>();
                           var faces =
                               grayframe.DetectHaarCascade(
                                   haar, 1.4, 4,
                                   HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                                   new Size(nextFrame.Width / 8, nextFrame.Height / 8)
                                   )[0];
                          // Console.WriteLine(nextFrame.Width.ToString());
                           foreach (var face in faces)
                           {
                               nextFrame.Draw(face.rect, new Bgr(0, double.MaxValue, 0), 3);
                           }
                           pictureBox1.Image = nextFrame.ToBitmap();
                       }

               }
               
               }
               Thread.Sleep(5);
           }) {IsBackground = true};
           T1.Start();
           
           //   this.Cursor = new Cursor(Cursor.Current.Handle);
          // Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 50);
          // Cursor.Clip = new Rectangle(this.Location, this.Size);
          // SetCursorPos(120, 130);
         //  MessageBox.Show("Hi", "There");
          /// mouse_event(MouseEventType.LeftDown, Cursor.Position.X, Cursor.Position.Y+100, 120, 130);
           //mouse_event(MouseEventType.LeftUp, Cursor.Position.X+120, Cursor.Position.Y+100, 120, 130);
       }

       private void button3_Click(object sender, System.EventArgs e)
       {
        
       }

       private void button1_Click_1(object sender, System.EventArgs e)
       {
         
       }

       private void button1_Click_2(object sender, System.EventArgs e)
       {
           
       }
        //My code ends here
    }
}     

