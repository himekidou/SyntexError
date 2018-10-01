using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundControl : MonoBehaviour {

    public AudioSource[] BGM;
    public AudioSource[] effectSound;
    public Text soundText;
    private AudioSource temp;
    private bool isStop;

	// Use this for initialization
	void Start () {

        StartCoroutine(SoundOn());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SoundOn()
    {
        while(true)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isStop)
                {
                    BGM[0].Pause();
                }
                else
                {
                    BGM[0].UnPause();
                }

                isStop = !isStop;
            }
            yield return null;
        }
        
    }

    IEnumerator SoundDown()
    {
        while(true)
        {
            BGM[0].volume -= 0.02f;
            yield return new WaitForSeconds(0.1f);

            if(BGM[0].volume == 0)
            {
                StartCoroutine(SoundChange());
                break;
            }
        }
    }

    IEnumerator SoundUp()
    {
        BGM[0].Play();
        while (!(BGM[0].volume >= 0.21))
        {
            BGM[0].volume += 0.02f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator SoundChange()
    {
        BGM[0].Stop();

        temp = BGM[0];
        BGM[0] = BGM[1];
        BGM[1] = temp;

        BGM[0].Play();
        StartCoroutine(SoundUp());
        yield return null;
    }

    public void BgSoundUp()
    {
        BGM[0].volume += 0.1f;
        soundText.text = (BGM[0].volume * 10).ToString();
    }
    public void BgSoundDown()
    {
        BGM[0].volume -= 0.1f;
        soundText.text = (BGM[0].volume * 10).ToString();
    }
    public void EffectSoundUp()
    {
        effectSound[0].volume -= 0.1f;
        soundText.text = (effectSound[0].volume * 10).ToString();
    }
    public void EffectSoundDown()
    {
        effectSound[0].volume -= 0.1f;
        soundText.text = (effectSound[0].volume * 10).ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(SoundDown());

        }
    }
}
