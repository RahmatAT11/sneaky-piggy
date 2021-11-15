using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private BaseCharController playerPrefab;

    private void Start()
    {
        Instantiate(playerPrefab, transform.position, playerPrefab.transform.rotation);
    }
}
