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
    public partial class DicsWin : Window, INotifyPropertyChanged
    {
        private Dic selectedDic;

        public Dic SelectedDic
        {
            get => selectedDic;
            set
            {
                selectedDic = value;
                Signal();
            }
        }

        public ObservableCollection<Dic> Dics

        {
            get => Data.Dics;
        }
        public DicsWin()
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

        private void AddDics(object sender, RoutedEventArgs e)
        {
            Dics.Add(new Dic { Title = "Новый котяус" });
        }

        private void DeleteDics(object sender, RoutedEventArgs e)
        {
            if (SelectedDic == null)
                return;
            if (MessageBox.Show("Хотите удалить выбранного котяуса?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Dics.Remove(SelectedDic);
            }
        }
    }
}
