using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorState : MonoBehaviour {
    public bool enter = false;
    public bool canOpen = true;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Player" && canOpen)
        {
            gameObject.GetComponent<Animator>().SetBool("Open", true);
        }
    }
}
