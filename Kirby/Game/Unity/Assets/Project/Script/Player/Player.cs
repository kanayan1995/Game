using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤー制御クラス
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>
    /// 生成時呼び出し処理
    /// </summary>
    private void Awake()
    {
        
    }

    /// <summary>
    /// 右スティック入力
    /// </summary>
    /// <returns></returns>
    private bool RightStickStay()
    {      
        var right = Input.GetAxis("InputMoveX");
        if (right < 0)
        {
            return true;
        }

        return Input.GetKey(KeyCode.A);
    }

    /// <summary>
    /// 左スティック入力
    /// </summary>
    /// <returns></returns>
    private bool LefttickStay()
    {
        var left = Input.GetAxis("InputMoveX");
        if (left > 0)
        {
            return true;
        }


        return Input.GetKey(KeyCode.D);
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    private void Move()
    {
        // 左移動
        if (RightStickStay())
        {
            var moveLeft = new Vector3(-1.0f, 0.0f, 0.0f);
            transform.position += moveLeft * Time.deltaTime;
        }

        // 右移動
        if (LefttickStay())
        {
            var moveRight = new Vector3(1.0f, 0.0f, 0.0f);
            transform.position += moveRight * Time.deltaTime;
        }
    }

    /// <summary>
    /// プレイヤー更新処理
    /// </summary>
    private void PlayerUpdate()
    {
        Move();
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    void Update()
    {
        PlayerUpdate();
    }

    /// <summary>
    /// デバッグ表示設定
    /// </summary>
    private void OnGUI()
    {
        var leftStick = Input.GetAxis("InputMoveX");
        string testText = "inputX : " + leftStick + "\n";

        testText = GUI.TextArea(new Rect(10, 10, 200, 100), testText);
    }
}
