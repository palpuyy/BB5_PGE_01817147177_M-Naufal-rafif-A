using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    bool isJump = true;
    bool isDead = false;
    int idMove = 0;
    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("Jump"+isJump);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(); 
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Idle();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Idle();
        }
        Move();
        Dead();
	}

    private void OnCollisionStay2D(Collision2D collision) {
        //kondisi Ketika Menyentuh Tanah
        if (isJump)
        {
            anim.ResetTrigger("jump");
            if (idMove == 0) anim.SetTrigger("idle");
            isJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        //Kondisi Ketika Menyentuh Tanah
        anim.SetTrigger("jump");
        anim.ResetTrigger("Run");
        anim.ResetTrigger("idle");
        isJump = true;
        
    }

    public void MoveRight(){
        idMove = 1;
    }

    public void MoveLeft() {
        idMove = 2;
    }

    private void Move() {
        if (idMove == 1 && !isDead)
        {
            // Kondisi Ketika bergerak ke kanan
            if (!isJump) anim.SetTrigger("run");
            transform.Translate(1 * Time.deltaTime * 5f, 0, 0);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        
        if (idMove == 2 && !isDead)
        {
            // Kondisi Ketika bergerak ke kiri
            if (!isJump) anim.SetTrigger("run");
            transform.Translate(-1 * Time.deltaTime * 5f, 0, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void Jump(){
        if (!isJump)
        {
            // Kondisi Ketika Loncat
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.transform.tag.Equals("Coins"))
        {
            //Data.score += 15;
            Destroy(collision.gameObject);
        }
    }

    public void Idle(){
        //Kondisi Ketika Idle
        if (!isJump)
        {
            anim.ResetTrigger("jump");
            anim.ResetTrigger("run");
            anim.SetTrigger("idle");
        }
        idMove = 0;
    }

    private void Dead(){
        if (!isDead)
        {
            if (transform.position.y < -10f)
            {
                // Kondisi Ketika Jatuh
                isDead = true;
            }
        }
    }
}
