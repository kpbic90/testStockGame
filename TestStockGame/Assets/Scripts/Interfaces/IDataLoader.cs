using System.Collections.Generic;
using Assets.Scripts.Models;

namespace Assets.Scripts.Interfaces
{
    public interface IDataLoader
    {
        void Init(string connStr);
        List<User> GetUsers();
        List<Item> GetItems();
        List<StockItem> GetStockData();
    }
}