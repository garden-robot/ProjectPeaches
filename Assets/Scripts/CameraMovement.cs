using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _leftBound = -10f;
	[SerializeField] private float _rightBound = 10f;
    [SerializeField] private float _topBound = 10f;
    [SerializeField] private float _bottomBound = -10f;
    [SerializeField] private Transform _target = null;

    private Transform _transform;


    // Start is called before the first frame update
	private void Awake() {
		_transform = GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update()
    {
        _transform.position = new Vector3(
            Mathf.Clamp(_target.position.x, _leftBound, _rightBound),
            Mathf.Clamp(_target.position.y, _bottomBound, _topBound),
            _transform.position.z
            );
    }
}
