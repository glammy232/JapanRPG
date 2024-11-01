using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public abstract class InventoryItem : MonoBehaviour
    {
        private Sprite _sprite;
    }

    public class Medicine : InventoryItem
    {

    }

    public class Weapon : InventoryItem
    {

    }

    public class BodyArmor : InventoryItem
    {

    }
}