using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualMove : MonoBehaviour
{
    [SerializeField] private MoveButton leftMove;
    [SerializeField] private MoveButton rightMove;

    [SerializeField] private PlayerMove playerMove;

    private int currentId;

    private void Awake()
    {
        //leftMove.OnDown += Down;
        //rightMove.OnDown += Down;

        //leftMove.OnUp += Up;
        //rightMove.OnUp += Up;
    }

    private void OnDestroy()
    {
        //leftMove.OnDown -= Down;
        //rightMove.OnDown -= Down;

        //leftMove.OnUp -= Up;
        //rightMove.OnUp -= Up;
    }

    private void Down(int id)
    {
        currentId = id;
        playerMove.Move(currentId);
    }

    private void Up(int id)
    {
        if(currentId == id)
        {
            currentId = 0;
            playerMove.Move(0);
        }
    }
}
