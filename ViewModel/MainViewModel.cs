using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Data;
using Terminiranje.Model;

namespace Terminiranje.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        public const string JobPropertyName = "Job";
        public const string TrajanjePropertyName = "Trajanje";
        public const string RokPropertyName = "Rok";
        public const string PocetakPropertyName = "Pocetak";
        public const string KrajPropertyName = "Kraj";
        public const string KasnjenjePropertyName = "Kasnjenje";
        private string _job;
        private float _trajanje;
        private float _rok;
        private float _pocetak;
        private float _kraj;
        private float _kasnjenje;
        public List<ListView> Liste;
        public bool[] TablesToDraw = new bool[5];
        public TableView tableView;
        
      
        



        public string Job
        {
            get
            {
                return _job;
            }
            set
            {
                if (_job == value) return;
                _job = value;
                RaisePropertyChanged(JobPropertyName);
            }
        }

        public float Trajanje
        {
            get
            {
                return _trajanje;
            }
            set
            {
                if (_trajanje == value) return;
                _trajanje = value;
                RaisePropertyChanged(TrajanjePropertyName);
            }
        }

        public float Rok
        {
            get
            {
                return _rok;
            }
            set
            {
                if (_rok == value) return;
                _rok = value;
                RaisePropertyChanged(RokPropertyName);
            }
        }
        public float Pocetak
        {
            get
            {
                return _pocetak;
            }
            set
            {
                if (_pocetak == value) return;
                _pocetak = value;
                RaisePropertyChanged(PocetakPropertyName);
            }
        }
        public float Kraj
        {
            get
            {
                return _kraj;
            }
            set
            {
                if (_kraj == value) return;
                _kraj = value;
                RaisePropertyChanged(KrajPropertyName);
            }
        }
        public float Kasnjenje
        {
            get
            {
                return _kasnjenje;
            }
            set
            {
                if (_kasnjenje == value) return;
                _kasnjenje = value;
                RaisePropertyChanged(KasnjenjePropertyName);
            }
        }

        public ObservableCollection<DataItem> list { get;private set; }
        public List<DataItem> Data1;
        public List<DataItem> Data2;
        public List<DataItem> Data3;
        public List<DataItem> Data4;
        public List<DataItem> Data5;

        

        public RelayCommand addToTable {get; private set;}
        public RelayCommand addView { get; private set; }
        public RelayCommand setTablesToDraw0 { get; set; }
        public RelayCommand setTablesToDraw1 { get; set; }
        public RelayCommand setTablesToDraw2 { get; set; }
        public RelayCommand setTablesToDraw3 { get; set; }
        public RelayCommand setTablesToDraw4 { get; set; }
        
        public MainViewModel(IDataService dataService)
        {
            
            tableView = new TableView();
            list = new ObservableCollection<DataItem>();
            addToTable = new RelayCommand(add);
            addView = new RelayCommand(addTableView);
            setTablesToDraw0 = new RelayCommand(() => TablesToDraw[0] = !TablesToDraw[0]);
            setTablesToDraw1 = new RelayCommand(() => TablesToDraw[1] = !TablesToDraw[1]);
            setTablesToDraw2 = new RelayCommand(() => TablesToDraw[2] = !TablesToDraw[2]);
            setTablesToDraw3 = new RelayCommand(() => TablesToDraw[3] = !TablesToDraw[3]);
            setTablesToDraw4 = new RelayCommand(() => TablesToDraw[4] = !TablesToDraw[4]);

           
           
           
        }

        private void addTableView()
        {
            Data1 = new List<DataItem>();
            Data2 = new List<DataItem>();
            Data3 = new List<DataItem>();
            Data4 = new List<DataItem>();
            Data5 = new List<DataItem>();
            foreach (DataItem el in list) {
                Data1.Add(new DataItem(el.Job,el.Trajanje,el.Rok));
                Data2.Add(new DataItem(el.Job, el.Trajanje, el.Rok));
                Data3.Add(new DataItem(el.Job, el.Trajanje, el.Rok));
                Data4.Add(new DataItem(el.Job, el.Trajanje, el.Rok));
                Data5.Add(new DataItem(el.Job, el.Trajanje, el.Rok));
            }
            Data2.Sort(delegate(DataItem x, DataItem y)
            {
                return x.Rok.CompareTo(y.Rok);
            });
            Data3.Sort(delegate(DataItem x, DataItem y)
            {
                return (x.Rok-x.Trajanje).CompareTo(y.Rok-y.Trajanje);
            });
            Data4.Sort(delegate(DataItem x, DataItem y)
            {
                if (x.Rok / x.Trajanje == y.Rok / y.Trajanje) return x.Trajanje.CompareTo(y.Trajanje);
                return (x.Rok/x.Trajanje).CompareTo(y.Rok/y.Trajanje);
            });
            Data5.Sort(delegate(DataItem x, DataItem y)
            {
                return x.Trajanje.CompareTo(y.Trajanje);
            });


            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0)
                {
                    Data1[0].Pocetak = 0F;
                    Data2[0].Pocetak = 0F;
                    Data3[0].Pocetak = 0F;
                    Data4[0].Pocetak = 0F;
                    Data5[0].Pocetak = 0F;

                    Data1[0].Kraj = (float)Data1[0].Pocetak + Data1[0].Trajanje;
                    Data1[0].Kasnjenje = (float)Data1[0].Kraj - Data1[0].Rok <= 0 ? 0 : Data1[0].Kraj - Data1[0].Rok;

                    Data2[0].Kraj = (float)Data2[0].Pocetak + Data2[0].Trajanje;
                    Data2[0].Kasnjenje = (float)Data2[0].Kraj - Data2[0].Rok < 0 ? 0 : Data2[0].Kraj - Data2[0].Rok;

                    Data3[0].Kraj = (float)Data3[0].Pocetak + Data3[0].Trajanje;
                    Data3[0].Kasnjenje = (float)Data3[0].Kraj - Data3[0].Rok < 0 ? 0 : Data3[0].Kraj - Data3[0].Rok;

                    Data4[0].Kraj = (float)Data4[0].Pocetak + Data4[0].Trajanje;
                    Data4[0].Kasnjenje = (float)Data4[0].Kraj - Data4[0].Rok < 0 ? 0 : Data4[0].Kraj - Data4[0].Rok;

                    Data5[0].Kraj = (float)Data5[0].Pocetak + Data5[0].Trajanje;
                    Data5[0].Kasnjenje = (float)Data5[0].Kraj - Data5[0].Rok < 0 ? 0 : Data5[0].Kraj - Data5[0].Rok;
                }
                else
                {
                    Data1[i].Pocetak = (float)Data1[i - 1].Kraj;
                    Data2[i].Pocetak = (float)Data2[i - 1].Kraj;
                    Data3[i].Pocetak = (float)Data3[i - 1].Kraj;
                    Data4[i].Pocetak = (float)Data4[i - 1].Kraj;
                    Data5[i].Pocetak = (float)Data5[i - 1].Kraj;

                    Data1[i].Kraj = Data1[i].Pocetak + Data1[i].Trajanje;
                    Data1[i].Kasnjenje = Data1[i].Kraj - Data1[i].Rok <= 0 ? 0 : Data1[i].Kraj - Data1[i].Rok;

                    Data2[i].Kraj = Data2[i].Pocetak + Data2[i].Trajanje;
                    Data2[i].Kasnjenje = Data2[i].Kraj - Data2[i].Rok < 0 ? 0 : Data2[i].Kraj - Data2[i].Rok;

                    Data3[i].Kraj = Data3[i].Pocetak + Data3[i].Trajanje;
                    Data3[i].Kasnjenje = Data3[i].Kraj - Data3[i].Rok < 0 ? 0 : Data3[i].Kraj - Data3[i].Rok;

                    Data4[i].Kraj = Data4[i].Pocetak + Data4[i].Trajanje;
                    Data4[i].Kasnjenje = Data4[i].Kraj - Data4[i].Rok < 0 ? 0 : Data4[i].Kraj - Data4[i].Rok;

                    Data5[i].Kraj = Data5[i].Pocetak + Data5[i].Trajanje;
                    Data5[i].Kasnjenje = Data5[i].Kraj - Data5[i].Rok < 0 ? 0 : Data5[i].Kraj - Data5[i].Rok;

                }
            }
            createTable();
            tableView.dataGrid.Children.Clear();
            tableView.reset();
            for (int i = 0; i < 5; i++)
            {
                if (TablesToDraw[i])
                {
                    tableView.dataGrid.Children.Remove(Liste[i]);
                    tableView.addList(Liste[i]);
                }
            }
            
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}

        private void add() {
            if (Job == "" || Trajanje == 0 || Rok == 0) return;
            foreach (DataItem el in list)
            {
                if (el.Job == Job) return;
            }
            list.Add(new DataItem(Job,Trajanje,Rok));
            Job = "";
            Trajanje = 0;
            Rok = 0;            
        }

        private void createTable()
        {
            Liste = new List<ListView>();
            for (int i = 0; i < 5; i++) { 
                ListView listView = new ListView();
                GridView gridView = new GridView();
                GridViewColumn gridViewColumn0 = new GridViewColumn();
                GridViewColumn gridViewColumn1 = new GridViewColumn();
                GridViewColumn gridViewColumn2 = new GridViewColumn();
                GridViewColumn gridViewColumn3 = new GridViewColumn();
                GridViewColumn gridViewColumn4 = new GridViewColumn();
                GridViewColumn gridViewColumn5 = new GridViewColumn();
                GridViewColumn gridViewColumn6 = new GridViewColumn();
                switch (i)
                {
                    case 0: gridViewColumn0.Header = "FCFS"; gridViewColumn0.Width = 40; gridViewColumn0.DisplayMemberBinding = new Binding("NISTA"); gridView.Columns.Add(gridViewColumn0); break;
                    case 1: gridViewColumn0.Header = "DDATE"; gridViewColumn0.Width = 40; gridViewColumn0.DisplayMemberBinding = new Binding("NISTA"); gridView.Columns.Add(gridViewColumn0); break;
                    case 2: gridViewColumn0.Header = "SLACK"; gridViewColumn0.Width = 40; gridViewColumn0.DisplayMemberBinding = new Binding("NISTA"); gridView.Columns.Add(gridViewColumn0); break;
                    case 3: gridViewColumn0.Header = "CR"; gridViewColumn0.Width = 40; gridViewColumn0.DisplayMemberBinding = new Binding("NISTA"); gridView.Columns.Add(gridViewColumn0); break;
                    case 4: gridViewColumn0.Header = "SPT"; gridViewColumn0.Width = 40; gridViewColumn0.DisplayMemberBinding = new Binding("NISTA"); gridView.Columns.Add(gridViewColumn0); break;
                }
                gridViewColumn1.DisplayMemberBinding = new Binding("Job");
                gridViewColumn1.Header = "Job";
                gridViewColumn1.Width = 40;
                gridView.Columns.Add(gridViewColumn1);
                gridViewColumn2.DisplayMemberBinding = new Binding("Pocetak");
                gridViewColumn2.Header = "Pocetak";
                gridViewColumn2.Width = 50;
                gridView.Columns.Add(gridViewColumn2);
                gridViewColumn3.DisplayMemberBinding = new Binding("Trajanje");
                gridViewColumn3.Header = "Trajanje";
                gridViewColumn3.Width = 50;
                gridView.Columns.Add(gridViewColumn3);
                gridViewColumn4.DisplayMemberBinding = new Binding("Kraj");
                gridViewColumn4.Header = "Kraj";
                gridViewColumn4.Width = 66;
                gridView.Columns.Add(gridViewColumn4);
                gridViewColumn5.DisplayMemberBinding = new Binding("Rok");
                gridViewColumn5.Header = "Rok";
                gridViewColumn5.Width = 66;
                gridView.Columns.Add(gridViewColumn5);
                gridViewColumn6.DisplayMemberBinding = new Binding("Kasnjenje");
                gridViewColumn6.Header = "Kasnjenje";
                gridViewColumn6.Width = 66;
                gridView.Columns.Add(gridViewColumn6);
                listView.View = gridView;
                Liste.Add(listView);
        }
            Liste[0].ItemsSource = Data1;
            Liste[1].ItemsSource = Data2;
            Liste[2].ItemsSource = Data3;
            Liste[3].ItemsSource = Data4;
            Liste[4].ItemsSource = Data5;


        }

        private void SortAndCalculate()
        {
            

            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void InvokePropertyChanged(string propertyName)
        {
            var e = new PropertyChangedEventArgs(propertyName);
            PropertyChangedEventHandler changed = PropertyChanged;
            if (changed != null) changed(this, e);
        }
    }
}