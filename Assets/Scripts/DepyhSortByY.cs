using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepyhSortByY : MonoBehaviour {


    private const int IsometricRangePerYUnit = 100;
    //Will use this object to compute z-order
    public Transform target;

    private void Start()
    {
        
    }

    void Update () {
        Renderer renderer = GetComponentInChildren<Renderer>();

        if (target == null)
        {
            target = transform;
        }

        renderer.sortingOrder = -(int)(target.position.y * IsometricRangePerYUnit);
	}
}
