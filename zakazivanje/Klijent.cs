using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zakazivanje
{
   public class Klijent
    {
        public int id { get; set; }

		public string Ime { get; set; }
		public string Prezime { get; set; }

		public string BrojTelefona { get; set; }

		public Klijent() { }
		public Klijent( string ime, string p, string bt)
		{
		
			Ime = ime;
			Prezime = p;
			BrojTelefona = bt;
		}
		public override string ToString()
		{
			return $"{id}, {Ime}, {Prezime}";
		}

	}
}
