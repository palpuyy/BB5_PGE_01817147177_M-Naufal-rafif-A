using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public GameObject player;
    public float jumpforce;
    public Rigidbody rb;
    public int jump;
    public float horizontalVelocity;
    public int jumps;
       // Start is called before the first frame update
    void Start()
    {
        jumps = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(horizontalVelocity * Time.deltaTime, rb.velocity.y, rb.velocity.z);

        if (Input.GetKeyDown("space") && jumps > 0)
        {
            rb.AddForce(new Vector3(0, jumpforce, 0));
            jumps = jumps - 1;
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.GetComponent<obstacleController>() != null)
        {
            GameObject.Destroy(this.gameObject);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            Debug.Log("nyentuhGround");
            jumps = jumps + 1;
        }
    }


}
