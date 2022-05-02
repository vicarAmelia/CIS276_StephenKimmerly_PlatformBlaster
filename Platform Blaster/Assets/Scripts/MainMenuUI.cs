using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public string gameSceneName;
    // Start is called before the first frame update
    //When buttons are clicked they either start or exit the game
    private void Start()
    {
       startButton.onClick.AddListener(LoadGameScene); 
       exitButton.onClick.AddListener(ExitGame);
    }
    //Loads in game scene
    public void LoadGameScene()
    {
        GameSceneManager.Instance.LoadScene(gameSceneName);
    }
    //Quits the game
    public void ExitGame()
    {
        Application.Quit();
    }

}
