using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject _GameOverText;
    [SerializeField] GameObject _LevelText;
    [SerializeField] GameObject _LivesText;
    [SerializeField] GameObject _LevelCompleteText;
    [SerializeField] GameObject _MainLevelText;
    [SerializeField] GameObject level1;
    [SerializeField] GameObject level2;
    [SerializeField] GameObject level3;
    public int level = 1;

    void Start()
    {
        _GameOverText.SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void GameOver()
    {
        _GameOverText.SetActive(true);
    }

    public void increaseLevel()
    {
        _LevelText.GetComponent<Text>().text = "Level : " + level;
    }

    public void showComplete()
    {

        if(level == 1){
            level1.SetActive(false);
            level2.SetActive(true);
            level += 1;
            _LevelCompleteText.SetActive(true);
            _MainLevelText.SetActive(true);
            _MainLevelText.GetComponent<Text>().text = "Level : " + level;
            Invoke("DeactiveLevelText" , 5f);
        } else if(level == 2){
            level2.SetActive(false);
            level3.SetActive(true);
            level += 1;
            _LevelCompleteText.SetActive(true);
            _MainLevelText.SetActive(true);
            _MainLevelText.GetComponent<Text>().text = "Level : " + level;
            Invoke("DeactiveLevelText" , 5f);
        } else if(level == 3){
            gameCompleteText();
            level3.SetActive(false);
            Invoke("DeactiveLevelText" , 5f);
        }
    }

    public void decreaseLives(int n)
    {
        _LivesText.GetComponent<Text>().text = "Lives : " + n;
    }



    void DeactiveLevelText(){
        _LevelCompleteText.SetActive(false);
        _MainLevelText.SetActive(false);
    }

    void gameCompleteText(){
        _LevelCompleteText.GetComponent<Text>().text = "Congrats You Finsihed!";
        _LevelCompleteText.SetActive(true);
        _MainLevelText.SetActive(false);
    }
}
