using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
namespace MaximovInk.Inventory
{
    [CreateAssetMenu(fileName = "Item", menuName = "Item/base", order = 0)]
    public class ItemBase : ScriptableObject
    {
        public uint ID { get; set; }

        public Sprite Sprite;

        public Sprite DroppedSprite;

        public ITEM_TYPE Type;

        public ITEM_RARITY Rarity;

        public string Description;

        public float Weight;

        public uint MaxStack;

        public uint MaxCondition;

        public List<UseFunction> UseFunctions;

        public void Use(int id, Slot from)
        {
            if (id < UseFunctions.Count)
            {
                EventManager.Instance.UseFunction(UseFunctions[id], from);
            }
        }
    }
    [Serializable]
    public class UseFunction
    {
        public string name;
        public List<USABLE_EVENT> events;
    }

    [Serializable]
    public class USABLE_EVENT
    {
        public USE_TYPE type;
        public string value;
    }

    public enum ITEM_TYPE
    {
        NONE,
        WEAPON,
        EAT
    }

    public enum USE_TYPE
    {
        EQUIP,
        HEAL,
        EAT,
        DRINK,
        REGENERATION,
        DAMAGE,
        CHANGE
    }

    public enum ITEM_RARITY
    {
        BROKEN,
        NORMAL,
        RARE,
        EPIC_RARE,
        FANTASTIC
    }
}