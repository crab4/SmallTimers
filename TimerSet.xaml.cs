using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TimeBack {
    /// <summary>
    /// Логика взаимодействия для TimerSet.xaml
    /// </summary>
    public partial class TimerSet : Window {
        int m_seconds;
        int m_minutes;
        int m_hours;
        int m_days;
        MainWindow m_parent;
        public TimerSet(MainWindow parent) {
            m_parent = parent;
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void daysBox_TextChanged(object sender, TextChangedEventArgs e) {
            if (daysBox.Text.Length < 4)
                Int32.TryParse(daysBox.Text, out m_days);
            daysBox.Text = $"{m_days}";




        }
        //Хорошо бы сделать перенос по модулю в бОльший разряд
        private void hoursBox_TextChanged(object sender, TextChangedEventArgs e) {
            Console.WriteLine(hoursBox.Text);
            int tmp = -1;
            if (hoursBox.Text.Length < 3)
                Int32.TryParse(hoursBox.Text, out tmp);
            if (tmp >= 0 && tmp < 24)
                m_hours = tmp;
            hoursBox.Text = $"{m_hours}";
        }

        private void minutesBox_TextChanged(object sender, TextChangedEventArgs e) {
            int tmp = -1;
            if (minutesBox.Text.Length < 3)
                Int32.TryParse(minutesBox.Text, out tmp);
            if (tmp >= 0 && tmp < 60)
                m_minutes = tmp;
            minutesBox.Text = $"{m_minutes}";
        }

        private void secondsBox_TextChanged(object sender, TextChangedEventArgs e) {
            int tmp=-1;
            if (secondsBox.Text.Length < 3)
                Int32.TryParse(secondsBox.Text, out tmp);
            if (tmp >= 0 && tmp < 60)
                m_seconds = tmp;
            secondsBox.Text = m_seconds.ToString();

        }

        private void ResetButton_Click(object sender, RoutedEventArgs e) {
            daysBox.Text = "";
            hoursBox.Text = "";
            minutesBox.Text = "";
            secondsBox.Text = "";
            NameBox.Text = "";
        }

        private void StartButton_Click(object sender, RoutedEventArgs e) {
            m_parent.TakeTimer(m_days, m_hours, m_minutes, m_seconds, NameBox.Text);
        }
    }
}
