using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField]
    private float rightMaxPoint; //Serialize는 임시
    [SerializeField]
    private float leftMaxPoint; //Serialize는 임시

    [SerializeField]
    private Transform playerRightMaxTransform;
    [SerializeField]
    private Transform playerLeftMaxTransform;

    [SerializeField]
    private Transform playerObjTransform;

    private Player_Input playerInput;

    [SerializeField]
    private float moveSpeed = 5.0f; 

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GetComponent<Player_Input>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.isMove) {
            Move();
        }
    }

    private void Move()
    {
        if (playerInput.isMoveRight)
        {
            if (transform.position.x >= rightMaxPoint)
            {
                if (playerObjTransform.position.x < playerRightMaxTransform.position.x)
                {
                    playerObjTransform.position =
                        new Vector2(Mathf.Clamp(playerObjTransform.position.x + moveSpeed * Time.deltaTime, playerObjTransform.position.x, playerRightMaxTransform.position.x),
                        playerObjTransform.position.y);
                }
            }
            else {
                transform.position =
                        new Vector2(Mathf.Clamp(transform.position.x + moveSpeed * Time.deltaTime, transform.position.x, rightMaxPoint),
                       transform.position.y);
            }
        }
        else
        {
            if (playerObjTransform.position.x > playerLeftMaxTransform.position.x)
            {
                playerObjTransform.position =
                        new Vector2(Mathf.Clamp(playerObjTransform.position.x - moveSpeed * Time.deltaTime, playerLeftMaxTransform.position.x, playerObjTransform.position.x),
                        playerObjTransform.position.y);
            }
            else {
                transform.position =
                        new Vector2(Mathf.Clamp(transform.position.x - moveSpeed * Time.deltaTime, leftMaxPoint, transform.position.x),
                       transform.position.y);
            }
        }
    }

    public void SetRightMaxPoint(float value) { rightMaxPoint = value; }
    public void SetLeftMaxPoint(float value) { leftMaxPoint = value; }
}
