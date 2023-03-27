using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{

    public Button menuToggleButton;
    
    public Button exitApplicationButton;
    public Button exitMinigameButton;
     public Button removeTilesGameButton;

     private bool isMenuVisible;
    // Start is called before the first frame update
    void Start()
    {
        isMenuVisible = false;
        menuToggleButton.onClick.AddListener(menuToggleButtonHandler);
        exitApplicationButton.onClick.AddListener(exitApplicationButtonHandler);
        exitMinigameButton.onClick.AddListener(exitMinigameButtonHandler);
        removeTilesGameButton.onClick.AddListener(removeTilesGameButtonHandler);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void menuToggleButtonHandler()
    {
        isMenuVisible = !isMenuVisible;
        exitApplicationButton.gameObject.SetActive(isMenuVisible);
        exitMinigameButton.gameObject.SetActive(isMenuVisible);
        removeTilesGameButton.gameObject.SetActive(isMenuVisible);
    }


    void exitApplicationButtonHandler()
    {
        #if UNITY_STANDALONE
            Application.Quit();
        #endif
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    void exitMinigameButtonHandler()
    {
        SceneManager.LoadScene("GameScene");
    }

    void removeTilesGameButtonHandler()
    {
        SceneManager.LoadScene("RemoveTilesMinigame");
    }
}
