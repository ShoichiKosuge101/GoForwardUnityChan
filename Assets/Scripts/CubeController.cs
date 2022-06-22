using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField, Tooltip("�L���[�u�̈ړ����x")] 
    float speed = -12;

    // ���ňʒu
    private float _deadLine = -10;
    // �T�E���h
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        this._audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // �L���[�u�̈ړ�(���Έʒu)
        // Time.deltaTime �͑O��t���[������̕ω�����(�t���[�����[�g�����̋z��)
        this.transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // ��ʊO�ɏo����j��
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
