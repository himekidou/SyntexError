using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveText : MonoBehaviour {

    public GameObject moveTalk;
    public bool checkMap;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            moveTalk.SetActive(false);
            GameObject.FindGameObjectWithTag("gun").GetComponent<GunShot>().inputLock = false;
            if(checkMap)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerControl>().inputLock = true;
            GameObject.FindGameObjectWithTag("gun").GetComponent<GunShot>().inputLock = true;
        }
    }
}
