using System;
using System.Collections.Generic;
using System.Linq;
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

using StudentManager.ViewModels;

namespace StudentManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public StudentsViewModel svm { get; set; } = new StudentsViewModel();
        public MainWindow()
        {
            this.DataContext = svm;
            InitializeComponent();
        }

        // Написать здесь обработчик события позор или нет?
    }
}
