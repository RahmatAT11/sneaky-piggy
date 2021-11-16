using System;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private BaseCharController CharacterPrefab;

    private void Awake()
    {
        Instantiate(CharacterPrefab, transform.position, CharacterPrefab.transform.rotation);
    }
}
