using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
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

namespace Threading
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

        private async void MuButton_OnClick(object sender, RoutedEventArgs e)
        {

            await Task.Run(async () =>
            {
               
                Debug.WriteLine($"On Thread {Thread.CurrentThread.ManagedThreadId}");
                var webclient = new HttpClient();
                var html = await webclient.GetStringAsync("http://angelsix.com");

            });

            Debug.WriteLine($"Now on Thread {Thread.CurrentThread.ManagedThreadId}");
            //Now Logged in
            MuButton.Content = "Logged in";


        }

        //private async void MuButton_OnClick(object sender, RoutedEventArgs e)
        //{
        //    //Debug.WriteLine($"1 ({Thread.CurrentThread.ManagedThreadId})");

        //    await  Task.Run(()=>
        //    {
        //        //Debug.WriteLine($"2 ({Thread.CurrentThread.ManagedThreadId})");
        //        Debug.WriteLine($"On Thread {Thread.CurrentThread.ManagedThreadId}");
        //        var webclient = new HttpClient();
        //        var html = webclient.GetStringAsync("http://angelsix.com").Result;

        //        //Debug.WriteLine($"3 ({Thread.CurrentThread.ManagedThreadId})");
        //        Application.Current.Dispatcher.Invoke(() =>
        //        {
        //            Debug.WriteLine($"4 ({Thread.CurrentThread.ManagedThreadId})");

        //            Debug.WriteLine($"Now on Thread {Thread.CurrentThread.ManagedThreadId}");
        //            //Now Logged in
        //            MuButton.Content = "Logged in";
        //        });

        //        //Debug.WriteLine($"5 ({Thread.CurrentThread.ManagedThreadId})");

        //    });

        //    //Debug.WriteLine($"6 ({Thread.CurrentThread.ManagedThreadId})");
        //}
    }
}
