using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using INART.DesignPatterns;

public class EnemyInstantiator : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float delay;
    float startingTime;
    [SerializeField] int type;
    [SerializeField] Transform[] positions;
    List<GameObject> existentEnemies = new List<GameObject>();

    void Start()
    {
        type = Random.Range(0, 4);
        startingTime = delay;
    }

    void Update()
    {
        if (GameManager._instance.gameState == GameManager.GameState.PLAY)
        {
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                type = Random.Range(0, 4);
                Caller();
                delay = startingTime;
            }
        }
        // else if ()
        // {
        //     for (int i = 0; i < existentEnemies.Count; i++)
        //     {
        //         if (existentEnemies[i] != null && existentEnemies[i].activeInHierarchy)
        //         {
        //             existentEnemies[i].GetComponent<Enemy>().Destroy_Enemy();
        //         }
        //     }
        // }
    }

    void Caller()
    {
        // GameObject currentEnemy = null;
        // switch (type)
        // {
        //     //Up,down,right,left
        //     default:
        //     case 0:
        //         currentEnemy = Instantiate(enemy, positions[0]);
        //         currentEnemy.GetComponent<EnemyBehaviour>().Init(type);
        //         break;
        //     case 1:
        //         currentEnemy = Instantiate(enemy, positions[1]);
        //         currentEnemy.GetComponent<EnemyBehaviour>().Init(type);
        //         break;
        //     case 2:
        //         currentEnemy = Instantiate(enemy, positions[2]);
        //         currentEnemy.GetComponent<EnemyBehaviour>().Init(type);
        //         break;
        //     case 3:
        //         currentEnemy = Instantiate(enemy, positions[3]);
        //         currentEnemy.GetComponent<EnemyBehaviour>().Init(type);
        //         break;
        // }
        //
        // currentEnemy.GetComponent<ColorSetter>().RandomizeColor();
        // currentEnemy.GetComponent<ColorSetter>().SetColor();
        InstantiateEnemy();
    }
    
    void InstantiateEnemy()
    {
        GameObject newEnemy = GameObjectPool.instance.GetPooledObject("Enemy", type);
        if (newEnemy != null)
        {
            // newEnemy.transform.position = new Vector2(Random.Range(min, max), transform.position.y);
            Vector2 position;
            switch (type)
            {
                //Up,down,right,left
                default:
                case 0:
                    position=positions[0].position;
                    
                    // currentEnemy.GetComponent<EnemyBehaviour>().Init(type);
                    break;
                case 1:
                    position=positions[1].position;

                    // currentEnemy.GetComponent<EnemyBehaviour>().Init(type);
                    break;
                case 2:
                    position=positions[2].position;

                    // currentEnemy.GetComponent<EnemyBehaviour>().Init(type);
                    break;
                case 3:
                    position=positions[3].position;

                    // currentEnemy.GetComponent<EnemyBehaviour>().Init(type);
                    break;
            }
            newEnemy.transform.position = position;

            newEnemy.transform.rotation = Quaternion.identity;
            newEnemy.SetActive(true);
            newEnemy.GetComponent<EnemyBehaviour>().Init(type);
            
            // newEnemy.GetComponent<Rotating>().enabled=true;
            // switch (newEnemy.GetComponent<Enemy>().GetEnemySpeedClassifier())
            // {
            //     case 0:
            //         speedMultiplier = 1;
            //         break;
            //     case 1:
            //         speedMultiplier = 1.25f;
            //         break;
            // }

            // newEnemy.GetComponent<Rigidbody2D>().velocity =
            //     Vector2.down * Time.fixedDeltaTime * 100 * speed * speedMultiplier;
            // existentEnemies.Add(newEnemy);
            newEnemy.GetComponent<ColorSetter>().RandomizeColor();
            newEnemy.GetComponent<ColorSetter>().SetColor();
            existentEnemies.Add(newEnemy);
        }
    }
}