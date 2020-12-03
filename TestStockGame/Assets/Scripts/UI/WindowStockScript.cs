using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Engine;
using Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class WindowStockScript : MonoBehaviour
    {
        [SerializeField] private Transform holderStockItems;
        [SerializeField] private GameObject prefabStockItem;

        private IEnumerable<IStockItem> stockData;
        private int currentPage = 0;
        private const int ItemsAtPage = 6;

        void Start()
        {
            var dataLoader = new JsonDataLoader();
            dataLoader.Init("");
        }

        public void NextPage()
        {
            if(currentPage >= (int)(stockData.Count() / ItemsAtPage))
                return;

            currentPage++;
        }

        public void PrevPage()
        {
            if(currentPage == 0)
                return;
            
            currentPage--;
        }

        public void Close()
        {
            Destroy(gameObject);
        }
    }
}