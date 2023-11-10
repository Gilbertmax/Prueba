using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourSolution.Data;

namespace YourSolucion.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly YourDbContext _context;

        public ClienteRepository(YourDbContext context)
        {
            _context = context;
        }

        public Cliente ObtenerClientePorId(int clienteId)
        {
            return _context.Clientes.FirstOrDefault(c => c.ClienteID == clienteId);
        }

        public List<Cliente> ObtenerTodosClientes()
        {
            return _context.Clientes.ToList();
        }

        public void CrearCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void ActualizarCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public void EliminarCliente(int clienteId)
        {
            var cliente = _context.Clientes.Find(clienteId);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }


}
