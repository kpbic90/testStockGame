using System.Collections.Generic;
using Assets.Scripts.Models;
using Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Engine
{
    public class StockItemsDrawer : MonoBehaviour
    {
        private const int ItemsInRow = 3;
        [SerializeField] private Transform holderStockItems;
        [SerializeField] private GameObject prefabStockItem;
        [SerializeField] private ScrollRect scrollRect;

        private List<StockItem> stockData;

        public List<StockItem> StockData
        {
            set
            {
                stockData = value;
                DrawItems();
            }
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
    }
}