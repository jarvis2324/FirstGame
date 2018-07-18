using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {
    public float speed=5;
   public int RandomN;
	// Use this for initialization
	void Start () {
        int RandomN = Random.Range(1, (int)speed);
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(Vector3.up * 3);
	}
}
