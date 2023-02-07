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

        //Debug.Log(transform.GetChild(0));

    }
}
