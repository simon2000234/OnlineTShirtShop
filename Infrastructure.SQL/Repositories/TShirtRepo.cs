using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            return _context.TShirts.FirstOrDefault(ts => ts.Id == id);
        }

        public TShirt CreateTshirt(TShirt NewTShirt)
        {
            _context.Attach(NewTShirt).State = EntityState.Added;
            _context.SaveChanges();
            return NewTShirt;
        }

        public TShirt DeleteTShirt(int id)
        {
            var tshirt = _context.Remove(new TShirt { Id = id }).Entity;
            _context.SaveChanges();
            return tshirt;
        }

        public TShirt UpdateTshirt(TShirt tshirt)
        {
            _context.Attach(tshirt).State = EntityState.Modified;

            _context.SaveChanges();

            return tshirt;
        }
    }
}