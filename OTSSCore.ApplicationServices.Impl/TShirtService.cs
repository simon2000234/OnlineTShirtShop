using System.Collections.Generic;
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
            return _repo.GetAllTshirts();
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

        public TShirt CreateTshirt(TShirt NewTShirt)
        {
            return _repo.CreateTshirt(NewTShirt);
        }
    }
}