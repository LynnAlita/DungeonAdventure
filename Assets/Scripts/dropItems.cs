using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropItems : MonoBehaviour
{
    //��������
    public GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Drop()
    {
        //��ȡ��ǰ�����λ��
        Vector3 pos = transform.position;
        pos.y += 1f;
        //��ȡ�������ĵ��߶������ɸõ���
        Instantiate(items[Random.Range(0, items.Length)], pos, Quaternion.identity);
        //ɾ����ǰ�������
        //Destroy(gameObject);
    }
}
