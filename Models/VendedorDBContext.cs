using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AgenciaSpring.Models
{

		public class VendedorDBContext : DbContext
		{
			public VendedorDBContext(DbContextOptions<VendedorDBContext> options)
	: base(options)
			{ }

			public DbSet<Vendedor> Vendedor { get; set; }
		}

}
