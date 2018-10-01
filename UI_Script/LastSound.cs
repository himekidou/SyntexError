using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSound : MonoBehaviour {

    public AudioSource Ending;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator SoundDown()
    {
        while (true)
        {
            GameObject.Find("GameControl").GetComponent<soundControl>().BGM[0].volume -= 0.02f;
            yield return new WaitForSeconds(0.1f);

            if (GameObject.Find("GameControl").GetComponent<soundControl>().BGM[0].volume == 0)
            {
                GameObject.Find("GameControl").GetComponent<soundControl>().BGM[0].Stop();
                StartCoroutine(LastBGM());
                break;
            }
        }
    }
    IEnumerator LastBGM()
    {
        Ending.Play();
        while (!(Ending.volume >= 0.21))
        {
            Ending.volume += 0.02f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(SoundDown());

        }
    }

}
