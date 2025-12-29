using E_Com.Models.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace E_Com.Models.Repository.Service
{
    public class Services<T> : IGeneric<T> where T : class
    {
        private readonly AppDBContext _db;
        private DbSet<T> _entity;
        public Services(AppDBContext dBContext) { 
         _db = dBContext;
         _entity=_db.Set<T>();

        
        }
        public async Task<bool> Add(T obj)
        {
              _db.AddAsync(obj);
            int i= await _db.SaveChangesAsync();
            if (i > 0)
            { 
                return  true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var data = await _entity.FindAsync(id);
            if (data != null) {
              _db.Remove(data);
               int i= await _db.SaveChangesAsync();
                if (i > 0) { 
                return true;
                }
                else { return false; }
            }
            return false;
           
        }

        public async Task<List<T>> GetAll()
        {
            return await _entity.ToListAsync();
        }

        public async Task<T> GetSingle(int id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task<bool> Update(T obj)
        {
            _db.Update(obj);
          int i= await _db.SaveChangesAsync();
            if (i > 0)
            {
                return true;
            }
            return false;
        }
    }
}
