using UnityEngine;
using System.Collections;
using System;

namespace Peasant
{
    public class IAInput : IInput
    {
        private Vector2 _direction;
        private PeasantControl _control;

        public IAInput(PeasantControl control)
        {
            setRandomDirection();
            _control = control;
        }

        public Vector2 GetAxis()
        {
            var hit = checkForObstacle(_control.transform.position, _direction, _control.Settings.DistanceToCheck, _control.Settings.LayerMask);
            Debug.DrawRay(_control.transform.position, _direction * _control.Settings.DistanceToCheck, Color.magenta);

            if (hit)
            {
                changeDirection(hit.normal);
            }

            run();

            return _direction;
        }

        private void setRandomDirection()
        {
            _direction = new Vector2(UnityEngine.Random.Range(-1, 1f), UnityEngine.Random.Range(-1, 1f));
            _direction.Normalize();
        }

        private void changeDirection(Vector2 normal)
        {
            _direction = Vector2.Reflect(_direction, normal);
        }

        private RaycastHit2D checkForObstacle(Vector2 origin, Vector2 direction, float distance, LayerMask mask)
        {
            RaycastHit2D hit = Physics2D.Raycast(origin, direction, distance, mask);

            return hit;
        }

        private float checkDistance()
        {
            return Vector2.Distance(_control.transform.position, _control.Settings.Monster.transform.position);
        }

        private void run()
        {
            if (checkDistance() <= _control.Settings.DistanceToRun)
            {
                _direction = _control.transform.position - _control.Settings.Monster.transform.position;
                _direction.Normalize();
            }
        }
    }
}
