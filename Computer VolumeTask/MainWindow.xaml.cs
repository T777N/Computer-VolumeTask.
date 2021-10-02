using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{



    public partial class MainWindow : Window
    {
        public static int work = 0;
        public int number = 0;
        public MainWindow()
        {
            InitializeComponent();





        }

        private void Mute_Click(object sender, RoutedEventArgs e)
        {
            Mut();
        }
        public void Mut()
        {
            if (work == 1)
            {

                Window window = Window.GetWindow(this);
                var wih = new WindowInteropHelper(window);
                IntPtr hWnd = wih.Handle;
                Mute computer = new Mute();
                computer.Muting(hWnd);
            }
        }
        private void Increase_Click(object sender, RoutedEventArgs e)
        {
            UP();
        }
        public void UP()
        {
            if (work == 1)
            {
                Window window = Window.GetWindow(this);
                var wih = new WindowInteropHelper(window);
                IntPtr hWnd = wih.Handle;
                Mute computer = new Mute();
                computer.Increase(hWnd);
            }
        }

        private void Decrease_Click(object sender, RoutedEventArgs e)
        {
            Down();
        }
        public void Down()
        {
            if (work == 1)
            {
                Window window = Window.GetWindow(this);
                var wih = new WindowInteropHelper(window);
                IntPtr hWnd = wih.Handle;
                Mute computer = new Mute();
                computer.Decrease(hWnd);
            }
        }

        private void sliderIpon_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (work == 1)
            {
                newLbl.Content = (int)sliderIpon.Value;
                bool count = true;
                while (count)
                {

                    if (number < (int)sliderIpon.Value && number + 1 != (int)sliderIpon.Value && number - 1 != (int)sliderIpon.Value)
                    {
                        UP();
                        number += 2;

                    }
                    else if (number > (int)sliderIpon.Value && number + 1 != (int)sliderIpon.Value && number - 1 != (int)sliderIpon.Value)
                    {
                        Down();
                        number -= 2;
                    }

                    if (number + 1 == (int)sliderIpon.Value || number - 1 == (int)sliderIpon.Value || number == (int)sliderIpon.Value)
                    {
                        count = false;
                    }
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (work == 0)
            {
                iponBtn.Margin = new Thickness(224, 108, 536, 277);
                iponBtn.Background = Brushes.Green;
                work = 1;
            }
            else if (work == 1)
            {
                iponBtn.Margin = new Thickness(196, 108, 564, 277);
                iponBtn.Background = Brushes.Red;
                work = 0;
            }
        }
    }

    public class Mute
    {

        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetConsoleWindow();



        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);



        public void Muting(IntPtr Handle)
        {
            SendMessageW(Handle, WM_APPCOMMAND, Handle, (IntPtr)APPCOMMAND_VOLUME_MUTE);
            return;
        }

        public void Decrease(IntPtr Handle)
        {
            SendMessageW(Handle, WM_APPCOMMAND, Handle, (IntPtr)APPCOMMAND_VOLUME_DOWN);
            return;
        }

        public void Increase(IntPtr Handle)
        {
            SendMessageW(Handle, WM_APPCOMMAND, Handle, (IntPtr)APPCOMMAND_VOLUME_UP);
            return;
        }

    }
}
