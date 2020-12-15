using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator Animator;
    private bool Direction;

    void Start()
    {
        Animator = GetComponent<Animator>();
        Direction = Random.Range(0,2)==1;
        ChangeDirection();
    }

    void ChangeDirection()
    {
        transform.eulerAngles = Direction ? new Vector3(0, 180, 0) : new Vector3(0, 0, 0);
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime*Random.Range(1,3));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Direction = !Direction;
        ChangeDirection();
    }
}
