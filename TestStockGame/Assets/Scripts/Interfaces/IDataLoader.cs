using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Models;

namespace Assets.Scripts.Interfaces
{
    public interface IDataLoader
    {
        void Init(string connStr);
        Task<List<User>> GetUsers();
        Task<List<Item>> GetItems();
        Task<List<StockItem>> GetStockData();
        Task<byte[]> LoadUserAvatar(string avatarName);
    }
}