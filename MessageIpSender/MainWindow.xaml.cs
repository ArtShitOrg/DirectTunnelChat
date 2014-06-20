using MessageIpSender.ViewModel;
using Saikt.WPF;
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

namespace MessageIpSender
{
    
    public partial class MainWindow : Window
    {
        private ConnectionViewModel _connectVM;
        public MainWindow()
        {
            InitializeComponent();
            _connectVM = new ConnectionViewModel();
            DataContext = _connectVM;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key != Key.Enter)
            {       
            }
            else
            {
                _connectVM.CommandSendHandler(null);
            }
        }
    }
}
