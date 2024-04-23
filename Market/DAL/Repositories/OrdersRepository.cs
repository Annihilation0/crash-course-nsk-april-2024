using Market.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.DAL.Repositories;

internal class OrdersRepository
{
    private readonly RepositoryContext _context;

    public OrdersRepository()
    {
        _context = new RepositoryContext();
    }

    public async Task<DbResult> CreateOrderAsync(Order order)
    {
        try
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return DbResult.Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return DbResult.UnknownError();
        }
    }

    public async Task<DbResult> ChangeStateForOrder(Guid orderId, OrderState newState)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);

        if (order is null)
            return DbResult.NotFound();

        order.State = newState;

        try
        {
            await _context.SaveChangesAsync();
            return DbResult.Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return DbResult.UnknownError();
        }
    }

    public async Task<DbResult<IReadOnlyCollection<Order>>> GetOrdersForSeller(Guid sellerId, bool onlyCreated,
        bool all)
    {
        var query = _context.Orders.Where(o => o.SellerId == sellerId);

        if (onlyCreated)
        {
            query = query.Where(o => o.State == OrderState.Created);
        }

        var orders = await query.ToListAsync();
        return DbResult<IReadOnlyCollection<Order>>.Ok(orders);
    }
}