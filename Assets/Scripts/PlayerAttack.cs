using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private PolygonCollider2D coll2D;
    //��ҹ����ĳ���ʱ��
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        //��ȡ��Ҷ���
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        //��ȡ������Χ��ײ��
        coll2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //��ҹ���
    public void Attack()
    {
        anim.SetTrigger("Attack");
        StartCoroutine(startHitBox());
    }

    //�ȴ�0.1s��ʼ������� ���Ϊ����ǰҡ
    IEnumerator startHitBox()
    {
        yield return new WaitForSeconds(0.1f);
        coll2D.enabled = true;
        StartCoroutine(disableHitBox());
    }

    //ʹ��Э�̣��ж���ҹ�����Ϻ�ȡ���������
    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        coll2D.enabled = false;
    }

    //��ҹ���
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Monster"))
        {
            other.gameObject.GetComponent<Monster>().TakeDamage(UserInfo.Instance.damage);
        }
    }
}
