using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Engine.InputSystem
{
    public class MobileInputManager : IInputManager
    {
        public Vector2 HandleMove()
        {
            if (Input.touches.Length > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                var delta = Input.GetTouch(0).deltaPosition;
                return new Vector2(delta.x, delta.y);
            }

            return Vector2.zero;
        }
    }
}