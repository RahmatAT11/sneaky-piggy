using UnityEngine;

namespace Controllers
{
    public class RoofSystemController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
