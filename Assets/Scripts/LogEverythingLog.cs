using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 
/// 
/// 
/// 
/// Write a comment header for LogEverythingLog
/// 
/// 
/// 
/// 
/// </summary>
public class LogEverythingLog : MonoBehaviour
{
    [SerializeField]
    private Text _buttonName;

    /// <summary>
    /// Static reference of this behavior.
    /// </summary>
    private static LogEverythingLog _instance = null;

    /// <summary>
    /// MonoBehaviour awake method. Called on all behaviors before any other method and before Start if multiple objects are created at once.
    /// </summary>
    void Awake ()
    {
        if (_instance == null)
        {
            _instance = this;
            _buttonName.text = "";
        }
        else
        {
            Debug.LogWarning("<color=#ff00ff>" + GetType().ToString() + " -> Awake(), instance already exists.</color>");
        }
        
        #if UNITY_EDITOR
        System.AppDomain.CurrentDomain.UnhandledException += OnHandleUnresolvedException;
        Application.logMessageReceived += OnHandleLogCallback;
        #endif

        string messageString = "<color=#7f007f>" + GetType().ToString() + " -> Awake(), behavior awake.</color>";

        logMessageInternal(messageString);

        _time = Time.time + 15f;
    }

    private float _time = 0f;
    
    /// <summary>
    /// MonoBehaviour initialization method. Called after Awake is called on all behaviors.
    /// </summary>
    void Start ()
    {
        string messageString = "<color=#7f0000>" + GetType().ToString() + " -> Start(), behavior started.</color>";

        logMessageInternal(messageString);
    }

    /// <summary>
    /// MonoBehaviour update method. Called when the simulation is updated. Called during most frames.
    /// </summary>
    void Update ()
    {
        if (_time <= Time.time)
        {
            _time = Time.time + 15f;

            Application.logMessageReceived -= OnHandleLogCallback;
            Application.logMessageReceived += OnHandleLogCallback;

            Debug.Log("<color=#ff00ff>" + GetType().ToString() + " -> Update(), Application.logMessageReceived has been reset.</color>");
            Debug.LogWarning("<color=#ff00ff>" + GetType().ToString() + " -> Update(), Application.logMessageReceived has been reset.</color>");
            Debug.LogError("<color=#ff00ff>" + GetType().ToString() + " -> Update(), Application.logMessageReceived has been reset.</color>");
        }
    }

    /// <summary>
    /// 
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    private void OnHandleUnresolvedException(object sender, System.UnhandledExceptionEventArgs arguments)
    {
        string messageString = "<color=#0000ff>" + GetType().ToString() + " -> OnHandleUnresolvedException(), sender = '" + sender.ToString() + "', arguments = '" + arguments.ToString() + "'</color>";

        logMessageInternal(messageString);
    }

    /// <summary>
    /// 
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    private void OnHandleLogCallback(string logString, string stackTrace, LogType type)
    {
        string messageString = "<color=#007f7f>" + GetType().ToString() + " -> OnHandleLogCallback(), logString = '"+logString+"', type = '"+type.ToString()+"'\n</color><color=#7f7f00>stackTrace:\n"+stackTrace+"</color>";

        logMessageInternal(messageString);
    }

    /// <summary>
    /// Static logging method exposed.
    /// </summary>
    /// <param name="messageString">Message string.</param>
    public static void LogMessage(string messageString)
    {
        if (_instance != null)
        {
            _instance.logMessageInternal(messageString);
        }
    }

    /// <summary>
    /// 
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    private void logMessageInternal(string messageString)
    {
        Debug.Log(messageString);
        _buttonName.text += messageString+'\n';
    }
}
