namespace E_Com.Models.Repository.Contract
{
    public interface IGeneric <T> where T : class
    {
       Task<bool>  Add(T pro);
        Task<bool> Update(T pro);
        Task<List<T>> GetAll();
       Task<T> GetSingle(int id);
        Task<bool> Delete(int id);

    }
}
