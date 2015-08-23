using UnityEngine;
using System.Collections;
using System;

namespace Peasant
{
    [Serializable]
    public struct Settings
    {
        public float Speed;
        public float DistanceToRun;
        public LayerMask LayerMask;
        public float DistanceToCheck;
        public Transform Monster;
    }

    public class PeasantControl : MonoBehaviour
    {
        public Settings Settings;

        private IInput _input;
        private IMovement _movement;
        public bool IsColliding;

        void Awake()
        {
            _input = new IAInput(this);
            _movement = new Movement(GetComponent<Rigidbody2D>());
        }

        void FixedUpdate()
        {
            move();
        }

        private void move()
        {
            Vector2 direction = _input.GetAxis();
            _movement.Move(direction, Settings.Speed);
        }

        void OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.transform.tag == "Obstacle")
            {
                IsColliding = true;
            }
        }

        void OnCollisionExit2D(Collision2D coll)
        {
            if (coll.transform.tag == "Obstacle")
            {
                IsColliding = false;
            }
        }
    }
}
