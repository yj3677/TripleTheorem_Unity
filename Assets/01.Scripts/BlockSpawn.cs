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
        poolblock = GameManager.instance.poolManager.Get(Random.Range(0, GameManager.instance.poolManager.blocks.Length)); //Ǯ���� �������� �� ��������
        poolblock.transform.position = transform.position;
        poolblock.transform.Translate(new Vector3(0, -0.7f, 0), Space.Self);
        poolblock.GetComponent<Block>().timer = 0;
        poolblock.transform.parent = gameObject.transform;
        //SpawnBlockCheck();
        //Debug.Log(transform.GetChild(0));

    }
//    void SpawnBlockCheck()
//    {
//        //���� �� �������� �ڽ� ������ 3�� �̻��̸� �ε��� �ִ밪-2���� �±� �˻�
        
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
//            Debug.Log("�����" + blocks[i]);
//            //Destroy(blocks[i]);
//            blocks[i].transform.SetParent(GameManager.instance.poolManager.transform);
//            blocks[i].gameObject.SetActive(false);
//        }
//    }
}
