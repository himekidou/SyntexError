using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour {
    public GameObject moveTalk;
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            moveTalk.SetActive(false);

        }
    }
}
