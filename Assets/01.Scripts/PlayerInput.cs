using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    // 이 범위를 클릭하면 제일 밑 block을 가져온다
    // block이 있는 상태로 다시 클릭하면 취소
    // block이 선택된 상태로 다른 범위를 클릭하면 block이 그 범위로 이동 



    public GameObject touchedObject;
    LayerMask layerMask;

    public TouchArea touchedblockSpawner;

    public int blockCount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouseClick();
    }
    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    blockCount = blockSpawner.transform.childCount;
    //    //Ray ray =Camera.main.ScreenPointToRay(Input.touch)
    //    Debug.Log(blockSpawner.poolblock);
    //    Debug.Log(eventData.pointerCurrentRaycast.gameObject);
    //    if (player.selectBlock == null) //선택된 블록이 없으면
    //    {
    //        player.selectBlock = blockSpawner.poolblock;
    //    }
    //    //선택된 블록에 테두리 씌워주기
    //    else if (player.selectBlock && (EventSystem.current.currentSelectedGameObject != this.gameObject))  //선택된 블록이 있는 상태라면 클릭한 터치포인트의 블록스폰 자식으로 이동
    //    {
    //        player.selectBlock.transform.Translate(new Vector3(0, blockCount *(- 0.7f), 0), Space.Self);

    //        Debug.Log(blockCount);
    //    }
    //    else if (player.selectBlock && (EventSystem.current.currentSelectedGameObject == this.gameObject)) //선택된 블록이 있고 같은 터치포인트를 클릭하면
    //    {
    //        player.selectBlock = null;
    //    }

    //    blockCount =0;
    //}
    void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPos, Camera.main.transform.forward);
            if (hitInformation.collider != null)
            {
                Transform hit = hitInformation.transform;
                //Debug.Log("hit Info : " + hit.name);
                if (hitInformation.collider.gameObject.layer==LayerMask.NameToLayer("TouchArea"))
                {
                    
                    //블록 스폰
                    touchedblockSpawner = hit.GetComponent<TouchArea>();
                    touchedObject = hitInformation.transform.gameObject;
                    blockCount = touchedblockSpawner.blockSpawner.transform.childCount;
                    touchedblockSpawner.BlockMove(touchedObject);
                    blockCount = 0;
                }
                
            }
            //Ray ray =Camera.main.ScreenPointToRay(Input.touch)
            //Debug.Log(touchedblockSpawner.poolblock);
            


        }

    }
    void BlockMoveTouchPoint()
    {

    }
}
