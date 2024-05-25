

using BookingManager.Entities;
using System.Linq.Expressions;

namespace BookingManager.Repositories.Interfaces
{
    public interface IApartmentRepository
    {
        Apartment AddApartment(Apartment apartment);
        Apartment UpdateApartment(Apartment apartment);
        Apartment FindById(int id);
        Apartment GetApartment(Expression<Func<Apartment, bool>> predicate);
        IEnumerable<Apartment> GetApartments(Expression<Func<Apartment, bool>> predicate = null);
        bool Exist(Expression<Func<Apartment, bool>> predicate);
    }
}
