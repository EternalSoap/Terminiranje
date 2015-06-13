using System.Windows;
using System.Windows.Controls;

namespace Terminiranje
{
    /// <summary>
    /// Description for TableView.
    /// </summary>
    public partial class TableView : Window
    {
        int i = 0;
        int j = 0;

        /// <summary>
        /// Initializes a new instance of the TableView class.
        /// </summary>
        public TableView()
        {
            InitializeComponent();
            
            
        }

        public void addList(ListView listView)
        {
            
            dataGrid.Children.Add(listView);

            Grid.SetColumn(listView, i);
            Grid.SetRow(listView, j);
            i++;
            if (i == 2) { i = 0; j++; }            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        public void reset(){
            this.Show();
            i = 0;
            j = 0;
        }
    }
}