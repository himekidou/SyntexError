using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextScene_creatPlayer : MonoBehaviour {
    // Use this for initialization
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Instantiate(player);
        //GameObject.FindGameObjectWithTag("Player").GetComponent<playerControl>().sceneChanged = true;
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 0.5f, 0);
        loadingScene.LoadScene("1-1");

    }


}
