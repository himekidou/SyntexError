using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerUI : MonoBehaviour {

    public Image imageHP;
    public float playerHP;
    public bool isPause = false;
    public bool isMinimap = false;
    public bool isText = true;
    public int nowScene;
    public Vector3 BossRoom;
    private GameObject pausePanel;
    private GameObject restartPanel;
    private GameObject quitPanel;
    private GameObject minimapPanel;
    private GameObject hpUI;
    private GameObject gunUI;
    private GameObject CheatUI;

	// Use this for initialization
	void Start () {

        pausePanel = GameObject.Find("Canvas").transform.Find("PauseUI").gameObject;
        restartPanel = GameObject.Find("Canvas").transform.Find("RestartUI").gameObject;
        quitPanel = GameObject.Find("Canvas").transform.Find("QuitUI").gameObject;
        minimapPanel = GameObject.Find("Canvas").transform.Find("MinimapUI").gameObject;
        hpUI = GameObject.Find("Canvas").transform.Find("hpUI").gameObject;
        gunUI = GameObject.Find("Canvas").transform.Find("GunUI").gameObject;
        CheatUI = GameObject.Find("Canvas").transform.Find("CheatUI").gameObject;

        //nowScene = SceneManager.GetActiveScene().buildIndex;

        StartCoroutine(playerHpcontrol());
        StartCoroutine(InputPause());
        StartCoroutine(InputMinimap());
	}
	
	// Update is called once per frame
	void Update () {

       
		
	}

    IEnumerator playerHpcontrol()
    {
        while(true)
        {
            /*
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<playerControl>().isDamaged)
            {
                imageHP.fillAmount -= 0.1f;
                GameObject.FindGameObjectWithTag("Player").GetComponent<playerControl>().isDamaged = false;

            }

            */

            playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<playerControl>().playerHP;

            imageHP.fillAmount = 0.1f * playerHP;


            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator InputPause()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(!isText)
                {
                    if (!isPause)
                    {
                        Time.timeScale = 0;
                        pausePanel.SetActive(true);
                    }
                    else
                    {
                        Time.timeScale = 1;
                        pausePanel.SetActive(false);
                        restartPanel.SetActive(false);
                        quitPanel.SetActive(false);
                        CheatUI.SetActive(false);
                    }
                    isPause = !isPause;
                }
                
            }
            else if(Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPause)
                {
                    Time.timeScale = 0;
                    pausePanel.SetActive(true);
                }
                else
                {
                    Time.timeScale = 1;
                    pausePanel.SetActive(false);
                    restartPanel.SetActive(false);
                    quitPanel.SetActive(false);
                    CheatUI.SetActive(false);
                }
                isPause = !isPause;       
            }

            yield return null;
        }
    }

    IEnumerator InputMinimap()
    {
        while(true)
        {
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                if(!isMinimap)
                {
                    Time.timeScale = 0;
                    minimapPanel.SetActive(true);
                    hpUI.SetActive(false);
                    gunUI.SetActive(false);
                }
                else
                {
                    Time.timeScale = 1;
                    minimapPanel.SetActive(false);
                    hpUI.SetActive(true);
                    gunUI.SetActive(true);
                }
                isMinimap = !isMinimap;
            }

            yield return null;
        }
    }

    public void ResumeBt()
    {
        if(isPause == true)
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            GetComponent<soundControl>().BGM[0].UnPause();
            isPause = false;
            
        }
    }

    public void RestartBt()
    {
        restartPanel.SetActive(true);
    }

    public void QuitBt()
    {
        quitPanel.SetActive(true);
    }

    public void ReQuestionYes()
    {
        Time.timeScale = 1;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        loadingScene.LoadScene("robby");
    }

    public void ReQuestionNo()
    {
        restartPanel.SetActive(false);
    }

    public void QuitQuestionYes()
    {
        Time.timeScale = 1;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        SceneManager.LoadScene("mainmenu");
    }

    public void QuitQuestionNo()
    {
        quitPanel.SetActive(false);
    }

    public void CheatBt()
    {
        CheatUI.SetActive(true);
    }

    public void InvincibleOnBt()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerControl>().playerHP = 9999;
    }

    public void InvincibleOffBt()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerControl>().playerHP = 10;
    }

    public void LevelOneChangeBt()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerControl>().sceneChanged = true;
        Time.timeScale = 1;
        loadingScene.LoadScene("1-1");
    }

    public void LevelTwoChangeBt()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerControl>().sceneChanged = true;
        Time.timeScale = 1;
        loadingScene.LoadScene("2-1");
        
    }

    public void LevelThreeChangeBt()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerControl>().sceneChanged = true;
        Time.timeScale = 1;
        loadingScene.LoadScene("3-1");
    }

    public void WeaponChargeBt()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerControl>().sceneChanged = true;
        Time.timeScale = 1;
        loadingScene.LoadScene("weaponRoom");
    }

    public void MoveBossRoom()
    {

        BossRoom = GameObject.FindGameObjectWithTag("MoveBossRoom").transform.position;
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(BossRoom.x, 0.5f, BossRoom.z);

        if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            loadingScene.LoadScene("1-1");
        }
        else if(SceneManager.GetActiveScene().buildIndex == 6)
        {
            loadingScene.LoadScene("2-1");
        }
        else if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            loadingScene.LoadScene("3-1");
        }
    }


}
