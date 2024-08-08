using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x >= 7.5f)
        {
            transform.position = new Vector3(16.7f, -2, -10);
        }
        else
        {
            transform.position = new Vector3(-1, -2, -10);
        }

        if (player.position.x >= 25.5f)
        {
            transform.position = new Vector3(34.4f, -2, -10);
        }
        else if (player.position.x < 25.5f && player.position.x >= 7.5f)
        {
            transform.position = new Vector3(16.7f, -2, -10);
        }

        if (player.position.x >= 43.5f)
        {
            transform.position = new Vector3(52.3f, -2, -10);
        }
        else if (player.position.x < 43.5f && player.position.x >= 25.5f)
        {
            transform.position = new Vector3(34.4f, -2, -10);
        }

        if(player.position.x >= 61.1f)
        {
            //loadnext
        }
    }
}
