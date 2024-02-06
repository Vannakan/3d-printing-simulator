using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            QuitGame();
        }
    }
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
