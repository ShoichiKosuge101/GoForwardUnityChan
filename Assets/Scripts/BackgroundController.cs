using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    // スクロール速度
    private float _scrollSpeed = -1;
    // 背景終了位置
    private float _deadLine = -16;
    // 背景開始位置
    private float _startLine = 15.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 背景を移動
        transform.Translate(this._scrollSpeed * Time.deltaTime, 0,0);

        // 画面外に出たら画面右端に移動
        if (transform.position.x < this._deadLine)
        {
            transform.position = new Vector2(this._startLine,0);
        }
    }
}
