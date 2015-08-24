using UnityEngine;
using System.Collections;

namespace Archer
{
    public class IAInput : IInput
    {
        private ArcherControl _control;
        private Vector2 _direction;

        public IAInput(ArcherControl control)
        {
            _control = control;
        }

        public Vector2 GetAxis()
        {
            follow();

            return _direction;
        }

        private float checkDistance()
        {
            return Vector2.Distance(_control.transform.position, _control.Settings.Monster.transform.position);
        }

        private void follow()
        {
            _direction = _control.Settings.Monster.transform.position - _control.transform.position;
            _direction.Normalize();
        }
    }
}
