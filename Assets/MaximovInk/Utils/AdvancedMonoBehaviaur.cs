using UnityEngine;

namespace MaximovInk.Utils
{
    public class AdvancedMonoBehaviaur : MonoBehaviour
    {
        public void GameObjectTurnActive()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}