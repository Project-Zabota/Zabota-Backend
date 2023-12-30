namespace Zabota.Repositories.Interfaces
{
    public interface IBaseRepository<TDbModel>
    {
        public List<TDbModel> GetAll();
        public TDbModel? Get(int id);
        public TDbModel Create(TDbModel model);
        public TDbModel Update(TDbModel model);
        public void Delete(int id);
    }
}
