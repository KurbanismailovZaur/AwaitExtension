﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using static UnityEngine.Debug;
using System.Threading;
using UnityEngine.SceneManagement;
using System;
using Numba.Tweening;

namespace Numba
{
    public class Test : MonoBehaviour
    {
        [SerializeField]
        private Transform _cube0;

        [SerializeField]
        private Transform _cube1;

        [SerializeField]
        private Ease _ease;

        [SerializeField]
        [Range(0f, 1f)]
        private float _time;

        [SerializeField]
        private bool _reversed;

        private Tweak _tweak;

        private Tween _tween;

        private async void Awake()
        {
            Log(Mathf.Repeat(1f, 1f));
            _tween = new Tween("MyXTween", 0f, 1f, (x) => { SetXPosition(_cube0, x); }, 1f).SetEase(Ease.ExpoIn).SetLoops(2, LoopType.ReversedYoyo);
            
            //Tween yTween = new Tween("MyYTween", 0f, 2f, (y) => { SetYPosition(_cube, y); }, 2f).SetEase(Ease.CircIn).SetLoops(-1, LoopType.Yoyo);
            //Tween zTween = new Tween("MyZTween", 0f, 3f, (z) => { SetZPosition(_cube, z); }, 3f).SetEase(Ease.QuintInOut).SetLoops(-1, LoopType.ReversedYoyo);

            //Sequence sequence = new Sequence();
            //sequence.Append(new Tween("Tween0", 0f, 1f, (x) => { SetXPosition(_cube0, x); }, 1f).SetEase(Ease.CircIn));
            //sequence.Append(new Tween("Tween1", 0f, 1f, (x) => { SetXPosition(_cube1, x); }, 1f));

            //await sequence.PlayAsync();

            Log("Tweened!");
        }

        private void Update()
        {
            _tween.SetTime(_time);
        }

        private void SetXPosition(Transform transform, float xPosition)
        {
            var position = transform.position;
            position.x = xPosition;
            transform.position = position;
        }

        //private void SetYPosition(Transform transform, float yPosition)
        //{
        //    var position = transform.position;
        //    position.y = yPosition;
        //    transform.position = position;
        //}

        //private void SetZPosition(Transform transform, float zPosition)
        //{
        //    var position = transform.position;
        //    position.z = zPosition;
        //    transform.position = position;
        //}
    }
}