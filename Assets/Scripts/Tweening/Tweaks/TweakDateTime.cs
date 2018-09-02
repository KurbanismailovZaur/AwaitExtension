﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using static UnityEngine.Debug;
using Numba.Tweening.Tweaks;
using Numba.Tweening;
using System;

namespace Numba.Tweening.Tweaks
{
    public sealed class TweakDateTime : Tweak<DateTime>
    {
        private TweakDateTime() { }

        public TweakDateTime(DateTime from, DateTime to, Action<DateTime> setter) : base(from, to, setter) { }

        public override void Increment()
        {
            TimeSpan change = To - From;
            From = To;
            To = To + change;
        }

        protected override DateTime Evaluate(float normalizedPassedTime, Ease ease) => new DateTime((long)Easing.Ease(From.Ticks, To.Ticks, normalizedPassedTime, ease));

        protected override DateTime EvaluateBackward(float normalizedPassedTime, Ease ease) => new DateTime((long)Easing.Ease(To.Ticks, From.Ticks, normalizedPassedTime, ease));
    }
}