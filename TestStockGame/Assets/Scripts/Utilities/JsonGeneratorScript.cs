using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts.Models;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Utilities
{
    public class JsonGeneratorScript : MonoBehaviour
    {
        private const int StockSize = 100;
        [SerializeField] private Sprite[] sprites;

        private void Start()
        {
            var users = GenerateUsers(8);
            var items = GenerateItems();
            var stock = GenerateStock(users, items);

            var jsonUsers = JsonUtility.ToJson(users);
            var jsonItems = JsonUtility.ToJson(items);
            var jsonStock = JsonUtility.ToJson(stock);

            File.WriteAllText("users.json", jsonUsers);
            File.WriteAllText("items.json", jsonItems);
            File.WriteAllText("stock.json", jsonStock);
        }

        private UsersCollection GenerateUsers(int count)
        {
            var result = new List<User>();
            for (var i = 0; i < count; i++)
                result.Add(new User
                {
                    Id = Guid.NewGuid(),
                    Name = $"User{i}",
                    Level = Random.Range(1, 100),
                    AvatarUrl = $"avatar_{i}.jpg"
                });

            return new UsersCollection {users = result};
        }

        private ItemsCollection GenerateItems()
        {
            var result = new List<Item>();
            foreach (var t in sprites)
                result.Add(new Item
                {
                    Id = Guid.NewGuid(),
                    Name = t.name,
                    ImageName = t.name
                });

            return new ItemsCollection {items = result};
        }

        private StockItemsCollection GenerateStock(UsersCollection users, ItemsCollection items)
        {
            var result = new List<StockItem>();

            for (var i = 0; i < StockSize; i++)
            {
                var user = users.users[Random.Range(0, users.users.Count())];
                var item = items.items[Random.Range(0, items.items.Count())];
                var count = Random.Range(1, 10);

                result.Add(new StockItem
                {
                    Id = Guid.NewGuid(),
                    ItemId = item.Id,
                    TraderId = user.Id,
                    Count = count,
                    Price = count * Random.Range(1, 10)
                });
            }

            return new StockItemsCollection {stockItems = result};
        }
    }
}