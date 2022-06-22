using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    // �X�N���[�����x
    private float _scrollSpeed = -1;
    // �w�i�I���ʒu
    private float _deadLine = -16;
    // �w�i�J�n�ʒu
    private float _startLine = 15.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �w�i���ړ�
        transform.Translate(this._scrollSpeed * Time.deltaTime, 0,0);

        // ��ʊO�ɏo�����ʉE�[�Ɉړ�
        if (transform.position.x < this._deadLine)
        {
            transform.position = new Vector2(this._startLine,0);
        }
    }
}
