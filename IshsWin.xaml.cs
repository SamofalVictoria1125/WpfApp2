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
using System.Windows.Shapes;

namespace WpfApp2
{
    public partial class IshsWin : Window, INotifyPropertyChanged
    {
        private Ishs selectedIshs;

        public Ishs SelectedIshs
        {
            get => selectedIshs;
            set
            {
                selectedIshs = value;
                Signal();
            }
        }
        public ObservableCollection<Ishs> Ishss
        {
            get => Data.Ishss;
        }
        public IshsWin()
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

        private void AddIshs(object sender, RoutedEventArgs e)
        {
            Ishss.Add(new Ishs { Poroda = "Новый котяус" });
        }

        private void DeleteIshs(object sender, RoutedEventArgs e)
        {
            if (SelectedIshs == null)
                return;
            if (MessageBox.Show("Действительно удалить выбранную породу?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Ishss.Remove(SelectedIshs);
            }
        }

    }
}
