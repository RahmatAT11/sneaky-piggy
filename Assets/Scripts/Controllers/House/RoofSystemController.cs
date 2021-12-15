using UnityEngine;

namespace Controllers
{
    public class RoofSystemController : MonoBehaviour
    {
        public void ShowRoof(bool isShow)
        {
            gameObject.SetActive(isShow);
        }
    }
}
