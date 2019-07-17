using System;
using UnityEngine;

/// <summary>
/// Async Await Utility for Unity. Read more at: http://www.stevevermeulen.com/index.php/2017/09/23/using-async-await-in-unity3d-2017/
/// </summary>
public static class Awaiters
{
    readonly static WaitForUpdate _waitForUpdate = new WaitForUpdate();
    readonly static WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();
    readonly static WaitForEndOfFrame _waitForEndOfFrame = new WaitForEndOfFrame();

    public static WaitForUpdate NextFrame
    {
        get { return _waitForUpdate; }
    }

    public static WaitForFixedUpdate FixedUpdate
    {
        get { return _waitForFixedUpdate; }
    }

    public static WaitForEndOfFrame EndOfFrame
    {
        get { return _waitForEndOfFrame; }
    }

    public static WaitForSeconds Seconds(float seconds)
    {
        return new WaitForSeconds(seconds);
    }

    public static WaitForSecondsRealtime SecondsRealtime(float seconds)
    {
        return new WaitForSecondsRealtime(seconds);
    }

    public static WaitUntil Until(Func<bool> predicate)
    {
        return new WaitUntil(predicate);
    }

    public static WaitWhile While(Func<bool> predicate)
    {
        return new WaitWhile(predicate);
    }
}
