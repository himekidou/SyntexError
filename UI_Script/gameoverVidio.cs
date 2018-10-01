using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class gameoverVidio : MonoBehaviour {

    public VideoPlayer videoPlayer;
    public VideoSource vidioSource;
    public AudioSource audioSource;
	// Use this for initialization

	void Start () {
        StartCoroutine(gameoverPlay());    
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator gameoverPlay()
    {
        Time.timeScale = 1;
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        audioSource = gameObject.AddComponent<AudioSource>();

        videoPlayer.Play();
        audioSource.volume = 0.15f;
        audioSource.Play();
        yield return new WaitForSeconds(5.0f);
        if (!videoPlayer.isPlaying && !audioSource.isPlaying)
        {
            SceneManager.LoadScene("gameoverUI");
        }
    }
}
