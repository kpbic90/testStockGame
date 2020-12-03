using System.Collections.Generic;

namespace Assets.Scripts.Interfaces
{
    public interface IDataLoader
    {
        void Init(string connStr);
        IEnumerable<IUser> GetUsers();
        IEnumerable<IItem> GetItems();
        IEnumerable<IStockItem> GetStockData();
    }
}