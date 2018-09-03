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
    public sealed class TweakVector4 : Tweak<Vector4>
    {
        private TweakVector4() { }

        public TweakVector4(Vector4 from, Vector4 to, Action<Vector4> setter) : base(from, to, setter) { }

        public override void Increment()
        {
            Vector4 change = To - From;
            From = To;
            To = To + change;
        }

        protected override Vector4 Evaluate(float normalizedPassedTime, Ease ease) => Easing.Ease(From, To, normalizedPassedTime, ease);

        protected override Vector4 EvaluateBackward(float normalizedPassedTime, Ease ease) => Easing.Ease(To, From, normalizedPassedTime, ease);
    }
}