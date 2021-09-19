using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using UnityEngine.SceneManagement;
public class gameSceneController : MonoBehaviour
{
    public playerController player;
    public Camera maincamera;
    public Text gameText;
    public Text gameOver;
    public GameObject[] blockPrefabs;
    private float blockPointer = -10;
    private float safeMargin = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        while (player != null && blockPointer < player.transform.position.x + safeMargin)
        {
            int blockIndex = Random.Range(0, blockPrefabs.Length);
            if (blockPointer < 20)
            {
                blockIndex = 0;
            }
            GameObject blockObject = GameObject.Instantiate<GameObject>(blockPrefabs[blockIndex]);
            blockObject.transform.SetParent(this.transform);
            blockController block = blockObject.GetComponent<blockController>();
            blockObject.transform.position = new Vector3(blockPointer + block.size / 2, 0, 0);
            blockPointer += block.size;
        }
        if (player != null)
        {
            maincamera.transform.position = new Vector3(
                player.transform.position.x,
                maincamera.transform.position.y,
                maincamera.transform.position.z);

            gameText.text = "Score :" + Mathf.Floor(player.transform.position.x);
        } else if (player == null)
        {
            gameText.text = "\n Press R to Restart";
            if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        }
        


    }

   
}
