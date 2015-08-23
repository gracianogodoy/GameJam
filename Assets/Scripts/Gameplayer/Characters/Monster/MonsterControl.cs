using UnityEngine;
using System.Collections;
using System;

namespace Monster
{
    [Serializable]
    public struct MonsterSettings
    {
        public float Speed;
    }

    public enum State
    {
        Idle,
        Moving
    }

    public class MonsterControl : MonoBehaviour
    {
        private IInput _input;
        private IMovement _movement;
        private Animator _animator;

        public MonsterSettings _settings;


        private State _state;

        void Awake()
        {
            _input = new Input(transform);
            _movement = new Movement(GetComponent<Rigidbody2D>());
            _state = State.Idle;
            _animator = GetComponentInChildren<Animator>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            processState();
        }

        private void processState()
        {
            float valueToChange = 0.2f;

            switch (_state)
            {
                case State.Idle:
                    stop();

                    _animator.SetBool("Walking", false);

                    if (_input.GetAxis().magnitude > valueToChange)
                    {
                        _state = State.Moving;
                    }
                    break;
                case State.Moving:
                    move();

                    _animator.SetBool("Walking", true);

                    if (_input.GetAxis().magnitude <= valueToChange)
                    {
                        _state = State.Idle;
                    }
                    break;
            }
        }

        private void move()
        {
            Vector2 direction = _input.GetAxis().normalized;

            _movement.Move(direction, _settings.Speed);
        }

        private void stop()
        {
            Vector2 direction = _input.GetAxis().normalized;

            _movement.Move(direction, 0);
        }
    }
}
