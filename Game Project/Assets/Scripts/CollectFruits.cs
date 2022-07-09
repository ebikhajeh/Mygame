using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFruits : MonoBehaviour
{
    private Player player;
    public AudioSource apple;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            apple.Play();
            player.fruits++;
            Destroy(gameObject); 
        }
    }
}
