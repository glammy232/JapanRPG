using Characters.Configuration;
using System;
using UnityEngine;

namespace Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : Character, IMoveable, IDamageble, IHealable
    {
        private Rigidbody2D _rigidbody2D;

        private CharacterAnimatorController _animationController;

        private float _maxHealth;

        private float _health;

        private float _speed;

        private States _state; 
        private States state
        {
            get => _state;
            set
            {
                _state = value;

                Debug.Log(Enum.GetName(typeof(States), value));

                _animationController.SetAnimation(Enum.GetName(typeof(States), value));
            }
        }

        private Vector2 _moveDirection;

        private void Awake()
        {
            PlayerConfig config = new PlayerConfig(Enum.GetNames(typeof(States)), 100, 10, 10, 5, GetComponent<Rigidbody2D>(), GetComponent<Animator>());

            Initialize(config);
        }

        public void Initialize(PlayerConfig config)
        {
            _maxHealth = config.MaxHealth;

            _health = config.BaseHealth;

            _speed = config.Speed;

            _rigidbody2D = config.Rigidbody2D;

            _animationController = new CharacterAnimatorController(config.Animator, _state);

            _animationController.SetAnimation(nameof(States.Idle));
        }

        private void Update()
        {
            int up = Convert.ToInt32(Input.GetKey(KeyCode.W));
            int down = Convert.ToInt32(Input.GetKey(KeyCode.S));
            int right = Convert.ToInt32(Input.GetKey(KeyCode.D));
            int left = Convert.ToInt32(Input.GetKey(KeyCode.A));

            _moveDirection = new Vector2(right + left, up + down);
            
            if (Input.GetMouseButtonDown(0))
                SimpleAttack();
        }

        private void FixedUpdate()
        {
            Move(_moveDirection, _speed);
        }

        public void GetDamage(int damage)
        {
            _health -= damage;
        }

        public void GetHealth(int health)
        {
            if (_health + health > _maxHealth)
                _health = _maxHealth;
            else
                _health += health;
        }

        public void Move(Vector2 direction, float speed)
        {
            if (direction == Vector2.zero)
            {
                state = States.Idle;

                return;
            }

            state = States.Walk;
        }

        public void SimpleAttack()
        {
            state = States.SimpleAttack;
        }

        public enum States
        {
            Idle = 0,
            Walk = 1,
            Run = 2,
            SimpleAttack = 3,
            SecondsAttack = 4,
            MainAttack = 5
        }
    }
}
