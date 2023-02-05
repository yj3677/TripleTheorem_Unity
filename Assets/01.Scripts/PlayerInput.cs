using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    // �� ������ Ŭ���ϸ� ���� �� block�� �����´�
    // block�� �ִ� ���·� �ٽ� Ŭ���ϸ� ���
    // block�� ���õ� ���·� �ٸ� ������ Ŭ���ϸ� block�� �� ������ �̵� 



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
    //    if (player.selectBlock == null) //���õ� ����� ������
    //    {
    //        player.selectBlock = blockSpawner.poolblock;
    //    }
    //    //���õ� ��Ͽ� �׵θ� �����ֱ�
    //    else if (player.selectBlock && (EventSystem.current.currentSelectedGameObject != this.gameObject))  //���õ� ����� �ִ� ���¶�� Ŭ���� ��ġ����Ʈ�� ��Ͻ��� �ڽ����� �̵�
    //    {
    //        player.selectBlock.transform.Translate(new Vector3(0, blockCount *(- 0.7f), 0), Space.Self);

    //        Debug.Log(blockCount);
    //    }
    //    else if (player.selectBlock && (EventSystem.current.currentSelectedGameObject == this.gameObject)) //���õ� ����� �ְ� ���� ��ġ����Ʈ�� Ŭ���ϸ�
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
                    
                    //��� ����
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
