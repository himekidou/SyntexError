using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastStageMove : MonoBehaviour {

    public GameObject jotTalkHolder;
    public bool isTalk;
    public bool isLastScene;
    bool playerEnter;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && playerEnter)
        {
            jotTalkHolder.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerControl>().inputLock = false;
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            loadingScene.LoadScene("Ending");

        }
    }

    void OnTriggerEnter(Collider other)
    {
        playerEnter = true;
        if (other.gameObject.tag == "Player" && !isLastScene)
        {
            isTalk = true;
            jotTalkHolder.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerControl>().inputLock = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerEnter = false;
    }


}
