namespace Contracts
{
    public interface IRepositoryManager
    {
        ICountryRepository Country { get; }
        // IEmployeeRepository Employee { get; }
        void Save();
    }
}
