using BookingManager.Context;
using BookingManager.Entities;
using BookingManager.Repositories.Interfaces;
using System.Linq;
using System.Linq.Expressions;

namespace BookingManager.Repositories.Implementations
{
    public class ApartmentRepository : IApartmentRepository
    {
        protected readonly ApplicationDbContext _context;
        public ApartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Apartment AddApartment(Apartment apartment)
        {
            _context.Apartments.Add(apartment);
            return apartment;
        }

        public bool Exist(Expression<Func<Apartment, bool>> predicate)
        {
            return _context.Apartments.Any(predicate);
        }

        public Apartment FindById(int id)
        {
            return _context.Apartments.Find(id);
        }

        public Apartment GetApartment(Expression<Func<Apartment, bool>> predicate)
        {
            return _context.Set<Apartment>().FirstOrDefault(predicate);
        }

        public IEnumerable<Apartment> GetApartments(Expression<Func<Apartment, bool>> predicate = null)
        {
            if(predicate is null)
            {
                return _context.Apartments.ToList();
            }
            return _context.Apartments.Where(predicate).ToList();
        }

        public Apartment UpdateApartment(Apartment apartment)
        {
            _context.Apartments.Update(apartment);
            return apartment;
        }
    }
}
