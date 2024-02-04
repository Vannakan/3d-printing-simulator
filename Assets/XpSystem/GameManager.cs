using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            quitGame();
        }   
    }
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
