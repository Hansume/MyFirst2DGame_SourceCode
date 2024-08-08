using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * 3.5f);
        if (transform.position.y <= -6)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
