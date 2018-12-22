using UnityEngine;
//using System.Collections.Generic;
namespace MaximovInk.Inventory
{
    [CreateAssetMenu(fileName = "untitled_ItemDatabase", menuName = "ItemDatabase", order = 1)]
    public class ItemDatabase : ScriptableObject
    {
        //public List<ItemBase> items = new List<ItemBase>();

        public ItemBase[] items;
    }
}