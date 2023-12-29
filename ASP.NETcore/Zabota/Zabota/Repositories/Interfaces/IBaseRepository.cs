namespace Zabota.Repositories.Interfaces
{
    public interface IBaseRepository<TDbModel>
    {
        public List<TDbModel> GetAll();
        public TDbModel? Get(int id);
        public TDbModel Post(TDbModel model);
        public TDbModel Put(TDbModel model);
        public void Delete(int id);
    }
}
