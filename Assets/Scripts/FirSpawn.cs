using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class FirSpawn : MonoBehaviour
{
    [SerializeField]
    private string _tag;
    [SerializeField]
    private float _timeGrow;
    [SerializeField]
    private GameObject _treeFir;

    [SerializeField]
    private SceneText _sceneText;
    [SerializeField]
    private Transform _arrowSpawnPoint;
    [SerializeField]
    private GameObject _arrow;

    private float _time;
    private bool Flag = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == _tag)
        {
            _time = Time.time;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == _tag && Time.time >= (_time + _timeGrow))
        {
            Instantiate(_treeFir, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(transform.GetChild(0).GetChild(0).gameObject);
            if (Flag)
            {
                _sceneText.SetTreeState(TreeState.end);
                _sceneText.setFirstFlag(true);
                Flag = false;
            }
        }
    }

    public void SpawnArrow()
    {
        Instantiate(_arrow, _arrowSpawnPoint.position, _arrow.transform.rotation, _arrowSpawnPoint);
    }
}
