using Microsoft.AspNetCore.Mvc;
using MyHttpClient;
using OnlineStore.Models;
using System.Text.Json;

namespace WebAppDemo.Controllers
{
	public class HomeController : Controller
	{
		public async Task<IActionResult> Index()
		{
			string? json = await new ApiClient("https://localhost:7221/").GetDataAsync("customers/1");
			if (json == null)
			{
				return View(new Customer() { FirstName = "Kenneth", LastName = "Jones"});
			}
			Customer c = JsonSerializer.Deserialize<Customer>(json);
			return View(c);
		}
	}
}
