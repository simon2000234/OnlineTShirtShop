using System.Collections.Generic;
using System.Linq;
using OTSSCore.DomainServices;
using OTSSCore.Entities;

namespace Infrastructure.SQL.Repositories
{
    public class TShirtRepo: ITShirtRepository
    {
        private OTSSContext _context;

        public TShirtRepo(OTSSContext context)
        {
            _context = context;
        }

        public List<TShirt> GetAllTshirts()
        {
            return _context.TShirts.ToList();
        }

        public TShirt GetTShirt(int id)
        {
            throw new System.NotImplementedException();
        }

        public TShirt CreateTshirt(TShirt NewTShirt)
        {
            throw new System.NotImplementedException();
        }

        public TShirt DeleteTShirt(int id)
        {
            throw new System.NotImplementedException();
        }

        public TShirt UpdateTshirt(TShirt tshirt)
        {
            throw new System.NotImplementedException();
        }
    }
}