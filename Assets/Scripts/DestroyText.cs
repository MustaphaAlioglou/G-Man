using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyText : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Word(Clone)")
        {
            Destroy(collision.gameObject);
        }
    }
}
