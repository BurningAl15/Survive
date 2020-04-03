using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using INART.ScreenShake;
using Random = UnityEngine.Random;

public class BulletBehaviour : MonoBehaviour {
    [SerializeField] Rigidbody2D rgb;

    public float speed;

    Vector2 direction;
    public float delay;
    private float initialDelay;
    private bool initBullet = false;

    public void Init(Vector2 _direction)
    {
        initialDelay = delay;
        direction = new Vector2(_direction.x, _direction.y);
        initBullet = true;
    }

    void Update()
    {
        if (initBullet)
        {
            Move();

            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                this.gameObject.SetActive (false);
                delay = initialDelay;
            }
        }
    }

    void Move()
    {
        rgb.velocity = new Vector2(speed * direction.x, speed * direction.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            ColorSetter enemyColor = collision.GetComponent<ColorSetter>();
            if (enemyColor.enemyColor != this.GetComponent<ColorSetter>().enemyColor)
            {
                ScreenShake.instance.TriggerShake();
                ScoreManager._instance.AddPoints();
            }
            else
            {
                ScoreManager._instance.TakePoints();
            }

            Instantiate(EnemyTypeManager._instance.GetParticles(enemyColor.enemyColor),collision.transform.position,Quaternion.identity);
                
            // Destroy(collision.gameObject);
            // Destroy(gameObject);
            collision.gameObject.SetActive (false);
            this.gameObject.SetActive (false);
        }
    }
}
