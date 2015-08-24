using UnityEngine;
using System.Collections;

namespace Monster
{
    public class Input : IInput
    {
        private Transform _monsterTransform;

        public Input(Transform transform)
        {
            _monsterTransform = transform;
        }

        public Vector2 GetAxis()
        {
            return direction();
        }

        private Vector2 direction()
        {
            Vector2 direction = mousePosition() - (Vector2)_monsterTransform.position;
            return direction;
        }

        private Vector2 mousePosition()
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            pos.z = 0;
            Vector2 pos2d = pos;
            return pos2d;
        }

    }
}
