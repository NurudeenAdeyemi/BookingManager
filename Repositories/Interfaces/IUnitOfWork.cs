namespace BookingManager.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}
