using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
public abstract class Singleton<T> : Singleton where T : MonoBehaviour {
    #region  Fields
    [CanBeNull]
    private static T _instance;

    [NotNull]
    private static readonly object Lock = new object();

    [SerializeField]
    private bool _persistent = false;
    #endregion

    #region  Properties
    [NotNull]
    public static T Instance {
        get {

            if (Quitting) {
                return null;
            }
            lock(Lock) {
                if (_instance != null)
                    return _instance;
                _instance = (T)FindObjectOfType(typeof(Singleton<T>));
                if (_instance != null) {
                    (_instance as Singleton<T>).OnInit();
                    return _instance;
                }
                return null;
            }
        }
    }
    #endregion

    #region  Methods
    private void Awake() {
        if (_persistent) {
#if UNITY_EDITOR
            if (EditorApplication.isPlaying)
                DontDestroyOnLoad(gameObject);
#else 
            DontDestroyOnLoad(gameObject);
#endif
        }
        T tempInstance = (T)Instance;
        if (tempInstance != this) {
#if UNITY_EDITOR
            if (EditorApplication.isPlaying) {
                Destroy(this.gameObject);
            }
#else 
            Destroy(this.gameObject);
#endif
        }
        OnAwake();
    }

    protected virtual void OnAwake() {}
    protected virtual void OnInit() {}
    #endregion
}
public abstract class Singleton : MonoBehaviour {
    #region  Properties
    public static bool Quitting { get; set; }
    #endregion

    #region  Methods
    void OnApplicationQuit() {
        Quitting = true;
    }

    #endregion
}