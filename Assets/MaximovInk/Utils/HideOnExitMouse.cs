using UnityEngine;
using UnityEngine.EventSystems;

namespace MaximovInk.Utils
{
    public class HideOnExitMouse<T> : MonoBehaviour where T : MonoBehaviour , IPointerExitHandler
    {
        public void OnPointerExit(PointerEventData eventData)
        {
            gameObject.SetActive(false);
        }
    }
}