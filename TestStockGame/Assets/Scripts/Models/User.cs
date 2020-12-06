using System;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class User
    {
        public delegate void HandleSpriteUpdated();

        public event HandleSpriteUpdated OnSpriteUpdated;

        [SerializeField] private string avatarUrl;

        [SerializeField] private string id;
        [SerializeField] private int level;
        [SerializeField] private string name;

        private Sprite sprite;

        public Guid Id
        {
            get => Guid.Parse(id);
            set => id = value.ToString();
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string AvatarUrl
        {
            get => avatarUrl;
            set => avatarUrl = value;
        }

        public int Level
        {
            get => level;
            set => level = value;
        }

        public Sprite Sprite
        {
            get => sprite;
            set
            {
                sprite = value;
                OnSpriteUpdated?.Invoke();
            }
        }
    }
}