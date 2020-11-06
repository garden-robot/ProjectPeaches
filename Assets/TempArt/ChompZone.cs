using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChompZone : MonoBehaviour
{
    [SerializeField] private GameObject _chompZone = null;
    private Transform _jaw = null;

    void Awake()
    {
        _chompZone.SetActive(false);
        _jaw = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_jaw.rotation.z >= 0f && _jaw.rotation.z <= 1f)
        {
            _chompZone.SetActive(true);
        }else{
            _chompZone.SetActive(false);
        }
    }
}
