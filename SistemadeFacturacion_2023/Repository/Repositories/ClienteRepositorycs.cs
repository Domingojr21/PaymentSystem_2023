using SistemadeFacturacion_2023.Context;
using SistemadeFacturacion_2023.Models;
using SistemadeFacturacion_2023.Repository.Core;
using SistemadeFacturacion_2023.Repository.Interfaces;

namespace SistemadeFacturacion_2023.Repository.Repositories
{
    public class ClienteRepositorycs : BaseRepository<Clientes>, IClienteRepository
    {
        private readonly FacturaContext _context;
        public ClienteRepositorycs(FacturaContext context) : base(context)
        {
           _context = context;
        }
    }
}
