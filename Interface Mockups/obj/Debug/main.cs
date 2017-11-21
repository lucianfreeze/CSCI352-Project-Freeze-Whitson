using System;
using System.Windows;

namespace Interface_Mockups {

    public partial class ReclaimMain : System.Windows.Application
    {
        public void InitializeComponent()
        {
            this.StartupUri = new System.Uri("MainWindow.xaml", System.UriKind.Relative);
        }

        [System.STAThreadAttribute()]
        public static void main()
        {
            Interface_Mockups.ReclaimMain app = new Interface_Mockups.ReclaimMain();
            app.InitializeComponent();
            app.Run();
        }
    }
}