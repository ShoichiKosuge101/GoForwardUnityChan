using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _body2D;

    // 地面の位置
    private float _groundLevel = -3.0f;

    [Range(0, 1f)]
    [SerializeField, Tooltip("ジャンプの減衰")] float dump = 0.8f;

    [Range(10, 30)]
    [SerializeField, Tooltip("ジャンプの速度")] float jumpVelocity = 20;

    // デッドライン
    private float _deadLine = -9.0f;
    // 足音
    private AudioSource _footSound;

    // Start is called before the first frame update
    void Start()
    {
        this._animator = this.GetComponent<Animator>();
        this._body2D = this.GetComponent<Rigidbody2D>();
        _footSound = this.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        // 走るモーション
        this._animator.SetFloat("Horizontal",1);

        // 接地判定
        //bool isGround= (this.transform.position.y > this._groundLevel) ? false : true;
        bool isGround = this.transform.position.y <= this._groundLevel;
        this._animator.SetBool("isGround",isGround);

        // ジャンプ状態ではボリュームを0にする
        _footSound.volume = (isGround) ? 1 : 0;

        // ジャンプ判定
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            this._body2D.velocity = new Vector2(0, this.jumpVelocity);
        }
        // クリックをやめたら減衰
        if (Input.GetMouseButtonUp(0))
        {
            this._body2D.velocity *= this.dump;
        }

        // デッドラインを超えた場合ゲームオーバー
        if(this.transform.position.x < this._deadLine)
        {
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            // ユニティちゃんを破棄
            Destroy(this.gameObject);
        }

    }
}
