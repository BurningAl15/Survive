using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypeManager : MonoBehaviour
{
   public static EnemyTypeManager _instance;

   public enum EnemyColor
   {
      RED,
      PURPLE,
      BLUE,
      GREEN
   }

   public List<EnemyColor> enemyColors = new List<EnemyColor>();
   public List<Color> colors = new List<Color>();
   public List<GameObject> particles = new List<GameObject>();
   Dictionary<EnemyColor, Color> colorDictionary = new Dictionary<EnemyColor, Color>();
   Dictionary<EnemyColor, GameObject> particlesDictionary = new Dictionary<EnemyColor, GameObject>();

   private void Awake()
   {
      if (_instance == null)
         _instance = this;
      else if (_instance != null)
         Destroy(this);

      Init();
   }

   void Init()
   {
      for (int i = 0; i < enemyColors.Count; i++)
      {
         colorDictionary.Add(enemyColors[i], colors[i]);
      }
      
      for (int i = 0; i < enemyColors.Count; i++)
      {
         particlesDictionary.Add(enemyColors[i], particles[i]);
      }
   }

   public Color GetColor(EnemyColor _key)
   {
      Color temp = Color.white;
      if (colorDictionary.TryGetValue(_key, out temp))
      {
         return temp;
      }
      else
      {
         return Color.white;
      }
   }
   
   public GameObject GetParticles(EnemyColor _key)
   {
      GameObject temp = null;
      if (particlesDictionary.TryGetValue(_key, out temp))
      {
         return temp;
      }
      else
      {
         return null;
      }
   }
}
