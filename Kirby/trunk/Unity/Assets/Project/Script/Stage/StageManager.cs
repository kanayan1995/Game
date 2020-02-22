using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージ情報を管理するツール
/// </summary>
public class StageManager : SingletonMonoBehaviour<StageManager>
{
    public MainStage01 mainStage01;   // 今日の設定

    /// <summary>
    /// マップ属性
    /// </summary>
    public enum MapData
    {
        None,
        Player, // プレイヤー
        Wall,   // 通常壁
    }

    /// <summary>
    /// 初期化設定
    /// </summary>
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// 初期化設定
    /// </summary>
    private void Start()
    {
        LoadStageData(0);
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        
    }

    /// <summary>
    /// ステージロードを行う
    /// </summary>
    public void LoadStageData(int index)
    {
        if (index == 0)
        {
            // ステージ設定
            mainStage01.CreateMap();
        }
    }
}
