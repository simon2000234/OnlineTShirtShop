using System.Collections.Generic;
using OTSSCore.Entities;

namespace OTSSCore.ApplicationServices
{
    public interface ITShirtService
    {
        List<TShirt> GetAllTshirts();

        TShirt GetTShirt(int id);

        TShirt CreateTshirt(TShirt NewTShirt);

        TShirt DeleteTShirt(int id);

        TShirt UpdateTshirt(TShirt tshirt);

        List<TShirt> GetFilteredTShirts(Filter filter);
    }
}