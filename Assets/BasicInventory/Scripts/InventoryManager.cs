using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace MaximovInk.Inventory
{
    public class InventoryManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public ItemDatabase itemDatabase;

        public Image dragging_item;

        private Slot begin;
        private Slot end;

        private DragType dragType;

        private bool draging = false;

        private void Update()
        {
            if (draging)
                dragging_item.transform.position = Input.mousePosition;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {

            dragType = Input.GetMouseButton(0) ? DragType.FULL : Input.GetMouseButton(1) ? DragType.HALF : DragType.ONE;

            if (eventData.pointerCurrentRaycast.gameObject != null)
            {
                if (eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>() && eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().DataItem.Item != null)
                {

                    begin = eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>();
                    dragging_item.sprite = begin.DataItem.Item.sprite;
                    dragging_item.gameObject.SetActive(true);
                }
            }


        }

        public void OnDrag(PointerEventData eventData)
        {
            dragging_item.transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            dragging_item.gameObject.SetActive(false);
            dragging_item.sprite = null;
            if (eventData.pointerCurrentRaycast.gameObject != null)
            {
                if (eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>())
                {
                    end = eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>();
                }
            }
            movingItems();

            begin = null;
            end = null;
        }

        private bool movingItems()
        {
            if (begin == null || end == null || begin.DataItem.Item == null || begin == end)
                return false;

            if (end.DataItem.Equals( begin.DataItem))
            {
                uint max = begin.DataItem.Item.max_stack;
                uint have = end.DataItem.Count;

                uint add = dragType == DragType.FULL ? begin.DataItem.Count : dragType == DragType.HALF ? begin.DataItem.Count/2 : 1;

                if (have >= max)
                {
                    return false;
                }
                if (have + add >= max)
                {
                    Debug.Log("have + add > max");
                    end.DataItem.Count = max;
                    begin.DataItem.Count -= (max - have);

                }
                else if (have + add < max)
                {
                    end.DataItem.Count += add;
                    begin.DataItem.Count -= add;
                }
            }
            else
            {
                moveDifferentItems(begin, end);
            }
            begin.Refresh();
            end.Refresh();

            return true;
        }

        private void moveDifferentItems(Slot begin , Slot end)
        {

            DataItem item = end.DataItem;

            if (item.Item != null)
            {
                end.DataItem = begin.DataItem;
                begin.DataItem = item;
            }
            else
            {
                uint add = dragType == DragType.FULL ? begin.DataItem.Count : dragType == DragType.HALF ? begin.DataItem.Count / 2 : 1;
                end.DataItem = new DataItem(begin.DataItem);
                end.DataItem.Count = add;
                begin.DataItem.Count -= add;
                
            }
            
            
        }

        private enum DragType
        {
            FULL,
            HALF,
            ONE
        }
    }
}

   