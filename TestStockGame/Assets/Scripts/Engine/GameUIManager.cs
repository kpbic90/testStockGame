﻿using System;
using Assets.Scripts.Engine.DataManagment;
using Assets.Scripts.Engine.InputSystem;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Engine
{
    public class GameUIManager : MonoBehaviour
    {
        [SerializeField] private DataManagerScript dataManager;
        [SerializeField] private InputManagerScript inputManager;

        [SerializeField] private Transform holderWindows;
        [SerializeField] private GameObject prefabWindowStock;

        private void Start()
        {
            ShowStock();
        }


        public void ShowStock()
        {
            var wind = Instantiate(prefabWindowStock
                , new Vector3()
                , Quaternion.identity, holderWindows);

            var windScript = wind.GetComponent<WindowStockScript>();
            windScript.OnRefreshListCall += WindScript_OnRefreshListCall;

            windScript.lastResetDate = dataManager.LastResetDate;
            windScript.inputManager = inputManager;
            windScript.StockData = dataManager.StockData;

            dataManager.OnDataUpdated += () =>
            {
                windScript.StockData = dataManager.StockData;
            };

            dataManager.OnLastResetDateUpdated += () =>
            {
                windScript.lastResetDate = dataManager.LastResetDate;
            };
        }

        private void WindScript_OnRefreshListCall(WindowStockScript sender)
        {
            dataManager.CallUpdateStock();

            sender.StockData = dataManager.StockData;
        }
    }
}