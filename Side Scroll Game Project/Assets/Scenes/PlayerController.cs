using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        move = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = speed * Time.deltaTime;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        h = h * moveSpeed;
        v = v * moveSpeed;

        transform.Translate(Vector3.right * h);
        transform.Translate(Vector3.forward * v);
    }
}
