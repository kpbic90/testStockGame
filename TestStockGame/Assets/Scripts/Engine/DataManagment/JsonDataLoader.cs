using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.Engine.DataManagment
{
    public class JsonDataLoader : IDataLoader
    {
        private string _url = string.Empty;

        public void Init(string connStr)
        {
            _url = connStr;
        }

        public async Task<List<User>> GetUsers()
        {
            using (var wc = new WebClient())
            {
                var url = $"{_url}/users.json";
                var response = await wc.DownloadStringTaskAsync(url);
                var data = JsonUtility.FromJson<UsersCollection>(response);
                return data.users;
            }
        }

        public async Task<List<Item>> GetItems()
        {
            using (var wc = new WebClient())
            {
                var url = $"{_url}/items.json";
                var response = await wc.DownloadStringTaskAsync(url);
                var data = JsonUtility.FromJson<ItemsCollection>(response);
                return data.items;
            }
        }

        public async Task<List<StockItem>> GetStockData()
        {
            using (var wc = new WebClient())
            {
                var url = $"{_url}/stock.json";
                var response = await wc.DownloadStringTaskAsync(url);
                var data = JsonUtility.FromJson<StockItemsCollection>(response);
                return data.stockItems;
            }
        }

        public async Task<byte[]> LoadUserAvatar(string avatarName)
        {
            using (var wc = new WebClient())
            {
                var url = $"{_url}/UserAvatars/{avatarName}";
                var response = await wc.DownloadDataTaskAsync(new Uri(url));
                return response;
            }
        }
    }
}