using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    public enum KeyAction { MOVE_RIGHT, MOVE_LEFT , INTERACT }

    private Dictionary<KeyAction, KeyCode> keys = new Dictionary<KeyAction, KeyCode>(); //키 세팅 딕셔너리
    private KeyCode[] defaultKeys = { KeyCode.D, KeyCode.A ,KeyCode.E }; //기본 설정 키들 - KeyAction의 순서 지킬것

    public bool isMoveRight { get; private set; }
    public bool isMoveLeft { get; private set; }
    public bool isMove { get { return (isMoveRight && !isMoveLeft) || (!isMoveRight && isMoveLeft); } } //isMoveRight xor isMoveLeft
    public bool isInteract { get; private set; }


    void Awake()
    {
        for (int i = 0; i < defaultKeys.Length; i++)
        {
            string tmp = i.ToString();

            int keyName = PlayerPrefs.GetInt(tmp, -1);
            Debug.Log(keyName);

            if (keyName != -1)
            {
                keys.Add((KeyAction)i, (KeyCode)keyName);
            }
            else {
                keys.Add((KeyAction)i, defaultKeys[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        isMoveRight = Input.GetKey(keys[KeyAction.MOVE_RIGHT]);
        isMoveLeft = Input.GetKey(keys[KeyAction.MOVE_LEFT]);
        isInteract = Input.GetKey(keys[KeyAction.INTERACT]);
    }
}
