using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(GameObject.Find("Player"));
            loadingScene.LoadScene("1-1");
            GameObject.FindGameObjectWithTag("Player").transform.GetComponent<playerControl>().sceneChanged = true;
            
        }

    }
}
