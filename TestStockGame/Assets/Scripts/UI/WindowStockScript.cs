using System;
using System.Collections.Generic;
using Assets.Scripts.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class WindowStockScript : MonoBehaviour
    {
        public delegate void HandleRefreshListCall(WindowStockScript sender);

        private const int ItemsInRow = 3;

        [SerializeField] private Transform holderStockItems;
        private List<Item> items;
        public DateTime lastResetDate;

        [SerializeField] private GameObject prefabStockItem;
        [SerializeField] private ScrollRect scrollRect;

        private List<StockItem> stockData;

        [SerializeField] private TextMeshProUGUI textTimer;
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
            var rowsCount = holderStockItems.childCount / ItemsInRow;
            var step = 2 * holderStockItems.GetComponent<RectTransform>().sizeDelta.x / rowsCount;
            scrollRect.velocity = new Vector2(-step, 0);
        }

        public void PrevPage()
        {
            var rowsCount = holderStockItems.childCount / ItemsInRow;
            var step = 2 * holderStockItems.GetComponent<RectTransform>().sizeDelta.x / rowsCount;
            scrollRect.velocity = new Vector2(step, 0);
        }

        public void Close()
        {
            Destroy(gameObject);
        }

        public void ResetDiamond()
        {
            // Substract diamonds
            OnRefreshListCall?.Invoke(this);
        }

        public void ResetAd()
        {
            //watch ad
            OnRefreshListCall?.Invoke(this);
        }

        private void DrawItems()
        {
            ClearItems();

            if (stockData == null)
                return;

            foreach (var item in stockData) InitItem(item);
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

        private void Update()
        {
            var value = lastResetDate.AddHours(24) - DateTime.Now;
            if (value.TotalSeconds < 0)
                value = new TimeSpan(0, 0, 0);
            textTimer.text = value.ToString(@"hh\:mm\:ss");
        }
    }
}