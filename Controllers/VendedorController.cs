using AgenciaSpring.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgenciaSpring.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VendedorController : ControllerBase
	{
		private readonly VendedorDBContext _context;

		public VendedorController(VendedorDBContext context)
		{
			_context = context;
		}

		//
		[HttpGet]
		public IEnumerable<Vendedor> GetVendedor()
		{
			return _context.Vendedor;
		}

		//
		[HttpGet("{id}")]
		public IActionResult GetVendedorPorId(int id)
		{
			Vendedor vendedor = _context.Vendedor.SingleOrDefault(modelo => modelo.VendedorId == id);
			if (vendedor == null)
			{
				return NotFound();
			}
			return new ObjectResult(vendedor);
		}

		//
		[HttpPost]
		public IActionResult CriarVendedor(Vendedor item)
		{
			if (item == null)
			{
				return BadRequest();
			}

			_context.Vendedor.Add(item);
			_context.SaveChanges();
			return new ObjectResult(item);

		}

		//
		[HttpPut("{id}")]
		public IActionResult Vendedor(int id, Vendedor item)
		{
			if (id != item.VendedorId)
			{
				return BadRequest();
			}
			_context.Entry(item).State = EntityState.Modified;
			_context.SaveChanges();

			return new NoContentResult();
		}

		//
		[HttpDelete("{id}")]
		public IActionResult DeletaVendedor(int id)
		{
			var vendedor = _context.Vendedor.SingleOrDefault(m => m.VendedorId == id);

			if (vendedor == null)
			{
				return BadRequest();
			}

			_context.Vendedor.Remove(vendedor);
			_context.SaveChanges();
			return Ok(vendedor);
		}
	}
}
