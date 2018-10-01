using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startUI : MonoBehaviour
{
    public Button btn;
    // Use this for initialization
    void Start()
    {
        btn.onClick.AddListener(() => ChangeScene("robby"));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}


