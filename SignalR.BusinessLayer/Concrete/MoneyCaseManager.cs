using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class MoneyCaseManager : IMoneyCaseService
    {
        private readonly IMoneyCaseDal _moneyCaseDal;
        public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
        {
            _moneyCaseDal = moneyCaseDal;
        }      

        public List<MoneyCase> TGetListAll()
        {
            return _moneyCaseDal.GetListAll();
        }

        public void TUpdate(MoneyCase entity)
        {
            _moneyCaseDal.Update(entity);
        }

        // Bunlara Gerek Yok
        public void TAdd(MoneyCase entity)  // Bunlara Gerek Yok
        {
            throw new NotImplementedException(); // Bunlara Gerek Yok
        }
        
        // Bunlara Gerek Yok
        public void TDelete(MoneyCase entity) // Bunlara Gerek Yok
        {
            throw new NotImplementedException(); // Bunlara Gerek Yok
        }
        
        // Bunlara Gerek Yok
        public MoneyCase TGetByID(int id) // Bunlara Gerek Yok
        {
            throw new NotImplementedException(); // Bunlara Gerek Yok
        }
    }
}