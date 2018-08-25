﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using static UnityEngine.Debug;
using System.Runtime.CompilerServices;
using System;

/// <summary>
/// This class allows run code after awaiting in background thread.
/// </summary>
public class WaitForBackgroundThread
{
    public ConfiguredTaskAwaitable.ConfiguredTaskAwaiter GetAwaiter() => Task.Run(() => { }).ConfigureAwait(false).GetAwaiter();
}