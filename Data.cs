using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfApp2
{
    static class Data
    {
        public static ObservableCollection<Dic> Dics = new ObservableCollection<Dic>();
        public static ObservableCollection<Cat> Cats = new ObservableCollection<Cat>();
        public static ObservableCollection<Ishs> Ishss = new ObservableCollection<Ishs>();
        public static ObservableCollection<Xozs> Xozss = new ObservableCollection<Xozs>();
    }
}
