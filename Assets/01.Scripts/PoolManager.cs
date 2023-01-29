using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //블록 프리펩들을 보관할 변수
    [SerializeField]
    public GameObject[] blocks;
    //풀 담당을 하는 리스트들
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
            if (!item.activeSelf) //비활성화 중이라면
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }
        if (!select)
        {
            select = Instantiate(blocks[index], transform); //생성
            blockpools[index].Add(select); //pool에 등록
        }
        //Debug.Log("Get");
        return select;
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
