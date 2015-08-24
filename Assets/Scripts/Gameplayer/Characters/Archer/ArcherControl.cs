using UnityEngine;
using System.Collections;
using System;

namespace Archer
{
    [Serializable]
    public struct Settings
    {
        public float Speed;
        public Transform Monster;
        public float DistanceToFollow;
    }

    public enum State
    {
        Idle,
        Moving
    }

    public class ArcherControl : MonoBehaviour
    {
        private IInput _input;
        private IMovement _movement;
        private State _state;

        public Settings Settings;

        void Awake()
        {
            _input = new IAInput(this);
            _movement = new Peasant.Movement(GetComponent<Rigidbody2D>());
            _state = State.Moving;
        }

        void FixedUpdate()
        {
            processState();
        }

        private void move()
        {
            Vector2 direction = _input.GetAxis();
            _movement.Move(direction, Settings.Speed);
        }

        private void stop()
        {
            Vector2 direction = _input.GetAxis();

            _movement.Move(direction, 0);
        }

        private void processState()
        {
            switch(_state)
            {
                case State.Idle:
                    if (checkDistance() > Settings.DistanceToFollow)
                    {
                        _state = State.Moving;
                    }

                    stop();
                    break;
                case State.Moving:
                    move();

                    if (checkDistance() <= Settings.DistanceToFollow)
                    {
                        _state = State.Idle;
                    }

                    break;
            }
        }

        private float checkDistance()
        {
            return Vector2.Distance(transform.position, Settings.Monster.transform.position);
        }
    }
}
