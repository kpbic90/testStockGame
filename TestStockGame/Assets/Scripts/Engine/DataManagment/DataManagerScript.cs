using System.Collections.Generic;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.Engine.DataManagment
{
    public class DataManagerScript : MonoBehaviour
    {
        public delegate void HandleDataUpdated();

        public event HandleDataUpdated OnDataUpdated;

        private IDataLoader dataLoader;

        public List<StockItem> StockData { get; private set; }

        public List<Item> Items { get; private set; }

        public List<User> Users { get; private set; }

        private void Start()
        {
            dataLoader = new JsonDataLoader();
            dataLoader.Init("https://raw.githubusercontent.com/kpbic90/testStockGame/main/JsonData");

            UpdateStock();
        }

        public void UpdateStock()
        {
            Users = dataLoader.GetUsers();
            Items = dataLoader.GetItems();
            StockData = dataLoader.GetStockData();

            OnDataUpdated?.Invoke();
        }
    }
}