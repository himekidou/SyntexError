using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class quitUI : MonoBehaviour {

    public Button btn;
    // Use this for initialization
    void Start()
    {
        btn.onClick.AddListener(() => QuitScene());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void QuitScene()
    {
        Application.Quit();
    }
}
