using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DoorOpen : MonoBehaviour
{
    public bool canOpen = true;
    public bool spawned;
    public GameObject DoorCollider;
    public bool openAgain = false;
    public bool isSpawnRoom= true;
    public Transform player;
    public bool isSpawning;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameObject.GetComponent<Animator>().SetBool("Open", false);
        DoorCollider.SetActive(true);
        canOpen = true;
        StartCoroutine(Door());
    }



    void OnTriggerEnter(Collider other)
    {
        gameObject.transform.parent.Find("minimapBlack").gameObject.SetActive(false);
        
        if (other.gameObject.tag == "Player" && canOpen && !isSpawning)
        {
            gameObject.GetComponent<Animator>().SetBool("Open", true);
            DoorCollider.SetActive(false);
            openAgain = true;

            spawned = gameObject.transform.parent.Find("spawn").GetComponent<enemySpawn>().spawned;
            if (!spawned && isSpawnRoom)
            {
                StartCoroutine(spawn());
                spawned = true;
            }
        }
    }

    IEnumerator Door()
    {
        while(true)
        {
            int monsterCount = (int)GameObject.FindGameObjectsWithTag("Enemy").Length;
            int bossCount = (int)GameObject.FindGameObjectsWithTag("Enemy(Boss)").Length;
            if (monsterCount == 0 && bossCount == 0 && !isSpawning)
            {
                canOpen = true;
            }
            else
            {
                canOpen = false;
            }

            if (canOpen && openAgain && !isSpawning && monsterCount == 0 && bossCount == 0)
            {
                Debug.Log("bbb");
                gameObject.GetComponent<Animator>().SetBool("Open", true);
                break;

            }
            yield return new WaitForSeconds(0.2f);
        }

    }

    IEnumerator spawn()
    {
        isSpawning = true;
        bool playerEnter = false;
        float doorRotation = transform.rotation.y;
        //들어가면 문닫기
        while (true)
        {
            Vector3 playerPos = player.transform.position;
            Vector3 absolutePos = new Vector3(playerPos.x - transform.position.x, 0, playerPos.z - transform.position.z);
            Debug.Log("absolutePos  =  " + absolutePos);
            Debug.Log("doorRotation  =  " + doorRotation);

            if (doorRotation == 0)
            {
                if (absolutePos.z > 2)
                {
                    break;
                }

            }
            else if(doorRotation > 0 && doorRotation < 1)
            {
                
                if (absolutePos.x > 2)
                {
                    break;
                }

            }
            else if(doorRotation == 1)
            {
                if (absolutePos.z < -2)
                {
                    break;
                }
            }
            else//doorRotation == -90
            {
                if (absolutePos.x < -2)
                {
                    break;
                }

            }
            yield return new WaitForSeconds(0.3f);
        }
        canOpen = false;
        gameObject.GetComponent<Animator>().SetBool("Open", false);
        DoorCollider.SetActive(true);


        yield return new WaitForSeconds(0.5f);
        gameObject.transform.parent.Find("spawn").GetComponent<enemySpawn>().spawnTrigger = true;
        gameObject.transform.parent.Find("spawn").GetComponent<enemySpawn>().spawned = true;

        yield return new WaitForSeconds(2f);
        isSpawning = false;
    }
}
