using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bullet = null;
    [SerializeField] private Transform _spawnLocation = null;
    [SerializeField] private string _bulletButton = "f";
    [SerializeField] private float _shootWaitTime = 1f;
    private float _shootWaitTimer = 1f;
    private bool _firstShot = false;

    
    void Update()
    {
        if(Input.GetKey(_bulletButton)){
            if(_firstShot == false){
                Instantiate(_bullet, _spawnLocation.position, Quaternion.identity);
                _firstShot = true;
                //print(_firstShot);
            }
            _shootWaitTimer -= Time.deltaTime;
            print(_shootWaitTimer);
            if(_shootWaitTimer <= 0f){
                Instantiate(_bullet, _spawnLocation.position, Quaternion.identity);
                print(_shootWaitTimer);
                _shootWaitTimer = _shootWaitTime;
            }
        }   
        if(Input.GetKeyUp(_bulletButton)){
            _shootWaitTimer = _shootWaitTime;
            _firstShot = false;
        }
    }
}
