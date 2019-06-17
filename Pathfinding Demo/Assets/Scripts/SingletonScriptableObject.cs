using System.Linq;
using UnityEngine;

/*
 * Abstract class for making reload-proof singletons out of ScriptableObjects.
 * Returns the asset created on the editor, or null if there is none.
 * 
 * From https://baraujo.net/unity3d-making-singletons-from-scriptableobjects-automatically/
 * 
 * Remember: The asset MUST be referenced by a GameObject within the scene; otherwise, Unity
 * will ignore it, resulting in the accessor returning null.
 */

public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
    static T _instance = null;
    public static T Instance
    {
        get
        {
            if (!_instance)
                _instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
            return _instance;
        }
    }
}
