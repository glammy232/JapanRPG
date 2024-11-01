using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters.Configuration
{
    public class CharacterConfig
    {
        public string[] NamesOfStates;

        public float BaseHealth;

        public float BaseDamage;

        public CharacterConfig(string[] namesOfStates, float baseHealth, float baseDamage)
        {
            NamesOfStates = namesOfStates;

            BaseHealth = baseHealth;

            BaseDamage = baseDamage;
        }
    }

    public class PlayerConfig : CharacterConfig
    {
        public float MaxHealth;

        public float Speed;

        public Rigidbody2D Rigidbody2D;

        public Animator Animator;

        public PlayerConfig(string[] namesOfStates, float baseHealth, float baseDamage, float maxHealth, float speed, Rigidbody2D rigidbody2D, Animator animator) : base(namesOfStates, baseHealth, baseDamage)
        {
            NamesOfStates = namesOfStates;

            BaseHealth = baseHealth;

            BaseDamage = baseDamage;

            MaxHealth = maxHealth;

            Speed = speed;

            Rigidbody2D = rigidbody2D;

            Animator = animator;
        }
    }

    public class EnemyConfig : CharacterConfig
    {
        public EnemyConfig(string[] namesOfStates, float baseHealth, float baseDamage) : base(namesOfStates, baseHealth, baseDamage)
        {
            NamesOfStates = namesOfStates;

            BaseHealth = baseHealth;

            BaseDamage = baseDamage;
        }
    }
}
