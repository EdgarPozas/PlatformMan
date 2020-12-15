using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode
{
    Playing,
    Lose,
    Win,
}

public class GameController : MonoBehaviour
{
    public Bar Bar;
    public FinalMenu FinalMenu;

    public int Coins;
    public float PlayerSpeed;
    public float PlayerJump;
    public int Life;

    public Transform LimitMin;
    public Transform LimitMax;

    public bool isPlayerJumping;
    public GameMode GameMode;
}

