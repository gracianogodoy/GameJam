﻿using UnityEngine;
using System.Collections;

namespace Monster
{
    public class Movement : IMovement
    {
        private Rigidbody2D _rigidbody;

        public Movement(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void Move(Vector2 direction, float speed)
        {
            Vector2 velocity = speed * direction * Time.deltaTime;

            _rigidbody.MovePosition(_rigidbody.position + velocity);
            rotateToMouse(direction);
        }

        private void rotateToMouse(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _rigidbody.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }
}
