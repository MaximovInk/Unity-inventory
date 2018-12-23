using UnityEngine;
using System.Collections;
using MaximovInk.Inventory;

[RequireComponent(typeof(Character))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Speed = 5;
    private DragItem dragItem;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
        }
        else if (rb.velocity.x != 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.F) && dragItem != null)
            dragItem.Take();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DragItem>() && collision.GetComponent<DragItem>().item.Item != null)
        {
            dragItem = collision.GetComponent<DragItem>();
            

            InventoryManager.Instance.ShowDragItemText(dragItem.item.Item.name, dragItem.transform.position);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (dragItem != null && dragItem == collision.GetComponent<DragItem>())
        {
            dragItem = null;
            InventoryManager.Instance.HideDragItemText();
        }
    }
}
