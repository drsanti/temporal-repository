
using System.Drawing.Imaging;

namespace SignalGenerationVisualization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //** Generates and returns sine wave data
        private double[] GenerateSineWave(int points=100, double amplitude=1.0, double cycles=1.0, double phaseshift=0.0, double offset=0.0)
        {
            double[] data = new double[points];   
            for(int i = 0; i < points; i++)
            {
                data[i] = amplitude * Math.Sin(2.0 * Math.PI * cycles * (double)i/points + phaseshift) + offset;
            }
            return data;
        }

        //**  Generates and returns square wave data
        private double[] GenerateSquareWave(int points = 100, double amplitude = 1.0, double cycles = 1.0, double offset = 0.0)
        {
            double[] data = new double[points];
            int  ppc = (int)(points / cycles + 0.5);    // number of points per cycle
            int phc = (int)(ppc / 2.0 + 0.5);           // number of points per half-cycle
            int state = 0;                              // 0: Low, 1: High
            int k = 0;
            for (int i = 0; i < points; i++)
            {
                k++;

                if(state == 0)
                {
                    if(k % phc == 0)
                    {
                        state = 1;
                        k = 0;
                    }
                }
                else if(state == 1)
                {
                    if (k % phc == 0)
                    {
                        state = 0;
                        k = 0;
                    }
                }

                data[i] = amplitude * state + offset;
            }
            return data;
        }


        //**  Generates and returns PWM wave data
        private double[] GeneratePwmWave(int points = 100, double amplitude = 1.0, double cycles = 1.0, double ratio = 0.5, double offset = 0.0)
        {
            double[] data = new double[points];
            int ppc = (int)(points / cycles + 0.5); // number of points per cycle
            int ptH = (int)(ppc * ratio + 0.5);     // number of points of HIGH
            int ptL = ppc - ptH;                    // number of points of LOW
            int state = 0;                          // 0: Low, 1: High
            int k = 0;
            for (int i = 0; i < points; i++)
            {
                k++;

                if (state == 0)
                {
                    if (k % ptL == 0)
                    {
                        state = 1;
                        k = 0;
                    }
                }
                else if (state == 1)
                {
                    if (k % ptH == 0)
                    {
                        state = 0;
                        k = 0;
                    }
                }

                data[i] = amplitude * state + offset;
                
            }
            return data;
        }


        private void VisualizeData(double[] data)
        {
            //** Create a bitmap object
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height, PixelFormat.Format24bppRgb);

            //** Create a graphics object
            Graphics graphics = Graphics.FromImage(bitmap);

            //** Clear with black background
            graphics.Clear(Color.Black);

            //** Create a pen
            Pen pen = new Pen(Color.Red, 3);


            //** Create points
            PointF[] points = new PointF[data.Length];

            for (int i = 0; i < points.Length; i++)
            {
                points[i].X = (float)i * (float)pictureBox1.Width / data.Length;
                points[i].Y = pictureBox1.Height - (float)data[i];
            }

            // Draw lines
            graphics.DrawLines(pen, points);


            //** 1)------------------------------------------------------------
            //** Draw on the PictureBox
            pictureBox1.Image = bitmap;

            //** Cleanup
            graphics.Dispose();


            //** 2)------------------------------------------------------------
            //** Draw on Panel
            Graphics g = panel1.CreateGraphics();
            g.DrawImage(bitmap, 0, 0);

            //** Cleanup
            g.Dispose();
        }

        //** Usage: Generates and draws on PictureBox and Panel. 
        private void Example_GenerateAndVisualizeData()
        {
            int samples = pictureBox1.Width;
            double amplitude = pictureBox1.Height / 2.1;
            double cycles = 5;
            double offset = pictureBox1.Height / 2;
            double phase  = 0.0;
            double ratio = 0.9;

            //-- TESTING ------------------------------------------------------------------------------

            //** Generate a sine wave data/signal
            var data = GenerateSineWave(samples, amplitude, cycles, phase, offset);

            //** Generate a square wave/signal
            //var data = GenerateSquareWave(samples, amplitude, cycles, offset);

            //** Generate a PWM wave/signal
            //var data = GeneratePwmWave(samples, amplitude, cycles, _ratio, offset);

            //-----------------------------------------------------------------------------------------


            //** Plot the data
            VisualizeData(data);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Example_GenerateAndVisualizeData();
        }
    }
}
