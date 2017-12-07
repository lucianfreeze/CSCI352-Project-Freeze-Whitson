// Authors: Lucian Freeze / Brett Whitson
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
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public static void Main()
        {
            Interface_Mockups.ReclaimMain app = new Interface_Mockups.ReclaimMain();
            app.InitializeComponent();
            app.Run();
        }
    }
}