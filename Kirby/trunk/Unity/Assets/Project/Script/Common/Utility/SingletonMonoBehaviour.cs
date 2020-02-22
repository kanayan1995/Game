using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// MonoBehaviourを継承したシングルトン
/// </summary>
public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    /// <summary>
    /// インスタンス取得
    /// </summary>
    public static T Instance
    {
        get
        {
            // 初期化
            if (instance == null)
            {
                Type type = typeof(T);

                instance = (T)FindObjectOfType(type);
            }

            return instance;
        }
    }

    /// <summary>
    /// 生成時に呼ばれる関数
    /// </summary>
    virtual protected void Awake()
    {
        if (this!= instance)
        {
            Destroy(this);

            Debug.LogError(
                 typeof(T) +
                 " は既に他のGameObjectにアタッチされているため、コンポーネントを破棄しました." +
                 " アタッチされているGameObjectは " + Instance.gameObject.name + " です.");

            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

}
