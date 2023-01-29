using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchArea : MonoBehaviour
{
    public Player player;
    [SerializeField]
    PlayerInput playerInput;
    public BlockSpawn blockSpawner;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BlockMove(GameObject touchedObject)
    {

        if (player.selectBlock && (touchedObject.tag != player.selectBlock.transform.parent.tag))  //선택된 블록이 있는 상태라면 클릭한 터치포인트의 블록스폰 자식으로 이동
        {
            if (blockSpawner.bottomBlockIndex >= 0)
            {
                //플레이어 selectBlock을 touch한 blockSpawn으로 이동
                //부모 변경
                player.selectBlock.transform.SetParent(playerInput.touchedblockSpawner.blockSpawner.transform);
                //부모 변경 후 첫 번째 인덱스(0)로 변경 
                player.selectBlock.transform.SetAsFirstSibling();
                //player.selectBlock.transform.Translate(new Vector3(playerInput.touchedblockSpawner.transform.position.x, (playerInput.blockCount) * (-0.7f), 0), Space.Self);
                //player.selectBlock.transform.position = new Vector2(0, 0);
                //로컬 위치 변경 (y값만 변경)
                player.selectBlock.transform.localPosition = new Vector2(0, ((blockSpawner.bottomBlockIndex+1) * (-0.7f)));
                //player.selectBlock.transform.Translate(new Vector2(0, (playerInput.blockCount + 1) * (-0.7f)));
                player.selectBlock.GetComponent<Block>().OffBlockOutLine();
                if(blockSpawner.bottomBlockIndex >= 2)
                {
                    player.selectBlock.GetComponent<Block>().BlockCheck();
                }
                
                player.selectBlock = null;
            }
            Debug.Log("현재 TouchArea의 블록 개수: "+playerInput.blockCount);
        }
        else if (player.selectBlock && (touchedObject.tag == player.selectBlock.transform.parent.tag)) //선택된 블록이 있고 같은 터치포인트를 클릭하면
        {
            player.selectBlock.GetComponent<Block>().OffBlockOutLine();
            player.selectBlock = null;
        }
        else if (player.selectBlock == null && blockSpawner.bottomBlockIndex > 0) //선택된 블록이 없으면
        {
            player.selectBlock = blockSpawner.bottomBlock;
            //선택된 블록에 테두리 씌워주기
            player.selectBlock.GetComponent<Block>().OnBlockOutLine();
        }
        //else if(blockSpawner.bottomBlockIndex <= 0)
        //{
        //    return;
        //}
    }
}
