using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Animation>().Play("CzarAttackPose");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
