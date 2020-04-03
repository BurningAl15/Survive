using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour {
    bool animationDone = false;
    [SerializeField] Material material;

    public IEnumerator CurtainEffectFadeOut (float _delay) {
        // material.SetTexture ("_TransitionTex", textures[Random.Range (0, textures.Count)]);
        material.SetFloat ("_Cutoff", 1);

        // float scaleTime = Time.fixedDeltaTime * 2;

        for (float i = _delay; i > 0; i -= Time.fixedDeltaTime) {
            material.SetFloat ("_Cutoff", i / _delay);
            yield return null;
        }
        material.SetFloat ("_Cutoff", 0);
        yield return null;

        animationDone = true;
    }

    public IEnumerator CurtainEffectFadeIn (float _delay) {
        // material.SetTexture ("_TransitionTex", textures[Random.Range (0, textures.Count)]);
        material.SetFloat ("_Cutoff", 0);

        // float scaleTime = Time.fixedDeltaTime * 2;

        for (float i = 0; i < _delay; i += Time.fixedDeltaTime) {
            material.SetFloat ("_Cutoff", i / _delay);
            yield return null;
        }
        material.SetFloat ("_Cutoff", 1);
        yield return null;

        animationDone = true;
    }

    public bool GetAnimationDone () {
        return animationDone;
    }
}