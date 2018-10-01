using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class titleVideo : MonoBehaviour {


    public VideoPlayer videoPlayer;
    public VideoSource vidioSource;
    public AudioSource audioSource;

    // Use this for initialization
    void Start () {
        StartCoroutine(titlePlay());
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("mainmenu");
        }

    }
    IEnumerator titlePlay()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        audioSource = gameObject.AddComponent<AudioSource>();

        videoPlayer.Play();
        audioSource.volume = 0.15f;
        audioSource.Play();
        yield return new WaitForSeconds(245.0f);
        if (!videoPlayer.isPlaying)
        {
            SceneManager.LoadScene("mainmenu");
        }
        
    }
}
