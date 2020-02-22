using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージ情報取得
/// </summary>
public class MainStage01 : MonoBehaviour
{
    
    // マップチップ情報
    public GameObject WallData;    // 壁判定
    public GameObject playerData;  // プレイヤーデータ

    // マップチップステージデータ
    public int[,] MapData = new int[,]
    {
        { 0,0,0,0,0 },
        { 0,0,0,0,0 },
        { 0,0,0,0,0 },
        { 1,0,0,0,0 },
        { 2,2,2,2,2 },
    };


    // マップ生成
    public int length = 2;

    /// <summary>
    /// マップデータ作成
    /// </summary>
    /// <param name="mapData"></param>
    private void CreateMapData( int x , int y ,  int mapData)
    {
        StageManager.MapData data = (StageManager.MapData)mapData;
        GameObject instance = null;
        bool isCreate = true;

        switch (data)
        {
            case StageManager.MapData.None:
                isCreate = false;
                break;
            case StageManager.MapData.Player:
                instance = GameObject.Instantiate(playerData);
                Player player = instance.GetComponent<Player>();
                player.MainStage = this;
                break;
            case StageManager.MapData.Wall:
                instance = GameObject.Instantiate(WallData);
                break;
        }

        // 位置設定
        if (isCreate == true)
        {
            instance.transform.localPosition = new Vector3(x * length, y * length, 0);
            instance.transform.SetParent(this.transform);
        }
    }



    /// <summary>
    /// 全体マップ生成
    /// </summary>
    public void CreateMap()
    {
        for (int y = 0; y < MapData.GetLength(1); y++)
        {
            for (int x = 0; x < MapData.GetLength(0); x++)
            {
                CreateMapData(x, y, MapData[y, x]);
                Debug.Log(MapData[x, y]);
            }
        }
    }

    /// <summary>
    /// ステージデータ取得
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public int GetStageData(int x  ,int y)
    {
        return MapData[x, y];
    }

}
