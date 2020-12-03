using System.Collections.Generic;
using System.Net;
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

        public List<User> GetUsers()
        {
            using (var wc = new WebClient())
            {
                var url = $"{_url}/users.json";
                var response = wc.DownloadString(url);
                var data = JsonUtility.FromJson<UsersCollection>(response);
                return data.users;
            }
        }

        public List<Item> GetItems()
        {
            using (var wc = new WebClient())
            {
                var url = $"{_url}/items.json";
                var response = wc.DownloadString(url);
                var data = JsonUtility.FromJson<ItemsCollection>(response);
                return data.items;
            }
        }

        public List<StockItem> GetStockData()
        {
            using (var wc = new WebClient())
            {
                var url = $"{_url}/stock.json";
                var response = wc.DownloadString(url);
                var data = JsonUtility.FromJson<StockItemsCollection>(response);
                return data.stockItems;
            }
        }
    }
}