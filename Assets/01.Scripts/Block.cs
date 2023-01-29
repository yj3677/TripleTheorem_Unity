using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Block : MonoBehaviour
{
    float timer;
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
        Debug.Log("My Index:" + myIndex);
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

            Debug.Log("�θ� �ڽ� ����"+GetComponentInParent<BlockSpawn>().bottomBlockIndex);

            for (int childIndex = 0; childIndex < 3; childIndex++)
            {
                blocks = new GameObject[3];
                //�θ� �����ͼ� �ڽ� �ε����� ������ �±� ��
                tagName = GetComponentInParent<BlockSpawn>().transform.GetChild(myIndex + childIndex).gameObject.tag;
                //BlockSpawn�� �ش� �ε����� �ڽ� ������Ʈ�� ����ش�. 
                blocks[childIndex] = GetComponentInParent<BlockSpawn>().transform.GetChild(myIndex + childIndex).gameObject;
                Debug.Log("��� �迭 " + blocks[childIndex]);


            if (tagName == gameObject.tag)
            {
                sameBlock += 1;
                if (sameBlock == 2)
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
        for (int childIndex = 0; childIndex < 3; childIndex++)
        {
            //Destroy(blocks[childIndex]);
            Debug.Log(blocks[childIndex]);
        }

        


    }
}
