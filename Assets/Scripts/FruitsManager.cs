﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsManager : MonoBehaviour {
    [SerializeField]
    private GameObject[] fruits;

    
	void Start () {
        
	}

    public GameObject RandomCreateFruit(int x, int y)
    {
        int index = Random.Range(0, fruits.Length);
        var go = Instantiate(fruits[index], gameObject.transform);
        go.transform.localPosition = new Vector3(x * 4 - 10, 0, +y * 4 - 10);
        go.transform.localScale = new Vector3(25, 25, 25);
        return go;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}