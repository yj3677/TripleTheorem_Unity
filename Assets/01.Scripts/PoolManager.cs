using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //��� ��������� ������ ����
    [SerializeField]
    public GameObject[] blocks;
    //Ǯ ����� �ϴ� ����Ʈ��
    List<GameObject>[] blockpools;

    private void Awake()
    {
        blockpools = new List<GameObject>[blocks.Length];
        for (int index = 0; index < blockpools.Length; index++)
        {
            blockpools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;
        foreach (GameObject item in blockpools[index])
        {
            if (!item.activeSelf) //��Ȱ��ȭ ���̶��
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }
        if (!select)
        {
            select = Instantiate(blocks[index], transform); //����
            blockpools[index].Add(select); //pool�� ���
        }
        //Debug.Log("Get");
        return select;
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
