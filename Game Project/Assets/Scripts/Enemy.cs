using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public double amountToMove;
    public float speed;
    private float startx;
    private int direction;
    [SerializeField] private GameObject _visual;

    // Start is called before the first frame update
    void Start()
    {
        startx = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameObject.transform.position.x < startx+amountToMove && direction == 0)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + speed, gameObject.transform.position.y);

        } else if (gameObject.transform.position.x >= startx + amountToMove && direction == 0)
        {
            direction = 1;
            gameObject.transform.localScale = new Vector2(-3, 3);
        }
        else if(gameObject.transform.position.x > startx && direction == 1)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - speed, gameObject.transform.position.y);
        }
        else if (gameObject.transform.position.x <= startx && direction == 1)
        {
            direction = 0;
            gameObject.transform.localScale = new Vector2(3, 3);
        }
    }

   
}
