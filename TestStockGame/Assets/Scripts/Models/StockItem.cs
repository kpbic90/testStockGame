﻿using System;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class StockItem 
    {
        public Guid Id { get => Guid.Parse(id); set => id = value.ToString(); }
        public Guid ItemId { get => Guid.Parse(item); set => item = value.ToString(); }
        public Guid TraderId { get => Guid.Parse(trader); set => trader = value.ToString(); }
        public int Count { get => count; set => count = value; }
        public int Price { get => price; set => price = value; }

        public Item Item { get; set; }
        public User User { get; set; }

        [SerializeField] private string id;
        [SerializeField] private string item;
        [SerializeField] private string trader;
        [SerializeField] private int count;
        [SerializeField] private int price;
    }
}
