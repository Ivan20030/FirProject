using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedSpawnComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject _seed;
    [SerializeField]
    private int _seedCount;

    void SpawnSeeds(int SeedCount)
    {
        for (int i = 0; i < SeedCount; i++)
        {
            //TODO (optional): Perhaps there is a need to add the disappearance of the cone.
            Instantiate(_seed, transform.position, Quaternion.identity);
        }
    }
}
