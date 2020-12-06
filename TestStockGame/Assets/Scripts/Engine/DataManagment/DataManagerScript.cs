using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.Engine.DataManagment
{
    public class DataManagerScript : MonoBehaviour
    {
        public delegate void HandleDataUpdated();
        public delegate void HandleLastResetDateUpdated();

        public event HandleDataUpdated OnDataUpdated;
        public event HandleLastResetDateUpdated OnLastResetDateUpdated;

        private IDataLoader _dataLoader;
        private SavedDataManager _savedDataManager;

        public List<StockItem> StockData { get; private set; }

        public List<Item> Items { get; private set; }

        public List<User> Users { get; private set; }

        private void Start()
        {
            _savedDataManager = new SavedDataManager();
            _dataLoader = new JsonDataLoader();
            _dataLoader.Init("https://raw.githubusercontent.com/kpbic90/testStockGame/main/JsonData");

            UpdateStock();
        }

        public void CallUpdateStock()
        {
            UpdateStock();
            UpdateResetDate();
        }

        private void UpdateResetDate()
        {
            _savedDataManager.SaveResetDate(DateTime.Now);
            OnLastResetDateUpdated?.Invoke();
        }

        private async void UpdateStock()
        {
            Users = await _dataLoader.GetUsers();
            Items = await _dataLoader.GetItems();
            StockData = await _dataLoader.GetStockData();

            foreach (var user in Users)
            {
                LoadUserImage(user);
            }

            foreach (var stockItem in StockData)
            {
                stockItem.Item = Items.Single(s => s.Id == stockItem.ItemId);
                stockItem.User = Users.Single(s => s.Id == stockItem.TraderId);
            }

            OnDataUpdated?.Invoke();
        }

        private async void LoadUserImage(User user)
        {
            var imageArray = await _dataLoader.LoadUserAvatar(user.AvatarUrl);
            var texture = new Texture2D(1, 1);
            texture.LoadImage(imageArray);
            var pivot = new Vector2(0.5f, 0.5f);
            var rect = new Rect(0, 0, texture.width, texture.height);
            user.Sprite = Sprite.Create(texture, rect, pivot);
        }

        public void SaveLastResetDate(DateTime date)
        {
            _savedDataManager.SaveResetDate(date);
        }

        public DateTime LastResetDate
        {
            get => _savedDataManager.GetLastResetDate();
            set => _savedDataManager.SaveResetDate(value);
        }
    }
}