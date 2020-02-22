using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤー制御クラス
/// </summary>
public class Player : MonoBehaviour
{

    /// <summary>
    /// プレイヤー状態
    /// </summary>
    public enum PlayerState
    {
        None = -1, 
        Idel,       // 待機中
        Move,
        Jump,       // ジャンプ中
    }
    private PlayerState m_playerState;

    public MainStage01 MainStage { set; get; }

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
    private bool LeftStickStay()
    {
        var left = Input.GetAxis("InputMoveX");
        if (left > 0)
        {
            return true;
        }


        return Input.GetKey(KeyCode.D);
    }

    private bool JumpPush()
    {

        return Input.GetKeyDown(KeyCode.W);
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
        if (LeftStickStay())
        {
            var moveRight = new Vector3(1.0f, 0.0f, 0.0f);
            transform.position += moveRight * Time.deltaTime;
        }

        //ジャンプ設定
        if (JumpPush())
        {
            var rigid = GetComponent<Rigidbody>();
            rigid.AddForce(new Vector3(0.0f, 9.8f*20, 0.0f));
        }
    }

    /// <summary>
    /// プレイヤー更新処理
    /// </summary>
    private void PlayerUpdate()
    {
        Move();
        CollisionUpdate();
    }

    /// <summary>
    /// 当たり判定更新
    /// </summary>
    private void CollisionUpdate()
    {
        
    }

    /// <summary>
    /// 壁との当たり判定
    /// </summary>
    private void CollisionWall()
    {
        var length = StageManager.Instance.mainStage01.length;
        var pos = transform.localPosition;
        var posX = (int)(pos.x / length);
        var posY = (int)(pos.y / length);
        var mapData = StageManager.Instance.mainStage01.GetStageData(posX, posY);

        // 右との当たり判定

        // 左との当たり判定

        // 上との当たり判定

        // 下との当たり判定
        
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
