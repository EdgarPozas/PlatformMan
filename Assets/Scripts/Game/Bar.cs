using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    private GameController GameController;
    public Text TxtCoins;
    public Slider SliderLife;

    void Start()
    {
        GameController = FindObjectOfType<GameController>();
        UpdateBar();
    }

    public void UpdateBar()
    {
        TxtCoins.text = GameController.Coins==0?"0":GameController.Coins.ToString("###,###,###,###");
        SliderLife.value = GameController.Life;
    }
}
