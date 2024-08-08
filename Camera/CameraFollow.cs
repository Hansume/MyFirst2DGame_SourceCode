using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x <= 0)
        {
            transform.position = new Vector3(0, player.position.y + 2.40387f, -10);
        }
        else if (player.position.x >= 20)
        {
            transform.position = new Vector3(20, player.position.y + 2.40387f, -10);
        }
        else
        {
            transform.position = new Vector3(player.position.x, player.position.y + 2.40387f, -10);
        }
    }
}
