using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
    [SerializeField] Rigidbody2D rgb;
    public float speed;

    Vector2 direction;
    int type;

    private bool initEnemy = false;

    public void Init(int _type)
    {
        type = _type;
        initEnemy = true;
        Move();
    }

    void Move()
    {
        switch (type)
        {
            //Up,down,right,left
            default:
            case 0:
                direction = Vector2.down;
                break;
            case 1:
                direction = Vector2.up;
                break;
            case 2:
                direction = Vector2.left;
                break;
            case 3:
                direction = Vector2.right;
                break;
        }

        rgb.velocity = new Vector2(speed * direction.x, speed * direction.y);
    }
}
