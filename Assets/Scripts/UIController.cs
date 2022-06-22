using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // ゲームオーバーテキスト
    private GameObject _gameOverText;
    // 走行距離テキスト
    private GameObject _runLengthText;
    // 走った距離
    private float _len = 0f;
    // 走る速度
    private float _speed = 5f;
    // ゲームオーバー判定
    private bool _isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        _gameOverText = GameObject.Find("GameOver");
        _runLengthText = GameObject.Find("RunLength");
    }

    // Update is called once per frame
    void Update()
    {
        if (!this._isGameOver)
        {
            this._len+=this._speed * Time.deltaTime;

            // 少数2桁で表示
            this._runLengthText.GetComponent<TextMeshProUGUI>().text = $"Distance: {_len.ToString("F2")} m";
        }

        // ゲームリスタート
        if (this._isGameOver)
        {
            // クリックされたらシーンロード
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void GameOver()
    {
        this._gameOverText.GetComponent<TextMeshProUGUI>().text = "Game Over";
        this._isGameOver = true;
    }
}
