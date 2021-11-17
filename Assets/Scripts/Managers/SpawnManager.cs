using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private BaseCharController playerPrefab;
    [SerializeField] private BaseCharController CharacterPrefab;

    private void Start()
    private void Awake()
    {
        Instantiate(playerPrefab, transform.position, playerPrefab.transform.rotation);
        Instantiate(CharacterPrefab, transform.position, CharacterPrefab.transform.rotation);
    }
}
