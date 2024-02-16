using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoleSpawner : MonoBehaviour
{

    //Create a vector3 array to hold spawn positions
    Vector3[] spawnPos = new[] {new Vector3(-249f, 90f, 0f), new Vector3(-113f, 90f, 0f), new Vector3(68f, 90f, 0f), new Vector3(202f, 90f, 0f), new Vector3(-249f, -43f, 0f), new Vector3(-113f, -43f, 0f), new Vector3(67f, -43f, 0f), new Vector3(203f, -43f, 0f) };
    //Create variables to init on startup
    public static bool moleOnScreen = false;
    public GameObject objectToSpawn;
    public Transform moleCanvas;
    int moleSpawnPos;
    int lastSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Randomly set the first mole's spawn position
        moleSpawnPos = Random.Range(0, 8);
    }

    // Update is called once per frame
    void Update()
    {
        //Conitional to see if game is started, if it is, and there is no mole on the screen, spawn a mole at a random position. Change the moles next spawn position and don't have it repeat, finally flip mole on screen switch
        if (Score.GameStarted)
        {
            if (!moleOnScreen)
            {
                spawnMole(spawnPos[moleSpawnPos]);
                lastSpawn = moleSpawnPos;
                while (lastSpawn == moleSpawnPos)
                {
                    moleSpawnPos = Random.Range(0, 8);
                }
                moleOnScreen = true;
            }
        }
    }

    //Create a function to spawn a mole and set it as a child to the mole canvas
    public void spawnMole (Vector3 v)
    {
        GameObject myMole = Instantiate(objectToSpawn, v, Quaternion.identity);
        myMole.transform.SetParent(moleCanvas, false);
    }
}
