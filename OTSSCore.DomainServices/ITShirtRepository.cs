using System.Collections.Generic;
using OTSSCore.Entities;

namespace OTSSCore.DomainServices
{
    public interface ITShirtRepository
    {
        List<TShirt> GetAllTshirts();

        TShirt GetTShirt(int id);

        TShirt CreateTshirt(TShirt NewTShirt);

        TShirt DeleteTShirt(int id);

        TShirt UpdateTshirt(TShirt tshirt);
    }
}