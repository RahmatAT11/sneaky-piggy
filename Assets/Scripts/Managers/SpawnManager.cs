using UnityEngine;
using Controllers.Base;

namespace Managers
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private BaseCharController characterPrefab;

        private void Awake()
        {
            Instantiate(characterPrefab, transform.position, transform.rotation);
        }
    }
}
