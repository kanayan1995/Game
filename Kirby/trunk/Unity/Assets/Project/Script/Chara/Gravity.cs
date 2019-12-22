/**
 *  @brief  重力設定
 *  @file   yokoe-asuka
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 重力設定
/// </summary>
public class Gravity : MonoBehaviour
{
    private const float GRAVITY = 1.0f; // 重力設定

    /// <summary>
    /// 更新処理
    /// </summary>
    void Update()
    {
        transform.position += new Vector3(0.0f, -GRAVITY, 0.0f) * Time.deltaTime;
    }
}
