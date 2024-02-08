using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class LevelBrowser : MonoBehaviour
{
    public LevelButton[] LevelButton;
    public GameObject ButtonParent;
    public GameObject MainMenu;
    // Start is called before the first frame update

    private void OnEnable()
    {
        for (int i = 0; i < 7; i++)
        {

            int levelNum = i + 1;
            LevelButton[i].gameObject.SetActive(true);
            LevelButton[i].GetComponent<LevelButton>().LevelText.text = (i + 1).ToString();
            LevelButton[i].GetComponent<Button>().onClick.RemoveAllListeners();
            LevelButton[i].GetComponent<Button>().onClick.AddListener(() => SelectLevel(2, levelNum));
            LevelButton[i].transform.localScale = Vector3.one;
        }
    }

    private void SelectLevel(int world, int level)
    {
        Debug.Log("Loaded level" + world + " - " + level);
    }

    public void BackButton()
    {
        MainMenu.SetActive(true);
        foreach (LevelButton l in LevelButton)
        {
            l.gameObject.SetActive(false);
        }
        this.gameObject.SetActive(false);
    }


}
