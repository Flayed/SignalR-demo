using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EnvironmentStatusViewer
{    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public EnvironmentStatusViewModel ViewModel = new EnvironmentStatusViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = ViewModel;
            ViewModel.DevStatus = "Good";
            ViewModel.TestStatus = "Good";
            ViewModel.StageStatus = "Good";
            var Client = new Client();
            Task.Run(async () =>
            {
                await Client.Start(UpdateEnvironmentStatus);
            });
        }

        private void UpdateEnvironmentStatus(string environment, string status)
        {
            switch (environment.ToLower())
            {
                case "dev":
                    ViewModel.DevStatus = status;
                    break;
                case "test":
                    ViewModel.TestStatus = status;
                    break;
                case "stage":
                    ViewModel.StageStatus = status;
                    break;               
            }
        }
    }
}
