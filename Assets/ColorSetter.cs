using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSetter : MonoBehaviour
{
    public EnemyTypeManager.EnemyColor enemyColor;
    [SerializeField] private TrailRenderer trail;

    public void RandomizeColor()
    {
        enemyColor = (EnemyTypeManager.EnemyColor) Random.Range(0, 4);
    }

    public void SetColor(EnemyTypeManager.EnemyColor _color)
    {
        enemyColor = _color;
        Color temp=EnemyTypeManager._instance.GetColor(_color);
        if (trail != null)
            trail.startColor = trail.endColor = temp;
        this.GetComponent<SpriteRenderer>().color = temp;
    }

    public void SetColor()
    {
        Color temp=EnemyTypeManager._instance.GetColor(enemyColor);
        if (trail != null)
            trail.startColor = trail.endColor = temp;
        this.GetComponent<SpriteRenderer>().color = temp;
    }
}
