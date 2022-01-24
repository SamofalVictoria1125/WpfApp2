using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApp2
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Cat selectedCat;

        public ObservableCollection<Cat> Cats

        {
            get => Data.Cats;
        }
        public ObservableCollection<Ishs> Ishsss
        {
            get => Data.Ishss;
        }

        public Cat SelectedCat
        {
            get => selectedCat;
            set
            {
                selectedCat = value;
                Signal();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        void Signal([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this,
                      new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void AddCat(object sender, RoutedEventArgs e) => Cats.Add(new Cat
        {
            Name = "Новый котяус",
            Birthday = DateTime.Today
        });

        private void DeleteCat(object sender, RoutedEventArgs e)
        {
            if (SelectedCat == null)
                return;
            if (MessageBox.Show("Вы хотите удалить данного котяуса?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Cats.Remove(SelectedCat);
                SelectedCat = null;
            }
        }

        private void OpenDic(object sender, RoutedEventArgs e)
        {
            DicsWin win = new DicsWin();
            win.ShowDialog();
        }

        private void OpenIshs(object sender, RoutedEventArgs e)
        {
            IshsWin win = new IshsWin();
            win.ShowDialog();
        }

        private void OpenXozs(object sender, RoutedEventArgs e)
        {
            XozsWin win = new XozsWin();
            win.ShowDialog();
        }
    }
}
