using System;

namespace Assets.Scripts.Interfaces
{
    public interface IStockItem
    {
        Guid Id { get; set; }
        Guid ItemId { get; set; }
        Guid TraderId { get; set; }
        int Count { get; set; }
        int Price { get; set; }
    }
}
