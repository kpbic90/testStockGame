using System.Collections.Generic;
using Assets.Scripts.Models;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Engine
{
    public class StockItemsDrawer : MonoBehaviour
    {
        private const int ItemsInRow = 3;
        private const int RowsAtScreen = 5;
        private GameObject[] _currentItems;
        private Vector2 _defaultPosition;
        private int _maxX;
        private List<StockItem> _stockData;
        [SerializeField] private Transform holderStockItems;
        [SerializeField] private GameObject prefabStockItem;

        private int CurrentOffset
        {
            get
            {
                if (!holderStockItems || !prefabStockItem)
                    return 0;

                var itemSize = prefabStockItem.GetComponent<RectTransform>().sizeDelta.x;
                var position = Mathf.Abs(holderStockItems.localPosition.x);
                return (int) (position / itemSize);
            }
        }

        public List<StockItem> StockData
        {
            set
            {
                _stockData = value;
                if (_stockData != null)
                    _maxX = (int) (_stockData.Count / ItemsInRow *
                                   prefabStockItem.GetComponent<RectTransform>().sizeDelta.x);
                ResetPosition();
                DrawItems();
            }
        }

        private void Awake()
        {
            _defaultPosition = holderStockItems.localPosition;
        }

        private void DrawItems()
        {
            ClearItems();

            if (_stockData == null)
                return;

            _currentItems = new GameObject[_stockData.Count];

            for (var index = 0; index < _stockData.Count; index++)
            {
                var item = _stockData[index];
                InitItem(item, index);

                if (index >= RowsAtScreen * ItemsInRow)
                    _currentItems[index].SetActive(false);
            }
        }

        private void ShowItems(int offset, int count)
        {
            for (var index = offset; index < Mathf.Min(_stockData.Count, offset + count); index++)
            {
                if (index < 0)
                    continue;

                _currentItems[index].SetActive(true);
            }
        }

        private void HideItems(int offset, int count)
        {
            for (var index = offset; index < Mathf.Min(_stockData.Count, offset + count); index++)
            {
                if (index < 0)
                    continue;

                _currentItems[index].SetActive(false);
            }
        }

        private void ClearItems()
        {
            var children = new List<GameObject>();
            foreach (Transform child in holderStockItems)
                children.Add(child.gameObject);
            children.ForEach(child => Destroy(child));
        }

        private void InitItem(StockItem item, int index)
        {
            var sizes = prefabStockItem.GetComponent<RectTransform>().sizeDelta;
            var position = new Vector3(index / 3, index % 3, 0);
            position = new Vector3(position.x * sizes.x, position.y * sizes.y);

            var go = Instantiate(prefabStockItem);
            go.transform.localPosition = position;
            go.transform.SetParent(holderStockItems, false);

            var script = go.GetComponent<StockItemScript>();
            script.stockItem = item;

            _currentItems[index] = go;
        }

        public void NextPage()
        {
            var step = -prefabStockItem.GetComponent<RectTransform>().sizeDelta.x;
            MoveItems(step);
        }

        public void PrevPage()
        {
            var step = prefabStockItem.GetComponent<RectTransform>().sizeDelta.x;
            MoveItems(step);
        }

        private void ResetPosition()
        {
            holderStockItems.localPosition = _defaultPosition;
        }

        public void MoveItems(float moveX)
        {
            var lastOffset = CurrentOffset;
            var newPosition = new Vector3(holderStockItems.localPosition.x + moveX, holderStockItems.localPosition.y);
            if (newPosition.x > 0 || newPosition.x <= -_maxX)
                return;

            holderStockItems.localPosition = newPosition;
            var newOffset = CurrentOffset;
            if (lastOffset != newOffset)
            {
                var resultOffset = (newOffset + (moveX < 0 ? RowsAtScreen : 0) - 1) * ItemsInRow;
                var deletedRowOffset = (newOffset + (moveX < 0 ? -2 : RowsAtScreen)) * ItemsInRow;
                ShowItems(resultOffset, ItemsInRow);
                HideItems(deletedRowOffset, ItemsInRow);
            }
        }
    }
}