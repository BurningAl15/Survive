﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace INART.ScreenShake {

    public class ScreenShake : MonoBehaviour {

        private static ScreenShake _instance;
        public static ScreenShake instance {
            get {
                if (_instance == null)
                    _instance = ScreenShake.FindObjectOfType<ScreenShake> ();
                return _instance;
            }
        }

        [SerializeField] Camera _camera;

        // Transform of the GameObject you want to shake
        private Transform _transform;

        // Desired duration of the shake effect
        private float shakeDuration = 0f;

        // A measure of magnitude for the shake. Tweak based on your preference
        private float shakeMagnitude = 0.15f;

        // A measure of how quickly the shake effect should evaporate
        private float dampingSpeed = 1.0f;

        // The initial position of the GameObject
        Vector3 initialPosition;

        void Awake () {
            if (_transform == null) {
                _transform = GetComponent (typeof (Transform)) as Transform;
            }
        }

        void OnEnable () {
            initialPosition = transform.localPosition;
        }

        void Update () {
            if (shakeDuration > 0) {
                transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

                shakeDuration -= Time.deltaTime * dampingSpeed;
            } else {
                shakeDuration = 0f;
                transform.localPosition = initialPosition;
            }
        }
        public void TriggerShake () {
            shakeDuration = .3f;
        }
    }
}