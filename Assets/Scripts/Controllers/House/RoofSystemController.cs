using UnityEngine;

namespace Controllers.House
{
    public class RoofSystemController : MonoBehaviour
    {
        private void Start()
        {
            HouseSystemController.PlayerEntered += ShowRoof;
        }

        private void OnDestroy()
        {
            HouseSystemController.PlayerEntered -= ShowRoof;
        }

        private void ShowRoof(bool isShow)
        {
            gameObject.SetActive(!isShow);
        }
    }
}
