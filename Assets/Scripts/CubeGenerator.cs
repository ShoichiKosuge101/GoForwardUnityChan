using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab;

    // 時間計測用変数
    private float _delta = 0f;

    [Range(0f, 2f)]
    [SerializeField, Tooltip("キューブ生成間隔")]
    float span = 1.0f;

    // キューブ生成位置 X座標
    private float _genPosX = 12f;

    // キューブ生成位置オフセット
    private float _offsetY = 0.3f;
    // キューブ縦方向間隔
    private float _spaceY = 6.9f;

    // キューブ生成位置
    private float _offsetX = 0.5f;
    // キューブ 縦横間隔
    private float _spaceX = 0.4f;

    [Range(1, 5)]
    [SerializeField, Tooltip("キューブ生成上限")] 
    int maxBlockNum = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this._delta +=Time.deltaTime;

        // span以上経過したかCheck
        if (this._delta > this.span)
        {
            // カウンタリセット
            this._delta = 0;

            // キューブ生成(1 ～ maxBockNum)
            var n = Random.Range(1, maxBlockNum+1);

            // キューブ生成処理
            for(int i = 0; i < n; i++)
            {
                GameObject go = Instantiate(cubePrefab);
                // 縦積みキューブ
                // それぞれ隙間が少し空くよう配置
                go.transform.position = new Vector2(this._genPosX, this._offsetY + i*this._spaceY);
            }

            // 次回生成タイミングの指定
            // 生成された数に応じて次のタイミングが遅くなる
            this.span = this._offsetX + this._spaceX * n;
        }

    }
}
