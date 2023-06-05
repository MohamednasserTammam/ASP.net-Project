namespace testCoreApp.Base
{
    public interface IRepository<T> where T : class
    {
        T FindByID(int id);
    }
}
