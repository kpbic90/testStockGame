using System.Collections.Generic;
using System.Net;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Engine
{
    public class JsonDataLoader : IDataLoader
    {
        private string _url = string.Empty;

        public void Init(string connStr)
        {
            _url = connStr;
        }

        public IEnumerable<IUser> GetUsers()
        {
            using (var wc = new WebClient())
            {
                var url = $"{_url}/users.json";
                var response = wc.DownloadString(url);
                var users = JsonUtility.FromJson<IEnumerable<IUser>>(response);
                return users;
            }
        }

        public IEnumerable<IItem> GetItems()
        {
            using (var wc = new WebClient())
            {
                var url = $"{_url}/items.json";
                var response = wc.DownloadString(url);
                var items = JsonUtility.FromJson<IEnumerable<IItem>>(response);
                return items;
            }
        }

        public IEnumerable<IStockItem> GetStockData()
        {
            using (var wc = new WebClient())
            {
                var url = $"{_url}/stock.json";
                var response = wc.DownloadString(url);
                var stockData = JsonUtility.FromJson<IEnumerable<IStockItem>>(response);
                return stockData;
            }
        }
    }
}