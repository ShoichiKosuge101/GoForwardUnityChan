using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField, Tooltip("キューブの移動速度")] 
    float speed = -12;

    // 消滅位置
    private float _deadLine = -10;
    // サウンド
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        this._audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // キューブの移動(相対位置)
        // Time.deltaTime は前回フレームからの変化時間(フレームレート差分の吸収)
        this.transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄
        if (transform.position.x < this._deadLine)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            _audioSource.Play();
        }
    }
}
