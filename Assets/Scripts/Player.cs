using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private GameInput gameInput;

    private bool isWalking;
    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x,0f,inputVector.y);

        float moveDistance = moveSpeed*Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(this.transform.position,this.transform.position + Vector3.up*playerHeight ,playerRadius,moveDir,moveDistance);

        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x,0f,0f).normalized;
            canMove = !Physics.CapsuleCast(this.transform.position, this.transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove) { 
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0f,0f, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(this.transform.position, this.transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
                if (canMove) { 
                    moveDir = moveDirZ;
                }
            }
        }

        if (canMove)
        {
            this.transform.position += moveDir * moveDistance;
        }
        
        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 10f;
        this.transform.forward = Vector3.Slerp(this.transform.forward,moveDir,Time.deltaTime*rotateSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
