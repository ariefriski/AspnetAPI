using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebAPI.Context;
using WebAPI.Repositories.Interface;

namespace WebAPI.Repositories
{
    public class GeneralRepository<Entity> : IRepository<Entity,int> where Entity : class
    {
        MyContext myContext;
        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Create(Entity entity)
        {
            myContext.Set<Entity>().Add(entity);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Delete(int id)
        {
            var data = Get(id);
            myContext.Set<Entity>().Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

      


        public Entity Get(int id)
        {
            var data = myContext.Set<Entity>().Find(id);
            return data;
        }

        public ICollection<Entity> Get()
        {
            return myContext.Set<Entity>().ToList();
        }

        public int Update(Entity entity)
        {
            myContext.Set<Entity>().Update(entity);
            var data = myContext.SaveChanges();
            return data;
        }
    }
}
