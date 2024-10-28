using EFCoreWebApiCrud.Model;
using EFCoreWebApiCrud.Model.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreWebApiCrud.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private ProductDbContext context;

		public ProductController(ProductDbContext _context)
		{
			this.context = _context;
		}

		[HttpGet]
		[Route("GetAllProducts")]
		public IActionResult GetAllProducts()
		{
			var productList = context.Products.ToList<Product>();
			return Ok(productList);
		}


		[HttpGet]
		[Route("GetProductByProductID")]
		public IActionResult GetProduct(int id)
		{
			Product product = context.Products.SingleOrDefault(x => x.ProductID == id);
			if (product == null)
				return NotFound();
			else
				return Ok(product);
		}

		[HttpPost]
		[Route("CreateNewProduct")]
		public IActionResult CreateProduct(Product product)
		{
			context.Products.Add(product);
			context.SaveChanges();
			return Ok(product.ProductID);
		}

		[HttpPut]
		[Route("UpdateProduct")]
		public IActionResult UpdateProduct(int productID, Product product)
		{
			Product productUpdated = context.Products.FirstOrDefault(x => x.ProductID == productID);

			if (productUpdated != null)
			{
				productUpdated.ProductName = product.ProductName;
				productUpdated.ProductDescription = product.ProductDescription;
				productUpdated.Brand = product.Brand;
				productUpdated.Price = product.Price;
				productUpdated.UpdateDate = product.UpdateDate;
				productUpdated.ImageName = product.ImageName;

				context.Products.Update(productUpdated);
				context.SaveChanges();
				return Ok(productUpdated);
			}
			else
				return NotFound();
		}

		[HttpDelete]
		[Route("DeleteProduct")]
		public IActionResult DeleteProduct(int productID)
		{
			Product product = context.Products.FirstOrDefault(x => x.ProductID == productID);

			if(product == null) 
				return  NotFound();

			context.Products.Remove(product);
			context.SaveChanges();
			return Ok(product);
		}
	}
}