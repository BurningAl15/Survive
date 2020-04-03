using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using INART.DesignPatterns;


public class PlayerBehaviour : MonoBehaviour
{
    /* Values could be in keys or positions
     0-> Up
     1-> Down
     2-> Right
     3-> Left
     */
    [SerializeField] KeyCode[] keys;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform[] positions;
    Vector2 direction;
    // [SerializeField] float delay;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject gameRender;
    private Coroutine currentCoroutine = null;

    
    void Start()
    {
        direction = Vector2.zero;
    }

    void Update()
    {
        if (GameManager._instance.gameState == GameManager.GameState.PLAY)
        {
            ShootDirection();
        }
        else if (GameManager._instance.gameState == GameManager.GameState.LOSE)
        {
            if (currentCoroutine == null)
            {
                currentCoroutine = StartCoroutine(Death());
            }
        }
    }

    IEnumerator Death()
    {
        float maxDelay = .25f;
        for (float i = 0; i < maxDelay; i += Time.fixedDeltaTime)
        {
            gameRender.transform.localScale = Vector2.one * (maxDelay-i) / maxDelay;
            yield return new WaitForSeconds(.1f);
        }
        gameRender.transform.localScale = Vector2.zero;
        gameRender.SetActive(false);
        yield return new WaitForSeconds(.25f);
        Instantiate(EnemyTypeManager._instance.GetParticles(EnemyTypeManager.EnemyColor.RED));
        yield return new WaitForSeconds(.25f);
        Instantiate(EnemyTypeManager._instance.GetParticles(EnemyTypeManager.EnemyColor.PURPLE));
        yield return new WaitForSeconds(.25f);
        Instantiate(EnemyTypeManager._instance.GetParticles(EnemyTypeManager.EnemyColor.BLUE));
        yield return new WaitForSeconds(.25f);
        Instantiate(EnemyTypeManager._instance.GetParticles(EnemyTypeManager.EnemyColor.GREEN));
        
        GameManager._instance.gameState = GameManager.GameState.END;
        yield return StartCoroutine(GameScenesManager._instance.InitialTransition(.5f,true));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        currentCoroutine = null;
    }

    void ShootDirection()
    {
        if (Input.GetKeyDown(keys[0]))
        {
            ShootBullet(0, new Quaternion(0f, 0f, 0f, 180f), Vector2.up,"Top",0);
        }
        else if (Input.GetKeyDown(keys[1]))
        {
            ShootBullet(1, new Quaternion(540f, 0f, 0f, 180f), Vector2.down,"Bottom",2);
        }
        else if (Input.GetKeyDown(keys[2]))
        {
            ShootBullet(2, new Quaternion(0f, 0f, -180f, 180f), Vector2.right,"Right",3);
        }
        else if (Input.GetKeyDown(keys[3]))
        {
            ShootBullet(3, new Quaternion(0f, 0f, 180f, 180f), Vector2.left,"Left",1);
        }
    }

    void ShootBullet(int _posIndex,Quaternion _quat, Vector2 _direction, string _trigger,int color)
    {
        Vector3 pos;
        anim.SetTrigger(_trigger);
        GameObject newBullet = GameObjectPool.instance.GetPooledObject("Bullet");
        if (newBullet != null)
        {
            pos = new Vector3(positions[_posIndex].transform.position.x, positions[_posIndex].transform.position.y,
                positions[_posIndex].transform.position.z);

            direction = _direction;
            newBullet.transform.position = pos;
            newBullet.transform.rotation = _quat;
            newBullet.SetActive(true);

            // temp = Instantiate(bullet, pos, _quat);
            newBullet.GetComponent<BulletBehaviour>().Init(direction);
            newBullet.GetComponent<ColorSetter>().SetColor((EnemyTypeManager.EnemyColor) color);
        }
    }
}