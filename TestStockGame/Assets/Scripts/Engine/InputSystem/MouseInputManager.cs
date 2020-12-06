using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Engine.InputSystem
{
    public class MouseInputManager : IInputManager
    {
        private float sensetivity = 25;
        public Vector2 HandleMove()
        {
            if (Input.GetMouseButton(0)) return new Vector2(Input.GetAxis("Mouse X") * sensetivity, Input.GetAxis("Mouse Y") * sensetivity);

            return Vector2.zero;
        }
    }
}