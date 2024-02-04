using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{

    public UnityEngine.UI.Button[] menuButtons;
    public GameObject[] menuPanels;
    Color colorOn = Color.green;
    Color colorOff = Color.white;
    public int currentMenu;
    public GameObject mainMenuCanvas;
  
    // Start is called before the first frame update
    void Start()
    {        
        currentMenu = 0;
        setColours(menuButtons[currentMenu]);
        setActivePanel(menuPanels[currentMenu]);     
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void changeMenu(UnityEngine.UI.Button button)
    {
        setColours(button);

        currentMenu = System.Array.IndexOf(menuButtons,button);

        setActivePanel(menuPanels[currentMenu]);
    }

    void setActivePanel(GameObject panel)
    {
        foreach(GameObject g in menuPanels)
        {

            g.SetActive(false);
        }
        //iconMats[0].SetColor(Shader.PropertyToID("_EmissionColor"),colorOn);
        panel.SetActive(true);

    }

    void setColours(UnityEngine.UI.Button button)
    {
        foreach(UnityEngine.UI.Button m in menuButtons)
        {

            m.image.material.SetColor(Shader.PropertyToID("_EmissionColor"),colorOff);
        }
        //iconMats[0].SetColor(Shader.PropertyToID("_EmissionColor"),colorOn);
        button.image.material.SetColor(Shader.PropertyToID("_EmissionColor"),colorOn);
    }

    public void switchScene()
    {
        Debug.Log("if this works jacks a nonce");
        
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        mainMenuCanvas.SetActive(false);
    }
}
