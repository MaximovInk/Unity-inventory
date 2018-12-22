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

        public Sprite sprite;

        public Sprite dropped_sprite;

        public float weight;

        public uint max_stack;

        public uint max_condition;

        public List<USABLE_EVENT> events;

    }

    public enum USE_TYPE
    {
        EQUIP,
        HEAL,
        EAT,
        DRINK,
        REGENERATION,
        DAMAGE
    }

    public enum EQUIP_TYPE
    {
        HEAD_ACCS,
        HEAD,
        CHEST,
        LEGS
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