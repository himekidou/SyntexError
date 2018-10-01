using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textStart : MonoBehaviour {

    public GameObject talkHolder;
    private bool isText;

    bool check;

	// Use this for initialization
	void Start () {


    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape) && !check)
        {

            StartCoroutine(InputEscape());
            check = true;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("GameControl").GetComponent<playerUI>().isText = true;
            talkHolder.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<RobbyPlayerControl>().inputLock = true;
        }
    }

    IEnumerator InputEscape()
    {
        talkHolder.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<RobbyPlayerControl>().inputLock = false;
        gameObject.GetComponent<Collider>().enabled = false;

        yield return null;
        GameObject.Find("GameControl").GetComponent<playerUI>().isText = false;

        if (GameObject.Find("Collider") && isText == false)
        {
                Destroy(this);
        }

    }


}
