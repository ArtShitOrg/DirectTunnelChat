using MessageIpSender.Models;
using Saikt.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace MessageIpSender.ViewModel
{
    public class ConnectionViewModel : ViewModelBase
    {
        private readonly DispatcherTimer _timer;
        private MediaPlayer _player;

        private bool _isConnected = false;
        private string _ipSend = "127.0.0.1";
        private string _ipHost = "127.0.0.1";
        private string _portSend = "57379";
        private string _portHost = "57379";
        private string _message;
        private MessageModel _selectedItem;
        private MessageModel _messageMem;
        private ObservableCollection<MessageModel> _messages = new ObservableCollection<MessageModel>();

        private Task hostTask = null;
        private UdpClient udp = null;

        public ConnectionViewModel ()
	    {
            _player = new MediaPlayer();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(10);
            _timer.Tick += _timer_Tick;
            _timer.Start();

            CommandSend = new DelegateCommand(CommandSendHandler);
            CommandConnected = new DelegateCommand(CommandConnectedHandler);
            //CommandPlaySound = new DelegateCommand(CommandPlaySoundHandler);
	    }
        void _timer_Tick(object sender, EventArgs e)
        {
                if (_messageMem != null)
                {
                    Messages.Insert(0,_messageMem);

                    try
                    {
                        _player.Stop();
                        _player.Open(new Uri("message.mp3"));
                        _player.Play();
                    }
                    catch
                    { }
                }
                _messageMem = null;
                if (Messages.Count() != 0)
                    SelectedItem = Messages.FirstOrDefault();
        }

        public bool IsConnected
        {
            get { return _isConnected; }
            set
            {
                _isConnected = value;
                OnPropertyChanged("IsConnected");
            }
        }
        public MessageModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        public string IPSend
        {
            get { return _ipSend; }
            set
            {
                _ipSend = value;
                OnPropertyChanged("IPSend");
            }
        }
        public string IPHost
        {
            get { return _ipHost; }
            set
            {
                _ipHost = value;
                OnPropertyChanged("IPHost");
            }
        }
        public string PortSend
        {
            get { return _portSend; }
            set
            {
                _portSend = value;
                OnPropertyChanged("PortSend");
            }
        }
        public string PortHost
        {
            get { return _portHost; }
            set
            {
                _portHost = value;
                OnPropertyChanged("PortHost");
            }
        }
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }
        public ObservableCollection<MessageModel> Messages
        {
            get { return _messages; }
            set
            {
                try
                {
                    _messages = value;
                }
                catch { }
                OnPropertyChanged("Messages");
            }
        }

        public DelegateCommand CommandSend { get; private set; }
        public DelegateCommand CommandConnected { get; private set; }

        public void CommandSendHandler(object obj)
        {
            // Отправляем сообщение и  закрываем udpclient
            UdpClient udp = new UdpClient();
            if ((_message != null)&&(_message != ""))
            {
                byte[] message = Encoding.Default.GetBytes(_message);
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(_ipSend), Convert.ToInt32(_portSend));
                udp.Send(message, message.Length, ep);
                udp.Close();

                Messages.Insert(0, new MessageModel(true, _message, DateTime.Now.TimeOfDay));
                Message = null;
                if (Messages.Count() != 0)
                    SelectedItem = Messages.FirstOrDefault();
            }
        }

        public void CommandConnectedHandler(object obj)
        {
            // Чтобы наше приложение не заблокировалось,
            // для извлечения сообщений запускаем второй поток
            if (!IsConnected) 
                hostTask = Task.Factory.StartNew(() => Parallel.Invoke(new Action(() => Receive())));

            if (IsConnected)
                IsConnected = false;
            else
                IsConnected = true;
        }

        void Receive()
        {
            try
            {
                
                    IPEndPoint ep = new IPEndPoint(IPAddress.Parse(_ipHost), Convert.ToInt32(_portHost));
                    udp = new UdpClient(ep);
                    while (IsConnected)
                    {
                        IPEndPoint remote = null;
                        byte[] message = udp.Receive(ref remote);
                        if (IsConnected)
                        ShowMessage(Encoding.Default.GetString(message));
                    }
            }
            catch { }
            finally
            {
                if (udp != null) udp.Close();
            }


        }
        public void ShowMessage(string hostMessage)
        {
            try
            {

                MessageModel mes = new MessageModel(false, hostMessage, DateTime.Now.TimeOfDay);
                Dispatcher.CurrentDispatcher.Invoke((Action)delegate
                {
                    _messageMem = mes;
                });
            }
            catch { }
        }
    }
}
