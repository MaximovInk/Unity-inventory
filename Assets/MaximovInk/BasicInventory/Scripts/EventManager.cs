using UnityEngine;
using MaximovInk.Utils;
using System.Collections.Generic;

namespace MaximovInk.Inventory
{
    public class EventManager : Singleton<EventManager>
    {

        public void UseFunction(UseFunction function, Slot from)
        {
            Debug.Log(function.name);

            for (int i = 0; i < function.events.Count; i++)
            {
                UsableEvent(function.events[i],from);
            }
        }

        private void UsableEvent(USABLE_EVENT _event ,Slot from)
        {
            string[] parameters = _event.value.Split('/');

            if (parameters.Length == 0)
                return;

            switch (_event.type)
            {
                case USE_TYPE.EQUIP:
                    break;
                case USE_TYPE.HEAL:
                    break;
                case USE_TYPE.EAT:
                    float eat = 0;
                    float.TryParse(parameters[0], out eat);
                    eat *= from.DataItem.Condition / from.DataItem.Item.MaxCondition;

                    if (parameters.Length > 1)
                    {
                        float div = 1;
                        float.TryParse(parameters[1], out div);

                        GameManager.Instance.player.eat += eat;

                        from.DataItem.Condition -= (from.DataItem.Item.MaxCondition /div / from.DataItem.Count);
                    }
                    else
                    {
                        GameManager.Instance.player.eat += eat;
                        from.DataItem.Count -=1;
                    }
                    from.refresh();

                    break;
                case USE_TYPE.DRINK:
                    break;
                case USE_TYPE.CHANGE:
                    int id = 0;
                    int.TryParse(parameters[0], out id);
                    if (id >= InventoryManager.Instance.ItemDatabase.items.Length)
                        return;

                    if (parameters.Length > 1)
                    {
                        int count = 0;

                        int.TryParse(parameters[1], out count);

                        for (int i = 0; i < count; i++)
                        {
                            DataItem di = new DataItem(InventoryManager.Instance.ItemDatabase.items[id]);
                            di.Condition = from.DataItem.Condition / from.DataItem.Item.MaxCondition * di.Item.MaxCondition;
                            from.GetComponentInParent<Inventory>().AddItem(di);
                        }

                        from.DataItem.Count--;
                        from.refresh();
                    }
                    else
                    {
                        from.DataItem.Count--;

                        /*float before = from.DataItem.Count;
                        float after = before - 1;
                        from.DataItem.Count = (uint)after;
                        from.DataItem.Condition -= from.DataItem.Condition/ from.DataItem.Item.MaxCondition *  after / before;*/
                        DataItem di = new DataItem(InventoryManager.Instance.ItemDatabase.items[id]);
                        di.Condition = from.DataItem.Condition / from.DataItem.Item.MaxCondition * di.Item.MaxCondition;
                        from.GetComponentInParent<Inventory>().AddItem(di);
                        from.refresh();
                    }
                    
                    break;
                default:
                    break;
            }
        }

    }
}