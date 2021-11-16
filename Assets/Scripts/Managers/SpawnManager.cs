using UnityEngine;
using UnityEngine.Serialization;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private BaseCharController CharacterPrefab;

    private void Start()
    {
        Instantiate(CharacterPrefab, transform.position, CharacterPrefab.transform.rotation);
    }
}
