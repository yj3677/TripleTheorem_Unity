//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    //public Transform[] spawnPoint;
    Block block;
    public Transform bottomBlock;
    public GameObject poolblock;
    public int bottomBlockIndex;
    GameObject[] blocks;

    int sameBlock;
    string tagName;
    float timer;
    private void Awake()
    {
       
    }
    void Start()
    {
        block = GetComponent<Block>();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        bottomBlockIndex = transform.childCount;
        if (transform.childCount <=0)
        {
            bottomBlock = null;
        }
        else
        {
            bottomBlock = transform.GetChild(0);

        }

        timer += Time.deltaTime;
        if (timer > 10)
        {
            timer = 0;
            Spawn();
        }

    }
    public void Spawn()
    {
        poolblock = GameManager.instance.poolManager.Get(Random.Range(0, GameManager.instance.poolManager.blocks.Length)); //풀에서 랜덤으로 블럭 가져오기
        poolblock.transform.position = transform.position;
        poolblock.transform.Translate(new Vector3(0, -0.7f, 0), Space.Self);
        poolblock.GetComponent<Block>().timer = 0;
        poolblock.transform.parent = gameObject.transform;
        //SpawnBlockCheck();
        //Debug.Log(transform.GetChild(0));

    }
//    void SpawnBlockCheck()
//    {
//        //스폰 후 스포너의 자식 개수가 3개 이상이면 인덱스 최대값-2까지 태그 검사
        
//        if (bottomBlockIndex >= 2)
//        {
//            blocks = new GameObject[bottomBlockIndex+1];
//            for (int i = bottomBlockIndex; i > bottomBlockIndex-3; i--)
//            {
//                print(i);
//                tagName= transform.GetChild(i).gameObject.tag;
//                blocks[i] = transform.GetChild(i).gameObject;
//                if (tagName == gameObject.tag)
//                {
//                    sameBlock += 1;
//                    if (sameBlock == 3)
//                    {
//                        BlockRemove();
//                    }
//                    else
//                    {
//                        //break;
//                    }
//                }
//            }
//        }


//    }

//    private void BlockRemove()
//    {
//        for (int i = 0; i < 3; i++)
//        {
//            Debug.Log("담긴블록" + blocks[i]);
//            //Destroy(blocks[i]);
//            blocks[i].transform.SetParent(GameManager.instance.poolManager.transform);
//            blocks[i].gameObject.SetActive(false);
//        }
//    }
}
