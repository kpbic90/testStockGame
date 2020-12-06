using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Engine.InputSystem
{
    public class InputManagerScript : MonoBehaviour
    {
        public delegate void HandleMove(Vector2 move);

        public event HandleMove OnMove;

        public IInputManager InputManager;

        private void Start()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                case RuntimePlatform.Android:
                    InputManager = new MobileInputManager();
                    break;
                default:
                    InputManager = new MouseInputManager();
                    break;
            }
        }

        private void Update()
        {
            var move = InputManager.HandleMove();

            if(move != Vector2.zero)
                OnMove?.Invoke(move);
        }
    }
}