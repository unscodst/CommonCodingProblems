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


namespace UndoAction
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        Stack<UndoButton> undoOps = new Stack<UndoButton>();
        Random _rng = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }
        private Brush GetRandomBrush()
        {
            byte[] rgb = new byte[3];
            _rng.NextBytes(rgb);

            return new SolidColorBrush(Color.FromRgb(rgb[0], rgb[1], rgb[2]));
        }
        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            undoOps.Push(new UndoButton(Button_1));
            Button_1.Background = GetRandomBrush();
            UpdateList();
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            undoOps.Push(new UndoButton(Button_2));
            Button_2.Background = GetRandomBrush();
            UpdateList();
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            undoOps.Push(new UndoButton(Button_3));
            Button_3.Background = GetRandomBrush();
            UpdateList();
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            if(undoOps.Count > 0)
            {
                undoOps.Pop().Execute();
                UpdateList();
            }
        }

        private void UpdateList()
        {
            StoredColors.Items.Clear();
            foreach(UndoButton action in undoOps)
            {
                StoredColors.Items.Add(action.ToString());
            }
        }
    }
}
