using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// 
/// 
/// 
/// Write a comment header for CrashMe
/// 
/// 
/// 
/// 
/// </summary>
public class CrashMe : MonoBehaviour
{
    /// <summary>
    /// How to crash me.
    /// </summary>
    public enum CrashMeHow
    {
        notImplementedException,
        nullPointer,
        divideByZero,
        nativeCrash,
    }

    [SerializeField]
    private CrashMeHow _howToCrash;
    
    /// <summary>
    /// MonoBehaviour awake method. Called on all behaviors before any other method and before Start if multiple objects are created at once.
    /// </summary>
    void Awake ()
    {
    }
    
    /// <summary>
    /// MonoBehaviour initialization method. Called after Awake is called on all behaviors.
    /// </summary>
    void Start ()
    {
    }

    /// <summary>
    /// MonoBehaviour update method. Called when the simulation is updated. Called during most frames.
    /// </summary>
    void Update ()
    {
    }

    /// <summary>
    /// 
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    public void CrashMeNowPlease()
    {
        switch (_howToCrash)
        {
        case CrashMeHow.notImplementedException:
            throw new System.NotImplementedException();
            break;

        case CrashMeHow.nullPointer:
            object nullPointer = null;
            Debug.Log("This will never print: "+nullPointer.ToString());
            break;

        case CrashMeHow.divideByZero:
            int zero = 0;
            Debug.Log("4 / 0 = "+(4 / zero));
            break;

        case CrashMeHow.nativeCrash:
            #if (UNITY_ANDROID && !UNITY_EDITOR)
            AndroidJavaClass player = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
            AndroidJavaObject activity = player.GetStatic<AndroidJavaObject>("currentActivity"); 
            AndroidJavaObject exampleClass = new AndroidJavaObject("net.hockeyapp.exampleunityplugin.ExampleClass"); 
            exampleClass.Call("forceAppCrash", activity);
            #else
            Debug.LogWarning("'CrashMeHow.nativeCrash' is unsupported on this platform.");
            #endif
            break;
        }
    }
}
