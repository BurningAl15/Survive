using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScenesManager : MonoBehaviour {
    public static GameScenesManager _instance;
    [SerializeField] float globalDelay;

    [SerializeField] bool startWithFade;
    [SerializeField] bool tryCalling;

    [SerializeField] TransitionManager transitionManager;
    
    Coroutine currentCoroutine = null;
    void Awake () {
        if (_instance == null)
            _instance = this;
        else
            Destroy (gameObject);

        if(tryCalling)
            StartCoroutine(InitialTransition(.5f));
    }

    public void ChangeToNextScene () {
        if (currentCoroutine == null) {
            currentCoroutine = StartCoroutine (CallTransition ());
        }
    }

    public void ChangeToOtherScene (string _sceneName) {
        if (currentCoroutine == null) {
            currentCoroutine = StartCoroutine (CallTransition (_sceneName));
        }
    }

   public IEnumerator InitialTransition(float _delay)
    {
        if (startWithFade) {
            yield return StartCoroutine (transitionManager.CurtainEffectFadeIn (.5f));
        } else {
            yield return StartCoroutine (transitionManager.CurtainEffectFadeOut (.5f));
        }
    }
   
   public IEnumerator InitialTransition(float _delay,bool _fade)
   {
       if (_fade) {
           yield return StartCoroutine (transitionManager.CurtainEffectFadeIn (.5f));
       } else {
           yield return StartCoroutine (transitionManager.CurtainEffectFadeOut (.5f));
       }
   }
   
    IEnumerator CallTransition (string _sceneName = "") {
        yield return new WaitForSeconds (globalDelay);
        // StartCoroutine (transitionManager.CurtainEffectFadeIn (.5f));
        // yield return new WaitUntil (() => transitionManager.GetAnimationDone ());

        yield return StartCoroutine (transitionManager.CurtainEffectFadeIn (.5f));
        if (_sceneName != "")
            SceneManager.LoadScene (_sceneName);
        else
            SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1 != null ? SceneManager.GetActiveScene ().buildIndex + 1 : 0);
        currentCoroutine = null;
    }
}