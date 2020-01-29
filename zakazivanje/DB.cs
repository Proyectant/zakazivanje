using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace zakazivanje
{
	public class DB : DbContext
	{
		public DbSet<Klijent> dbKlijenti { get; set; }
		public DbSet<Tretman> dbTretmani { get; set; }


		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Klijent>().HasKey(k => k.id);
			modelBuilder.Entity<Tretman>().HasKey(p => p.id);
		
		}
	}
}
