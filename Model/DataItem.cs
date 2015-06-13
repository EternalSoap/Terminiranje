using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terminiranje.Model
{
    public class DataItem : IComparable
    {
        public DataItem(string job, float trajanje, float rok, float pocetak =0, float kraj =0, float kasnjenje =0)
        {
            Job = job;
            Trajanje = trajanje;
            Rok = rok;
            Pocetak = pocetak;
            Kraj = kraj;
            Kasnjenje = kasnjenje;
        }

        public string Job { get;  set; }
        public float Trajanje { get;  set; }
        public float Rok { get;  set; }
        public float Pocetak { get;  set; }
        public float Kraj { get; set; }
        public float Kasnjenje { get; set; }

        public int CompareTo(object obj)
        {
            DataItem dataItem = obj as DataItem;
        return this.Trajanje.CompareTo(dataItem.Trajanje);
    }
        
    }
}
