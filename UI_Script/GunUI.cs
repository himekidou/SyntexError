using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GunUI : MonoBehaviour {

    public Text[] gun_Bullet;

	// Use this for initialization
	void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {
        GunText();
    }

    public void GunText()
    {
        gun_Bullet[0].text = GameObject.FindGameObjectWithTag("GunControl").GetComponent<GunControl>().GunName;
        if(GameObject.FindGameObjectWithTag("GunControl").GetComponent<GunControl>().nowMagazine == 0)
        {
            gun_Bullet[1].text = " ";
        }

        else
        {
            gun_Bullet[1].text = GameObject.FindGameObjectWithTag("GunControl").GetComponent<GunControl>().nowMagazine.ToString();
        }

        if(GameObject.FindGameObjectWithTag("GunControl").GetComponent<GunControl>().nowBullet > 5000)
        {
            gun_Bullet[2].text = "Infinity";
        }

        else if(GameObject.FindGameObjectWithTag("GunControl").GetComponent<GunControl>().nowBullet == 0)
        {
            gun_Bullet[2].text = " ";
        }

        else
        {
            gun_Bullet[2].text = GameObject.FindGameObjectWithTag("GunControl").GetComponent<GunControl>().nowBullet.ToString();
        }

        if(GameObject.FindGameObjectWithTag("GunControl").GetComponent<GunControl>().nowBullet == 0 &&
            GameObject.FindGameObjectWithTag("GunControl").GetComponent<GunControl>().nowMagazine == 0)
        {
            gun_Bullet[3].text = " ";
        }
        else
        {
            gun_Bullet[3].text = "/";
        }
        

    }
}
