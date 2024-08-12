using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    private bool isWalking;
    private void Update()
    {
        Vector3 moveDir = new Vector3(0,0,0);
        if (Input.GetKey(KeyCode.W))
        {
            moveDir.z = +1;
        }
        if (Input.GetKey(KeyCode.S)) {
            moveDir.z = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDir.x = +1;
        }
        if ((Input.GetKey(KeyCode.A))){
            moveDir.x = -1;
        }

        moveDir = moveDir.normalized;
        this.transform.position += moveDir*moveSpeed*Time.deltaTime;

        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 10f;
        this.transform.forward = Vector3.Slerp(this.transform.forward,moveDir,Time.deltaTime*rotateSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
