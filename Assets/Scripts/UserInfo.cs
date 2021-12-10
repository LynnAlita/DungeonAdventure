using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInfo : MonoBehaviour
{
    //����ģʽ
    public static UserInfo Instance;

    //�û�����
    public float Speed;
    public float health;   //Ѫ��
    public float armor;    //����
    public int damage;  //������

    //�û���Ѫ�����ͻ�����
    public Slider slider_health;
    public Slider slider_armor;
    public Text text_health;
    public Text text_armor;

    //�ж��Ƿ��Ѿ����ڻظ�����
    private bool isRecoveringArmor = false;
    //�ж��Ƿ����޵�
    public bool isNB = false;

    void Start()
    {
        //��ҳ�ʼ5��Ѫ 5���
        health = 3;
        armor = 0;

        slider_health.value = health/5;
        slider_armor.value = armor / 5;

        text_health.text = health + " \\ 5";
        text_armor.text = armor + " \\ 5";
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //����δ����״̬�£�ÿ5s�ظ�һ�㻤��
        if(armor != 5 && !isRecoveringArmor)
        {
            InvokeRepeating("recover_armor", 5, 5);
            isRecoveringArmor = true;
        }
        else if(armor == 5)
        {
            CancelInvoke("recover_armor");
            isRecoveringArmor = false;
        }
    }

    void recover_armor()
    {
        armor += 1;
        slider_armor.value = armor / 5;
        text_armor.text = armor + " \\ 5";
    }

    public void recover_health()
    {
        health += 1;
        slider_health.value = health / 5;
        text_health.text = health + " \\ 5";
    }

    //lynn����� ����Ѫ���ͻ���ֵ����������ܵ��˺���
    public void healthOrarmor_update()
    {
        slider_health.value = health / 5;
        slider_armor.value = armor / 5;

        text_health.text = health + " \\ 5";
        text_armor.text = armor + " \\ 5";
    }
}
