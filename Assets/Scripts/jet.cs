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
        if (collision.gameObject.CompareTag("WTC")) // Ensure the WTC has the tag "WTC"
        {
            JetGameManager.instance.triggerExplosion();
        }

        else
        {
            JetGameManager.instance.GameOver();
        }
    }

    public void setGravityOn()
    {
        rb2D.gravityScale = 1;
    }

    public void setGravityOff()
    {
        rb2D.gravityScale = 0;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "ScoreTrigger")
    //        JetGameManager.instance.UpdateScore();
    //}
}
