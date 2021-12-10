using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Item_SpeedUp"))
        {
            //�񵽼��ٵ��ߣ����10s����Ч��
            UserInfo.Instance.Speed += 8;
            //��������ƶ��ٶ�
            gameObject.GetComponent<PlayerMove>().Update_Speed();
            Destroy(other.gameObject);
            Invoke("Reset_Speed", 10);
        } else if(other.CompareTag("Item_HealthUp"))
        {
            //�񵽻�Ѫ���� Ѫ����1
            if(UserInfo.Instance.health != 5)
            {
                GameObject.Find("UserInfo").GetComponent<UserInfo>().recover_health();
            }
            Destroy(other.gameObject);
        } else if(other.CompareTag("Item_Shiled"))
        {
            //���޵е��� ����޵�6s
            UserInfo.Instance.isNB = true;
            Invoke("Reset_NB", 6);
            Destroy(other.gameObject);
        }
    }

    //��������ٶ�
    public void Reset_Speed()
    {
        UserInfo.Instance.Speed = 8;
        gameObject.GetComponent<PlayerMove>().Update_Speed();
    }

    //��������޵�״̬
    public void Reset_NB()
    {
        UserInfo.Instance.isNB = false;
    }

    //����յ��˺�����Ѫ���ͻ��׵ļ��ٷ���
    public void DamageByMonster()
    {
        //���ж��Ƿ����޵�״̬
        if (!UserInfo.Instance.isNB)
        {
            //�������ݹ���Ĺ�������������ֵ
            if (UserInfo.Instance.armor >= 2)
            {
                UserInfo.Instance.armor -= 2;
                UserInfo.Instance.healthOrarmor_update();
            }
            else if (UserInfo.Instance.armor == 1)
            {
                UserInfo.Instance.armor = 0;
                UserInfo.Instance.health -= 1;
                UserInfo.Instance.healthOrarmor_update();
            }
            else if (UserInfo.Instance.health >= 3)
            {
                UserInfo.Instance.health -= 2;
                UserInfo.Instance.healthOrarmor_update();
            }
            else //���Ѫ����0���޷��ƶ�����������״̬������game over Ȼ�����¿�ʼ
            {
                UserInfo.Instance.health = 0;
                UserInfo.Instance.healthOrarmor_update();
            }
        }

    }
}