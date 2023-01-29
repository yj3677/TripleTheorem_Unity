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

        if (player.selectBlock && (touchedObject.tag != player.selectBlock.transform.parent.tag))  //���õ� ����� �ִ� ���¶�� Ŭ���� ��ġ����Ʈ�� ��Ͻ��� �ڽ����� �̵�
        {
            if (blockSpawner.bottomBlockIndex >= 0)
            {
                //�÷��̾� selectBlock�� touch�� blockSpawn���� �̵�
                //�θ� ����
                player.selectBlock.transform.SetParent(playerInput.touchedblockSpawner.blockSpawner.transform);
                //�θ� ���� �� ù ��° �ε���(0)�� ���� 
                player.selectBlock.transform.SetAsFirstSibling();
                //player.selectBlock.transform.Translate(new Vector3(playerInput.touchedblockSpawner.transform.position.x, (playerInput.blockCount) * (-0.7f), 0), Space.Self);
                //player.selectBlock.transform.position = new Vector2(0, 0);
                //���� ��ġ ���� (y���� ����)
                player.selectBlock.transform.localPosition = new Vector2(0, ((blockSpawner.bottomBlockIndex+1) * (-0.7f)));
                //player.selectBlock.transform.Translate(new Vector2(0, (playerInput.blockCount + 1) * (-0.7f)));
                player.selectBlock.GetComponent<Block>().OffBlockOutLine();
                if(blockSpawner.bottomBlockIndex >= 2)
                {
                    player.selectBlock.GetComponent<Block>().BlockCheck();
                }
                
                player.selectBlock = null;
            }
            Debug.Log("���� TouchArea�� ��� ����: "+playerInput.blockCount);
        }
        else if (player.selectBlock && (touchedObject.tag == player.selectBlock.transform.parent.tag)) //���õ� ����� �ְ� ���� ��ġ����Ʈ�� Ŭ���ϸ�
        {
            player.selectBlock.GetComponent<Block>().OffBlockOutLine();
            player.selectBlock = null;
        }
        else if (player.selectBlock == null && blockSpawner.bottomBlockIndex > 0) //���õ� ����� ������
        {
            player.selectBlock = blockSpawner.bottomBlock;
            //���õ� ��Ͽ� �׵θ� �����ֱ�
            player.selectBlock.GetComponent<Block>().OnBlockOutLine();
        }
        //else if(blockSpawner.bottomBlockIndex <= 0)
        //{
        //    return;
        //}
    }
}
