using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Talent_Addmission_System
{
    public partial class TakePictureForm : Form
    {
        // capture picture via camera
        private VideoCaptureDevice videoCapture;
        private FilterInfoCollection filterInfo;



        public static Image capturedImage = null;
        public static Boolean isDoneClicked = false;
        public static Boolean isBtnCaptureClicked = false;

        public TakePictureForm()
        {
            InitializeComponent();
        }


        private void TakePictureForm_Load(object sender, EventArgs e)
        {
            isBtnCaptureClicked = false;
            try
            {
                startCamera();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (videoCapture.IsRunning) videoCapture.Stop();

            pbLiveImage.Image = capturedImage;
            isBtnCaptureClicked = true;

        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (isBtnCaptureClicked)
            {
                if (pbLiveImage.Image != null)
                {
                    capturedImage = pbLiveImage.Image;
                    isDoneClicked = true;
                    this.Close();
                }
            }

        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            isBtnCaptureClicked = false;
            capturedImage = null;
            if (!(videoCapture.IsRunning))
            {
                try
                {
                    startCamera();
                }
                catch (Exception)
                {
                    return;
                }
            }
        }


        private void Camera_On(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                var bitmap = (Bitmap)eventArgs.Frame.Clone();
                bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
                pbLiveImage.Image = bitmap;
                capturedImage = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
      
        }

        private void startCamera()
        {
            try
            {
                filterInfo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                videoCapture = new VideoCaptureDevice(filterInfo[0].MonikerString);
                videoCapture.NewFrame += new NewFrameEventHandler(Camera_On);
            
                if (!(videoCapture.IsRunning))
                {
                    videoCapture.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TakePictureForm_FormClosing(object sender, FormClosingEventArgs e)
        { 
            if (videoCapture.IsRunning) videoCapture.Stop();
            
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            isBtnCaptureClicked = false;
            isDoneClicked = false;
            capturedImage = null;
            if (videoCapture.IsRunning) videoCapture.Stop();
            this.Close();
        }
    }

    
}
