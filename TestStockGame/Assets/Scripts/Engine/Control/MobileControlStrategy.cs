using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Engine.Control
{
    public class MobileControlStrategy : IControlStrategy
    {
        private Vector2 _currentSwipe;
        private Vector2 _firstPressPos;
        private Vector2 _secondPressPos;
        private bool _startedSwipe;

        public Vector2 GetSwipe()
        {
            if (Input.touches.Length <= 0)
                return Vector2.zero;

            var t = Input.GetTouch(0);
            switch (t.phase)
            {
                case TouchPhase.Began:
                {
                    var mousePosPercY = t.position.y / Screen.height;
                    if (mousePosPercY < 0.2f || mousePosPercY > 0.8f)
                        return Vector2.zero;

                    _firstPressPos = new Vector2(t.position.x, t.position.y);
                    _startedSwipe = true;
                    break;
                }
                case TouchPhase.Ended when !_startedSwipe:
                    return Vector2.zero;
                case TouchPhase.Ended:
                    _secondPressPos = new Vector2(t.position.x, t.position.y);
                    _currentSwipe = new Vector3(_secondPressPos.x - _firstPressPos.x,
                        _secondPressPos.y - _firstPressPos.y);
                    _startedSwipe = false;

                    return _currentSwipe;
            }

            return Vector2.zero;
        }
    }
}