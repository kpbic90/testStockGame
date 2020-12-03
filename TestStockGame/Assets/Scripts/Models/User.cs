using System;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class User
    {
        public Guid Id { get => Guid.Parse(id); set => id = value.ToString(); }
        public string Name { get => name; set => name = value; }
        public string AvatarUrl { get => avatarUrl; set => avatarUrl = value; }
        public int Level { get => level; set => level = value; }

        [SerializeField] private string id;
        [SerializeField] private string name;
        [SerializeField] private string avatarUrl;
        [SerializeField] private int level;
    }
}
