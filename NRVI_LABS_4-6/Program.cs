using System;
using System.Windows.Forms;

namespace NRVI_LABS_4_6 { 
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MessageFormattingForm());
        }
    }
}
