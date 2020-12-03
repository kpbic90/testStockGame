using System;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class Item : IItem
    {
        public Guid Id { get => Guid.Parse(id); set => id = value.ToString(); }
        public string Name { get => name; set => name = value; }
        public string ImageName { get => imageName; set => imageName = value; }

        [SerializeField] private string id;
        [SerializeField] private string name;
        [SerializeField] private string imageName;
    }
}