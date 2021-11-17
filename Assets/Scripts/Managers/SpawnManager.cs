using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private BaseCharController CharacterPrefab;

    private void Awake()
    {
        Instantiate(CharacterPrefab, transform.position, CharacterPrefab.transform.rotation);
    }
}
