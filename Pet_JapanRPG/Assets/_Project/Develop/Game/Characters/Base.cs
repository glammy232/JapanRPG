using Characters.Configuration;
using UnityEngine;

internal interface IDamageble
{
    public void GetDamage(int damage);
}

internal interface IHealable
{
    public void GetHealth(int health);
}

internal interface IMoveable
{
    public void Move(Vector2 direction, float speed);
}

internal interface IInteroperable
{
    public void Interact();
}