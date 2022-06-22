using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _body2D;

    // �n�ʂ̈ʒu
    private float _groundLevel = -3.0f;

    [Range(0, 1f)]
    [SerializeField, Tooltip("�W�����v�̌���")] float dump = 0.8f;

    [Range(10, 30)]
    [SerializeField, Tooltip("�W�����v�̑��x")] float jumpVelocity = 20;

    // �f�b�h���C��
    private float _deadLine = -9.0f;
    // ����
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
        // ���郂�[�V����
        this._animator.SetFloat("Horizontal",1);

        // �ڒn����
        //bool isGround= (this.transform.position.y > this._groundLevel) ? false : true;
        bool isGround = this.transform.position.y <= this._groundLevel;
        this._animator.SetBool("isGround",isGround);

        // �W�����v��Ԃł̓{�����[����0�ɂ���
        _footSound.volume = (isGround) ? 1 : 0;

        // �W�����v����
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            this._body2D.velocity = new Vector2(0, this.jumpVelocity);
        }
        // �N���b�N����߂��猸��
        if (Input.GetMouseButtonUp(0))
        {
            this._body2D.velocity *= this.dump;
        }

        // �f�b�h���C���𒴂����ꍇ�Q�[���I�[�o�[
        if(this.transform.position.x < this._deadLine)
        {
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            // ���j�e�B������j��
            Destroy(this.gameObject);
        }

    }
}
