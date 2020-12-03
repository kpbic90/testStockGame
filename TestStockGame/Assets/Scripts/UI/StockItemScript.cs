using Assets.Scripts.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class StockItemScript : MonoBehaviour
    {
        [SerializeField] private Image imageItem;
        [SerializeField] private Image imageSeller;

        public StockItem stockItem;
        [SerializeField] private TextMeshProUGUI textItemCost;
        [SerializeField] private TextMeshProUGUI textItemCount;
        [SerializeField] private TextMeshProUGUI textItemName;
        [SerializeField] private TextMeshProUGUI textTraderLevel;
        [SerializeField] private TextMeshProUGUI textTraderName;

        private void Start()
        {
            if (stockItem == null)
                return;

            //textItemName.text = stockItem.Item.Name;
            textItemCost.text = stockItem.Price.ToString();
            textItemCount.text = $"x{stockItem.Count}";
            //imageItem.sprite = Resources.Load<Sprite>($"Sprites\\Items\\{stockItem.Item.ImageName}");

            //textTraderName.text = stockItem.Trader.Name;
            //textTraderLevel.text = stockItem.Trader.Level.ToString();
        }
    }
}