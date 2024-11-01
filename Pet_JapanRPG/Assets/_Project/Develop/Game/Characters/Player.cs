using Characters.Configuration;
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

        private bool _isMoving;

        private float _speed;

        private States _states; 

        public void Initialize(PlayerConfig config)
        {
            _maxHealth = config.MaxHealth;

            _health = config.BaseHealth;

            _speed = config.Speed;

            _rigidbody2D = config.Rigidbody2D;

            _animationController = new CharacterAnimatorController(config.Animator, _states);

            _animationController.SetAnimation(nameof(States.Idle));
        }

        private void Update()
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                _isMoving = true;
            else
                _isMoving = false;
        }

        private void FixedUpdate()
        {
            if (_isMoving)
            {
                Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

                Move(direction, _speed);
            }
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
