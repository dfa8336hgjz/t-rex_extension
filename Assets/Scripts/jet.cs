using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] float jumpForce;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2D.velocity = Vector2.up * jumpForce; //luc nhay fix cung
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        JetGameManager.instance.GameOver();
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "ScoreTrigger")
    //        JetGameManager.instance.UpdateScore();
    //}
}
