using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab;

    // ���Ԍv���p�ϐ�
    private float _delta = 0f;

    [Range(0f, 2f)]
    [SerializeField, Tooltip("�L���[�u�����Ԋu")]
    float span = 1.0f;

    // �L���[�u�����ʒu X���W
    private float _genPosX = 12f;

    // �L���[�u�����ʒu�I�t�Z�b�g
    private float _offsetY = 0.3f;
    // �L���[�u�c�����Ԋu
    private float _spaceY = 6.9f;

    // �L���[�u�����ʒu
    private float _offsetX = 0.5f;
    // �L���[�u �c���Ԋu
    private float _spaceX = 0.4f;

    [Range(1, 5)]
    [SerializeField, Tooltip("�L���[�u�������")] 
    int maxBlockNum = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this._delta +=Time.deltaTime;

        // span�ȏ�o�߂�����Check
        if (this._delta > this.span)
        {
            // �J�E���^���Z�b�g
            this._delta = 0;

            // �L���[�u����(1 �` maxBockNum)
            var n = Random.Range(1, maxBlockNum+1);

            // �L���[�u��������
            for(int i = 0; i < n; i++)
            {
                GameObject go = Instantiate(cubePrefab);
                // �c�ς݃L���[�u
                // ���ꂼ�ꌄ�Ԃ������󂭂悤�z�u
                go.transform.position = new Vector2(this._genPosX, this._offsetY + i*this._spaceY);
            }

            // ���񐶐��^�C�~���O�̎w��
            // �������ꂽ���ɉ����Ď��̃^�C�~���O���x���Ȃ�
            this.span = this._offsetX + this._spaceX * n;
        }

    }
}
