[ApiController]
[Route("api/cart")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpPost("add-to-cart/{clienteId}/{articuloId}/{cantidad}")]
    public IActionResult AddToCart(int clienteId, int articuloId, int cantidad)
    {
        _cartService.AddToCart(clienteId, articuloId, cantidad);
        return Ok();
    }

    [HttpDelete("remove-from-cart/{clienteId}/{articuloId}")]
    public IActionResult RemoveFromCart(int clienteId, int articuloId)
    {
        _cartService.RemoveFromCart(clienteId, articuloId);
        return Ok();
    }

    [HttpGet("get-cart/{clienteId}")]
    public IActionResult GetCart(int clienteId)
    {
        var cartContent = _cartService.GetCart(clienteId);
        return Ok(cartContent);
    }
}
