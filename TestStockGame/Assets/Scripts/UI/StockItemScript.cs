using Assets.Scripts.Models;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
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

            textItemName.text = stockItem.Item.Name;
            textItemCost.text = stockItem.Price.ToString();
            textItemCount.text = $"x{stockItem.Count}";

            Addressables.LoadAssetAsync<Sprite>(stockItem.Item.ImageName).Completed += StockItemScript_Completed;
            textTraderName.text = stockItem.User.Name;
            textTraderLevel.text = stockItem.User.Level.ToString();
            stockItem.User.OnSpriteUpdated += User_OnSpriteUpdated;
            imageSeller.sprite = stockItem.User.Sprite;
        }

        private void StockItemScript_Completed(AsyncOperationHandle<Sprite> obj)
        {
            switch (obj.Status)
            {
                case AsyncOperationStatus.Succeeded:
                    imageItem.sprite = obj.Result;
                    break;

                case AsyncOperationStatus.Failed:
                    Debug.LogError("Failed to load Sprite");
                    break;
            }
        }

        private void User_OnSpriteUpdated()
        {
            imageSeller.sprite = stockItem.User.Sprite;
        }
    }
}