using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using Microsoft.Win32;

namespace UIThread
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
           // var openFileDialog = new OpenFileDialog();
            //var result = openFileDialog.ShowDialog();

            //var messageQueue = new List<object>();

            //--------------------------------------

            //while (true)
            //{
            //    ProcessSomeUI();
            //    ProcessEventHandlers();
            //    ProcessExternalMessages();

            //    var nextMessage = messageQueue[0];
            //    // Process next Message


            //}
            //----------------------------------------

            var buttonDispatcher = MyButton.Dispatcher;
            var windowDispatcher = Dispatcher;

            var thisDispatcher = System.Windows.Threading.Dispatcher.FromThread(Thread.CurrentThread);

            Dispatcher newThreadDispatcher;

            new Thread(() =>
            {


                var newTheradDispatcher = System.Windows.Threading.Dispatcher.FromThread(Thread.CurrentThread);

                if (buttonDispatcher == windowDispatcher && buttonDispatcher == thisDispatcher)
                {
                    
                }
                if (buttonDispatcher == newTheradDispatcher)
                {
                    
                }
            }).Start();
        }

    }
}
