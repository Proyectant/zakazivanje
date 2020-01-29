using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zakazivanje
{
    public class Tretman
    {

        public int id { get; set; }

        public string Naziv { get; set; }
        public decimal Cena { get; set; }

        public string PonovniPregled  { get; set; }

        public Tretman () { }

		public Tretman (string n, decimal c, string pp)
		{

			Naziv = n;
			Cena = c;
			PonovniPregled = pp;
		}
		public override string ToString()
		{
			return $"{id}, {Naziv}, {Cena}, {PonovniPregled}";
		}

	}
}
