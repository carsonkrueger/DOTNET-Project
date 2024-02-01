using ASPNET_BACKEND.Contexts;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;

namespace ASPNET_BACKEND.Services;

public class CRUD
{
    private readonly OnlineStoreContext _context;

    public CRUD(OnlineStoreContext context)
    {
        _context = context;
    }

    public async Task<object?> GetEntityById(Type entityType,int id)
    {
        return await _context.FindAsync(entityType, id);
    }

    public async void Save(object entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }


}
