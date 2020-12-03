using System;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class StockItem : IStockItem
    {
        public Guid Id { get => Guid.Parse(id); set => id = value.ToString(); }
        public Guid ItemId { get => Guid.Parse(item); set => item = value.ToString(); }
        public Guid TraderId { get => Guid.Parse(trader); set => trader = value.ToString(); }
        public int Count { get => count; set => count = value; }
        public int Price { get => price; set => price = value; }

        [SerializeField] private string id;
        [SerializeField] private string item;
        [SerializeField] private string trader;
        [SerializeField] private int count;
        [SerializeField] private int price;
    }
}
