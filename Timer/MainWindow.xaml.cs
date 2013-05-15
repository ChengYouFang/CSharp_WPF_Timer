using System;
using System.Threading;
using System.Windows;

namespace Time
{
    public partial class MainWindow : Window
    {
        private Timer timer;
        private SynchronizationContext syncContext = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            syncContext = SynchronizationContext.Current;
            timer = new Timer(Timer_Ticked, null, 0, 1000);
        }

        private void Timer_Ticked(Object stateInfo)
        {
            SendOrPostCallback callBack = delegate(object state)
            {
                this.label1.Content = string.Format("{0:T}", DateTime.Now.ToLocalTime());
            };
            syncContext.Post(callBack, null);
        }
    }
}