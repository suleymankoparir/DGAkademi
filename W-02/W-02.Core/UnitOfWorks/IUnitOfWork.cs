namespace W_02.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
