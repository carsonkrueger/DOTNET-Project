using ASPNET_BACKEND.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_BACKEND.Controller;

[ApiController]
[Route("Customer")]
public class CustomerController : ControllerBase
{
    private readonly OnlineStoreContext _context;

    public CustomerController(OnlineStoreContext context)
    {
        _context = context;
    }

    // GET: Customer/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomerById([FromRoute] int id)
    {

        Customer? c = await _context.Customers.FindAsync(id);
        
        if (c == null)
        {
            return NotFound();
        }
        
        return Ok(c);
    }

    // PUT: Customer
    [HttpPut]
    public async Task<ActionResult> UpdateCustomer([FromBody] Customer updated)
    {
        _context.Update(updated);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
