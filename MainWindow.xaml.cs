using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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

namespace TimeBack {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window {
        List<TableClass> smallTable;
        DispatcherTimer m_seconds;
        MediaPlayer lets;
        public MainWindow() {
            InitializeComponent();
            CreateObjects();
            lets = new MediaPlayer();
            lets.Open(new Uri("sounds/alert.wav", UriKind.Relative));
            lets.MediaEnded += Lets_MediaEnded;

        }

        private void Lets_MediaEnded(object sender, EventArgs e) {
            lets.Stop();
        }

        // Здесь должен читаться файл с предыдущими настройками
        private void CreateObjects() {
            smallTable = new List<TableClass>();
            timerTable.ItemsSource = smallTable;
            m_seconds = new DispatcherTimer();
            m_seconds.Interval = TimeSpan.FromSeconds(1);
            m_seconds.Start();
            m_seconds.Tick += TimerClock;
        }
        private void TimerClock(object sender, EventArgs e) {
            for(var i =0; i < smallTable.Count; i++) {
                TimeSpan zero = TimeSpan.Parse(smallTable[i].Remain);
                if (zero == TimeSpan.Zero) {
                    EndOfTheTimer(i);
                    continue;
                }
                zero -= TimeSpan.FromSeconds(1);
                smallTable[i].Remain = zero.ToString();
                Console.WriteLine(smallTable[i].Remain);
                timerTable.Items.Refresh();


            }
               
        }

        private void EndOfTheTimer(int number) {
            smallTable.RemoveAt(number);
            lets.Play();
            timerTable.Items.Refresh();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            TimerSet tempWindow = new TimerSet(this);
            tempWindow.Visibility = Visibility.Visible;
        }
        public void TakeTimer(int days, int hours, int minutes, int seconds, string name) {
            TimeSpan remain = new TimeSpan(days, hours, minutes, seconds);
            DoomTimer myTest = new DoomTimer(remain);
            smallTable.Add(new TableClass(name, myTest.m_startTime.ToLongTimeString(), myTest.m_endingTime.ToLongTimeString(), remain.ToString()));
            timerTable.Items.Refresh();

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e) {
            smallTable.Clear();
            timerTable.Items.Refresh();
        }
        private void StopPlayer(object sender, RoutedEventArgs e) {
            lets.Stop();
        }
        /*  private void timeStaff_KeyDown(object sender, KeyEventArgs e) {
Console.WriteLine($"{e.Key} {e.OriginalSource} {e.SystemKey}\n");
/*string[] numbers = timeStaff.Text.Split(':');
if ((int)e.Key.ToString()[0] > 57 || (int)e.Key.ToString()[0] < 48) {
timeStaff.Text = m_text;
return;
}*/





        /*   private void LockContent(object sender, EventArgs e) {
               SystemSounds.Beep.Play();
               //Console.WriteLine($"{sender} {e}");
               m_timers[0].Stop();
               m_timers.RemoveAt(0);

           }
           private void MinusOne(object sender, EventArgs e) {
               if (timeStaff.Text == "00:00:00")
                   secondTimer.Tick -= MinusOne;
               string[] input = timeStaff.Text.Split(':', StringSplitOptions.RemoveEmptyEntries);
               int hours = 0, minutes = 0, seconds = 0;
               if (input.Length != 3)
                   return;
               TimeSpan interval = new TimeSpan(0, 0, 0);
               if (Int32.TryParse(input[0], out hours) && Int32.TryParse(input[1], out minutes) && Int32.TryParse(input[2], out seconds))
                   interval = new TimeSpan(hours, minutes, seconds);
               interval = interval - TimeSpan.FromSeconds(1);
               timeStaff.Text = interval.ToString();

           }
           private void Button_Click(object sender, RoutedEventArgs e) {
               string[] input = timeStaff.Text.Split(':', StringSplitOptions.RemoveEmptyEntries);
               int hours=0, minutes=0, seconds=0;
               if (input.Length != 3)
                   return;
               TimeSpan interval = new TimeSpan(0, 0, 0);
               if (Int32.TryParse(input[0], out hours) && Int32.TryParse(input[1], out minutes) && Int32.TryParse(input[2], out seconds)) {
                   if (hours > 23 || hours < 0 || minutes > 59 || minutes < 0 || seconds > 59 || seconds < 0)
                       return;
                   interval = new TimeSpan(hours, minutes, seconds);
               }
               m_timers.Add(new DispatcherTimer());
               m_timers[m_timers.Count-1].Tick += LockContent;
               m_timers[m_timers.Count-1].Interval = interval;
               m_timers[m_timers.Count-1].Start();
               Console.WriteLine("Time count start");
               timeStaff.IsReadOnly = true;
               secondTimer.Tick += MinusOne;
           }

           private void Button_Click_1(object sender, RoutedEventArgs e) {
               foreach (var member in m_timers)
                   member.Stop();
               timeStaff.Text = "00:00:00";
           }*/
    }
}
