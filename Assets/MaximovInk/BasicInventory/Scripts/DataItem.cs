using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaximovInk.Inventory
{
    [Serializable]
    public class DataItem : IEquatable<DataItem>
    {
        [SerializeField]
        public ItemBase Item;

        public float Condition { get; set; }

        public uint Count { get; set; }

        public bool Equals(DataItem other)
        {
            if (GetHashCode() != other.GetHashCode())
                return false;

            if (Item != other.Item)
                return false;
            if (Condition != other.Condition)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = -1703542360;
            hashCode = hashCode * -1521134295 + EqualityComparer<ItemBase>.Default.GetHashCode(Item);
            hashCode = hashCode * -1521134295 + Condition.GetHashCode();
            hashCode = hashCode * -1521134295 + Count.GetHashCode();
            return hashCode;
        }

        public DataItem()
        {
            Count = 1;
            Condition = 1;
        }

        public DataItem(DataItem other, uint count = 1)
        {
            Item = other.Item;
            Condition = other.Condition;
            Count = count;
        }

        public DataItem(ItemBase asset)
        {
            Item = asset;
            Condition = asset.MaxCondition;
            Count = asset.MaxStack;
        }
    }
}