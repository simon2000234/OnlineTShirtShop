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

        public TShirt CreateTshirt(TShirt NewTShirt)
        {
            throw new System.NotImplementedException();
        }
    }
}