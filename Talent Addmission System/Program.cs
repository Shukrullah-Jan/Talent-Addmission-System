using System;
using System.Windows.Forms;
using Talent_Addmission_System.Properties;

namespace Talent_Addmission_System
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // check for software registration
            string activationCode = Settings.Default["activationCode"].ToString();
           
            if (activationCode != "PR2G9-K4L33-EU90S-REKAH-IOW02")
            {

                var activationForm = new ActivationForm();
                Application.Run(activationForm);

            }
            else
            {
                Application.Run(new SplashScreenForm());
          

            }

    
        }
    }
}
