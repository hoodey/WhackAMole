using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mole : MonoBehaviour
{
    int moleValue = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Creates a function to increase score when mole is clicked
    public void moleClicked()
    {
        Score.setScore(moleValue);
        Destroy(GameObject.Find("Mole(Clone)"));
        MoleSpawner.moleOnScreen = false;
    }
}
