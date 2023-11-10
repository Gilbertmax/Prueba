
using YourSolution.Data;

public interface ICartService
{
    void AddToCart(int clienteId, int articuloId, int cantidad);
    void RemoveFromCart(int clienteId, int articuloId);
    List<RelacionClienteArticulo> GetCart(int clienteId);
}

public class CartService : ICartService
{
    private readonly YourDbContext _context;

    public CartService(YourDbContext context)
    {
        _context = context;
    }

    public void AddToCart(int clienteId, int articuloId, int cantidad)
    {
     
    }

    public void RemoveFromCart(int clienteId, int articuloId)
    {
        
    }

    public List<RelacionClienteArticulo> GetCart(int clienteId)
    {
        return new List<RelacionClienteArticulo>();
    }
}
