using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;
    
    [SerializeField]
    private float rotateSpeed = 10f;

    [SerializeField] private GameInput gameInput;

    private bool isWalking;
     
    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementInputNormalized();

        //Player Move
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir*moveSpeed*Time.deltaTime;
        
        //set isWalking
        isWalking = moveDir != Vector3.zero;
        
        //Player Rotate
        transform.forward = Vector3.Slerp(transform.forward,moveDir,Time.deltaTime*rotateSpeed); 
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
