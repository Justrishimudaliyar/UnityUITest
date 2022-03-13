using UnityEngine;

/// <summary>
/// This is a Generic Singleton Class which can be inherited to make that child class a Singleton.
/// </summary>

public class SingletonGenericScript<T> : MonoBehaviour where T : SingletonGenericScript<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}