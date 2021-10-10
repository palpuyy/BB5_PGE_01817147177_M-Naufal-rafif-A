using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameScenenController : MonoBehaviour
{
    public GameObject scoring;
    public Text scoreView;
    public Text restartSign;
    
    public playerController player;
    public Camera gameCamera;
    public GameObject[] blockPrefabs;

    private float blockPointer;
    private float safeArea = 30;
    // Start is called before the first frame update
    void Start()
    {
        restartSign.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        while (player != null && blockPointer < player.transform.position.x + safeArea)
        {
            int random = Random.Range(0, blockPrefabs.Length);

            if (blockPointer < 15)
            {
                random = 0;
            }

            GameObject blockObject = GameObject.Instantiate<GameObject>(blockPrefabs[random]);
            blockObject.transform.SetParent(this.transform);

            blockController block = blockObject.GetComponent<blockController>();

            blockObject.transform.position = new Vector3(blockPointer + block.size/2, 0, 0);
            blockPointer += block.size;

        }

        if (player != null) {
            gameCamera.transform.position = 
                new Vector3(
                    player.transform.position.x, 
                    gameCamera.transform.position.y, 
                    gameCamera.transform.position.z);
            scoreView.text = "Score : " + (scoring.GetComponent<playerController>().score);
        }
        else
        {
            restartSign.text = "Press R to Restart";
            if (Input.GetKeyDown("r"))
            {
                SceneManager.LoadScene("SampleScene");
                
            }
        }

       
    }
}
