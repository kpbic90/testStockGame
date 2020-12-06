using System;
using System.Collections.Generic;
using Assets.Scripts.Engine;
using Assets.Scripts.Engine.InputSystem;
using Assets.Scripts.Models;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class WindowStockScript : MonoBehaviour
    {
        public delegate void HandleRefreshListCall(WindowStockScript sender);

        [SerializeField] private StockItemsDrawer _stockItemsDrawer;

        public DateTime lastResetDate;

        [SerializeField] private TextMeshProUGUI textTimer;
        public InputManagerScript inputManager;

        private void Start()
        {
            if (inputManager)
            {
                inputManager.OnMove += InputManager_OnMove;
            }
        }

        private void InputManager_OnMove(Vector2 move)
        {
            _stockItemsDrawer.MoveItems(move.x);
        }

        public List<StockItem> StockData
        {
            set => _stockItemsDrawer.StockData = value;
        }

        public event HandleRefreshListCall OnRefreshListCall;

        public void NextPage()
        {
            _stockItemsDrawer.NextPage();
        }

        public void PrevPage()
        {
            _stockItemsDrawer.PrevPage();
        }

        public void Close()
        {
            inputManager.OnMove -= InputManager_OnMove;
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

        private void Update()
        {
            var value = lastResetDate.AddHours(24) - DateTime.Now;
            if (value.TotalSeconds < 0)
                value = new TimeSpan(0, 0, 0);
            textTimer.text = value.ToString(@"hh\:mm\:ss");
        }
    }
}