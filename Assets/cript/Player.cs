//���̺귯��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ŭ����
public class Player : MonoBehaviour
{   // �������� �� ���ȿ� ���� public�� ������ !!
    // �� private�� �ٲٰ� �ش� ���� ���� [SerializeField] ����
    // ���� ����
    //public float moveSpeed = 3f;
    [SerializeField]
    private float moveSpeed = 3f;


    // Start is called before the first frame update
    // ��ũ��Ʈ�� ���۵� �� �Լ��� �����
    void Start()
    {
        
    }

    // Update is called once per frame
    // �����Ӹ��� �Լ��� �����
    void Update() // == private void Update()
    {
        // �ֵ���ǥ ��� �� string ���ڿ��� �޾ƿ´�.
        float h = Input.GetAxis("Horizontal");
        float playerSpeed = h * moveSpeed * Time.deltaTime;
        Vector3 vector3 = new Vector3();
        vector3.x = playerSpeed;
        // �ش��ϴ� ������Ʈ�� �̵���Ų��.
        transform.Translate(vector3);

        // Horizontal���� �������
        if(h<0)
        {
            // �����̸� �ִϸ��̼ǰ��� �ٲ۴�.
            GetComponent<Animator>().SetBool("Walk", true);
            // ������ x���� -1�� �ٲ۴�.
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(h == 0)
        {
            // �������� �ʴ´ٸ� False��
            GetComponent<Animator>().SetBool("Walk", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Walk", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
