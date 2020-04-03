using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using INART.ScreenShake;

public class CheckCollision : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Enemy"))
    {
      if (collision.GetComponent<ColorSetter>().enemyColor == this.GetComponent<ColorSetter>().enemyColor)
      {
        ScoreManager._instance.AddPoints();
        // Destroy(collision.gameObject);
      }
      else
      {
        ScreenShake.instance.TriggerShake();
        ScoreManager._instance.TakePoints();
        GameManager._instance.gameState = GameManager.GameState.LOSE;
        // Destroy(collision.gameObject);
      }
      collision.gameObject.SetActive (false);
    }
  }
}
