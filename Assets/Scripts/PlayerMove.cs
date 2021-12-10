using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    //����ƶ��ٶ�
    float m_speed;

    private Animator m_animator;
    private Rigidbody2D m_body2d;
    private bool m_combatIdle = false;
    private bool m_isDead = false;

    //�жϽ�ɫ�Ƿ���ˮƽ\��ֱ�ƶ�
    private bool isMoving_h = false;
    private bool isMoving_v = false;

    //����ҡ��
    public Joystick joy;

    //�ƶ�������
    Vector2 movement;

    //Translate�ƶ����ƺ���
    void MoveControlByTranslateGetAxis()
    {
        float horizontal = joy.Horizontal;
        float vertical = joy.Vertical;

        movement.x = horizontal;
        movement.y = vertical;

        if (horizontal != 0 && vertical != 0)
        {
            isMoving_h = true;
            isMoving_v = true;
        }
        else if(horizontal != 0 && vertical == 0)
        {
            isMoving_h = true;
            isMoving_v = false;
        } else if (horizontal == 0 && vertical != 0)
        {
            isMoving_h = false;
            isMoving_v = true;
        }
        else
        {
            isMoving_h = false;
            isMoving_v = false;
        }

        //�������ﳯ��
        if (horizontal > 0)
            transform.localScale = new Vector3(-3f, 3f, 3f);
        else if (horizontal < 0)
            transform.localScale = new Vector3(3f, 3f, 3f);

        //���������ƶ�����
        m_animator.SetFloat("AirSpeed", 1);
        if (Mathf.Abs(horizontal) > Mathf.Epsilon)
        {
            m_animator.SetInteger("AnimState", 2);
        }

        //��moveposition�ƶ�
        m_body2d.MovePosition(m_body2d.position + movement * m_speed * Time.fixedDeltaTime);
    }

    // Use this for initialization
    void Start()
    {
        Update_Speed();
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!(isMoving_h || isMoving_v))
        {
            m_animator.SetInteger("AnimState", 0);
        }
    }

    private void FixedUpdate()
    {
        //�����ƶ�
        MoveControlByTranslateGetAxis();
    }

    //��������ٶ�
    public void Update_Speed()
    {
        m_speed = UserInfo.Instance.Speed;
    }

}
