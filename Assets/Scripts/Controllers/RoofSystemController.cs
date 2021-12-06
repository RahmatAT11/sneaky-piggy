using UnityEngine;

namespace Controllers
{
    public class RoofSystemController : MonoBehaviour
    {
        public void ShowRoof(bool isShow)
        {
            GetComponent<SpriteRenderer>().enabled = isShow;
        }
    }
}
