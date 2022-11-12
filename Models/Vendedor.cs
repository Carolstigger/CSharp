using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaSpring.Models
{
	[Table("Vendedor")]
	public class Vendedor
	{
		[Key]
		public int VendedorId { get; set; }

		[Required(ErrorMessage = "Informe o nome do Vendedor")]
		[StringLength(50)]
		public string Nome { get; set; }

		[Required(ErrorMessage = "Informe o CPF do Vendedor")]
		[StringLength(11)]
		public string CPF { get; set; }

	}
}
