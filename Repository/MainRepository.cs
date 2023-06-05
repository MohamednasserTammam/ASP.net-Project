using testCoreApp.Base;
using testCoreApp.Data;

namespace testCoreApp.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        public MainRepository(AppDbContext context) { 

            this.context = context;
        
        }

        protected AppDbContext context;
        public T FindByID(int id)
        {
            return context.Set<T>().Find(id);
        }
    }
}
