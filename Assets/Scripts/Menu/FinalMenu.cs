using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalMenu : MonoBehaviour
{
    private GameController GameController;
    public GameObject FinalMenuGameObject;
    public Text TxtCoins;
    public Text TxtWinLose;

    void Start()
    {
        GameController = FindObjectOfType<GameController>();
    }

    public IEnumerator ShowCoins()
    {
        FinalMenuGameObject.SetActive(true);
        TxtCoins.text = "";
        TxtWinLose.text = GameController.GameMode == GameMode.Win ? "Win" : "Lose";

        for (int i = 0; i <= GameController.Coins; i+=100)
        {
            TxtCoins.text = i == 0 ? "0" : "+"+i.ToString("###,###,###,###");
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void ReStartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
