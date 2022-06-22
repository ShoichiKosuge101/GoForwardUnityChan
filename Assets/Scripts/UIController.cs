using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // �Q�[���I�[�o�[�e�L�X�g
    private GameObject _gameOverText;
    // ���s�����e�L�X�g
    private GameObject _runLengthText;
    // ����������
    private float _len = 0f;
    // ���鑬�x
    private float _speed = 5f;
    // �Q�[���I�[�o�[����
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

            // ����2���ŕ\��
            this._runLengthText.GetComponent<TextMeshProUGUI>().text = $"Distance: {_len.ToString("F2")} m";
        }

        // �Q�[�����X�^�[�g
        if (this._isGameOver)
        {
            // �N���b�N���ꂽ��V�[�����[�h
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
