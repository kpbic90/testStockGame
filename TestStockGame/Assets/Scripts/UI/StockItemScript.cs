using Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class StockItemScript : MonoBehaviour
    {
        [SerializeField] private Text textItemName;
        [SerializeField] private Text textItemCost;
        [SerializeField] private Text textItemCount;
        [SerializeField] private Text textTraderName;
        [SerializeField] private Text textTraderLevel;
        [SerializeField] private Image imageItem;
        [SerializeField] private Image imageSeller;

        public IStockItem stockItem;

        void Start()
        {
            if(stockItem == null)
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
