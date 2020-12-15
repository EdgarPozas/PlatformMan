using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameController GameController;
    private Animator Animator;
    private Rigidbody2D Rigidbody;
    private CapsuleCollider2D BoxCollider2D;

    void Start()
    {
        GameController = FindObjectOfType<GameController>();
        Animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody2D>();
        BoxCollider2D = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        if (GameController.GameMode != GameMode.Playing)
            return;

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x < GameController.LimitMin.position.x)
                return;
            transform.Translate(Vector2.right * Time.deltaTime * GameController.PlayerSpeed);
            transform.eulerAngles = new Vector3(0, 180, 0);
            Animator.SetTrigger("Walk");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x > GameController.LimitMax.position.x)
                return;
            transform.Translate(Vector2.right * Time.deltaTime * GameController.PlayerSpeed);
            transform.eulerAngles = new Vector3(0, 0, 0);
            Animator.SetTrigger("Walk");
        }
        if (Input.GetKeyDown(KeyCode.Space) && !GameController.isPlayerJumping)
        {
            Rigidbody.AddForce(Vector2.up * Time.deltaTime * GameController.PlayerJump,ForceMode2D.Impulse);
            Animator.SetTrigger("Jump");
        }

        if(GameController.Life<=0 || transform.position.y<GameController.LimitMin.position.y)
        {
            Rigidbody.constraints = RigidbodyConstraints2D.None;
            GameController.GameMode = GameMode.Lose;
            StartCoroutine(GameController.FinalMenu.ShowCoins());
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameController.GameMode != GameMode.Playing)
            return;

        var col = collision.collider;
        if (col.name == "Scenary")
        {
            GameController.isPlayerJumping = false;
        }
        else if (col.name.Contains("Coin"))
        {
            GameController.Coins+=100;
            GameController.Bar.UpdateBar();

            col.GetComponent<BoxCollider2D>().enabled = false;
            col.GetComponentInChildren<SpriteRenderer>().enabled = false;
            col.GetComponentInChildren<ParticleSystem>().Play();
            Destroy(col.gameObject,3);
        }
        else if (col.name.Contains("Enemy"))
        {
            GameController.Life -= 5+Random.Range(0,3);
            GameController.Bar.UpdateBar();
            Animator.SetTrigger("Hit");
        }
        else if (col.name == "Goal")
        {
            GameController.GameMode = GameMode.Win;
            StartCoroutine(GameController.FinalMenu.ShowCoins());
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        var col = collision.collider;
        if (col.name == "Scenary")
        {
            GameController.isPlayerJumping = true;
        }
    }
}
