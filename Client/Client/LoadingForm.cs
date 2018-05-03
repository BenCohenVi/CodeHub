using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Client
{
    public partial class LoadingForm : Form
    {
        private delegate void CloseDelegate();
        private static LoadingForm loadingForm;      
        public LoadingForm()
        {
            InitializeComponent();
        }

        static public void ShowLoadingScreen()
        /* Showing the loading screen.
         * 
         * To show the animation in the loading screen we need to run this form in a thread,
         * this function starts the thread that shows this form.
         */
        {
            if (loadingForm != null)
                return;
            Thread thread = new Thread(new ThreadStart(LoadingForm.ShowForm));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        static private void ShowForm()
        {
            loadingForm = new LoadingForm();
            Application.Run(loadingForm);
        }

        static public void CloseForm()
        {
            Thread.Sleep(100);
            loadingForm.Invoke(new CloseDelegate(LoadingForm.closeFormInternal));
        }

        static private void closeFormInternal()
        {
            loadingForm.Close();
            loadingForm = null;
        }
    }
}
