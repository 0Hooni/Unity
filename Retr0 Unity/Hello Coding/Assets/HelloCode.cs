using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
            int[] students = new int[5];

            int curScore = 100;
            for(int i=0; i<5; i++){
                students[i] = curScore;
                curScore -= 10;
                Debug.Log(i + "번 학생의 점수는 " + students[i] + "점 입니다.");
            }    
    }
}
