using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text fruits;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        fruits = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        fruits.text = "Fruits: " + player.fruits;
    }
}
