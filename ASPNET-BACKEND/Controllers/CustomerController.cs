using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using OnlineStore.InputModels;
using ASPNET_BACKEND.Contexts;

namespace ASPNET_BACKEND.Controller;

[ApiController]
public class CustomerController : ControllerBase
{
    private readonly OnlineStoreContext _context;

    public CustomerController(OnlineStoreContext context)
    {
        _context = context;
    }

    // GET: Customer/{id}
    [HttpGet]
    [Route("customers/{customerId}")]
    public async Task<ActionResult<Customer>> GetCustomerById([FromRoute] int customerId)
    {
        Customer? c = await _context.Customers.FindAsync(customerId);
        
        if (c == null)
            return NotFound();

        return Ok(c);
    }

    // PUT: Customer
    [HttpPut]
    [Route("customers/{id}")]
    public async Task<ActionResult> UpdateCustomer([FromBody] Customer updated)
    {
        _context.Update(updated);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        
        return Ok();
    }

    [HttpDelete]
    [Route("customers/{id}")]
    public async Task<IActionResult> DeleteCustomerById(int id)
    {
        _context.Remove(id);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return Ok();
    }

    [HttpGet]
    [Route("customers/{id}/orders")]
    public async Task<ActionResult<IEnumerable<Order>>> GetAllOrdersByCustomerId([FromRoute] int id)
    {
        try
        {
            var orders = await _context.Orders.Where(o => o.Customer.Id == id).ToListAsync();

            if (!orders.Any())
                return NotFound();

            return orders;
        }
        catch (Exception)
        {
            return StatusCode(500);
        }

    }

    [HttpGet]
    [Route("customers/{customerId}/orders/{orderId}")]
    public async Task<ActionResult<Order>> GetOrderByCustomerId([FromRoute] int customerId, [FromRoute] int orderId)
    {
        var o = await _context.Orders.Where(o => o.Customer.Id == customerId && o.Id == orderId).OrderBy(o => o.OrderPlaced).FirstAsync();

        if (o == null)
            return NotFound();

        return o;
    }

    [HttpPost]
    [Route("customers/{customerId}/orders")]
    public async Task<ActionResult> CreateOrderByCustomerId([FromRoute] int customerId, [FromBody] IEnumerable<OrderDetailInput> orderDetailsInput)
    {
        try
        {
            var newOrder = new Order()
            {
                CustomerId = customerId,
                OrderPlaced = DateTime.Now,
            };

            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            OrderDetail[] newDetails = new OrderDetail[orderDetailsInput.Count()];
            int i = 0;

            foreach (var detail in orderDetailsInput)
            {
                var d = new OrderDetail()
                {
                    OrderId = newOrder.Id,
                    Quantity = detail.Quantity,
                    ProductId = detail.ProductId,
                };
                newDetails[i] = d;
                i++;
            }

            await _context.OrderDetails.AddRangeAsync(newDetails);
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
        
        return Ok();
    }
}
