using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rigidbody;

    private float h;//horizontal
    private float v;//vertical

    private float moveX;
    private float moveZ;
    private float speedH = 50f;
    private float speedZ = 80f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            animator.Play("JUMP00", -1, 0);
        }
        
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        animator.SetFloat("h", h);
        animator.SetFloat("v", v);

        moveX = h * speedH * Time.deltaTime;
        moveZ = v * speedZ * Time.deltaTime;

        if(moveZ <= 0){
            moveX = 0;
        }

        rigidbody.velocity = new Vector3(moveX, 0, moveZ);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Cube"){
            Debug.Log("충돌 감지");
            animator.Play("DAMAGED01", -1, 0);
            this.transform.Translate(Vector3.back * speedZ * Time.deltaTime);
        }
    }

    private void OnCollisionStay(Collision other) {
        if(other.collider.tag == "Cube"){
            Debug.Log("충돌 유지");
        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.collider.tag == "Cube"){
            Debug.Log("충돌 종료");
        }
    }
}
