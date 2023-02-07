using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Block : MonoBehaviour
{
    public float timer;
    public float power = 2;
    public Rigidbody2D rb;
    Outline blockOutline;
    Transform blockVectorInit;
    GameObject[] blocks;

    int myIndex;
    string tagName;
    int sameBlock;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        blockOutline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        myIndex = transform.GetSiblingIndex();
        //Debug.Log("My Index:" + myIndex);
        timer += Time.deltaTime;
        if (timer > 10)
        {
            timer = 0;
            DownMove();
        }
    }

    public void DownMove()
    {
        transform.Translate(new Vector3(0, -0.7f, 0),Space.Self);
        //rb.AddForce(transform.up * -1 * (power));
    }
    public void OnBlockOutLine()
    {
        blockOutline.enabled=true;
    }
    public void OffBlockOutLine()
    {
        blockOutline.enabled = false;
    }
    public void BlockCheck()
    {
        
            sameBlock = 0;
        blocks = new GameObject[3];
        Debug.Log("부모 자식 개수"+GetComponentInParent<BlockSpawn>().bottomBlockIndex);

            for (int childIndex = 0; childIndex < 3; childIndex++)
            {

                //부모를 가져와서 자식 인덱스를 가져와 태그 비교
                tagName = GetComponentInParent<BlockSpawn>().transform.GetChild(myIndex + childIndex).gameObject.tag;
                //BlockSpawn의 해당 인덱스의 자식 오브젝트를 담아준다. 
                blocks[childIndex] = GetComponentInParent<BlockSpawn>().transform.GetChild(myIndex + childIndex).gameObject;
                //Debug.Log("블록 배열 " + blocks[childIndex]);


            if (tagName == gameObject.tag)
            {
                sameBlock += 1;
                if (sameBlock == 3)
                {
                    BlockRemove();
                }
                else
                {
                    //break;
                }
            }

        }
        
        
    }
    void BlockRemove()
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("담긴블록" + blocks[i]);
            //Destroy(blocks[i]);
            blocks[i].transform.SetParent(GameManager.instance.poolManager.transform);
            blocks[i].gameObject.SetActive(false);
        }
    }
}
