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
    public partial class XozsWin : Window, INotifyPropertyChanged
    {
        private Xozs selectedXozs;

        public Xozs SelectedXozs
        {
            get => selectedXozs;
            set
            {
                selectedXozs = value;
                Signal();
            }
        }

        public ObservableCollection<Xozs> Xozss
        {
            get => Data.Xozss;
        }
        public XozsWin()
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

        private void AddXozs(object sender, RoutedEventArgs e)
        {
            Xozss.Add(new Xozs { LastName = "Фамилия" });
        }

        private void DeleteXozs(object sender, RoutedEventArgs e)
        {
            if (SelectedXozs == null)
                return;
            if (MessageBox.Show("Действительно удалить выбранного куратора?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Xozss.Remove(SelectedXozs);
            }
        }
    }
}
