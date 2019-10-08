using System.Collections.Generic;
using System.IO;
using OTSSCore.DomainServices;
using OTSSCore.Entities;

namespace OTSSCore.ApplicationServices.Impl
{
    public class TShirtService: ITShirtService
    {
        private ITShirtRepository _repo;

        public TShirtService(ITShirtRepository repo)
        {
            _repo = repo;
        }

        public List<TShirt> GetAllTshirts()
        {
            return _repo.GetAllTshirts(null);
        }

        public TShirt GetTShirt(int id)
        {
            return _repo.GetTShirt(id);
        }

        public TShirt DeleteTShirt(int id)
        {
            return _repo.DeleteTShirt(id);
        }

        public TShirt UpdateTshirt(TShirt tshirt)
        {
            return _repo.UpdateTshirt(tshirt);
        }

        public List<TShirt> GetFilteredTShirts(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                throw new InvalidDataException("Current page and items pr page must be more than 0 or 0");
            }

            if ((filter.CurrentPage - 1) * filter.ItemsPrPage >= _repo.Count())
            {
                throw new InvalidDataException("Index out of bound to high page");
            }
            return _repo.GetAllTshirts(filter);
        }

        public TShirt CreateTshirt(TShirt NewTShirt)
        {
            return _repo.CreateTshirt(NewTShirt);
        }
    }
}