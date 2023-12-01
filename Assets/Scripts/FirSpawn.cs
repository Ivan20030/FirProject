using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirSpawn : MonoBehaviour
{
    [SerializeField]
    private string _tag;
    [SerializeField]
    private float _timeGrow;
    [SerializeField]
    private GameObject _treeFir;

    private float _time;

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
        }
    }
}
