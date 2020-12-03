using System.Collections.Generic;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class WindowStockScript : MonoBehaviour
    {
        public delegate void HandleRefreshListCall(WindowStockScript sender);

        [SerializeField] private Transform holderStockItems;
        private List<Item> items;

        [SerializeField] private GameObject prefabStockItem;

        private List<StockItem> stockData;
        private List<User> users;

        public List<StockItem> StockData
        {
            set
            {
                stockData = value;
                DrawItems();
            }
        }

        public List<Item> Items
        {
            set => items = value;
        }

        public List<User> Users
        {
            set => users = value;
        }

        public event HandleRefreshListCall OnRefreshListCall;

        public void NextPage()
        {

        }

        public void PrevPage()
        {

        }

        public void Close()
        {
            Destroy(gameObject);
        }

        private void DrawItems()
        {
            ClearItems();

            if(stockData == null)
                return;

            foreach (var item in stockData)
            {
                InitItem(item);
            }
        }

        private void ClearItems()
        {
            var children = new List<GameObject>();
            foreach (Transform child in holderStockItems)
                children.Add(child.gameObject);
            children.ForEach(child => Destroy(child));
        }

        private void InitItem(StockItem item)
        {
            var go = Instantiate(prefabStockItem
                , new Vector3()
                , Quaternion.identity, holderStockItems);

            var script = go.GetComponent<StockItemScript>();
            script.stockItem = item;
        }
    }
}