using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float xSpeed;
    public float minySpeed;
    public float maxySpeed;
    public GameObject deathVfx;

    Rigidbody2D m_rb;
    bool m_moveLeftOnStart; // xem chim co di chuyen ve ben trai k

    bool m_isDead;

    private void Awake() //truoc khi game chay
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        RandomMovingDir();
    }

    private void Update()
    {
        //m_rb.velocity = new Vector2(xSpeed, Random.Range(minySpeed, maxySpeed)); van toc cua chim

        m_rb.velocity = m_moveLeftOnStart ?
            new Vector2(-xSpeed, Random.Range(minySpeed, maxySpeed)) //neu true di chuyen ve tay trai, neu false di chuyen ve phia ben phai
             : new Vector2(xSpeed, Random.Range(minySpeed, maxySpeed));

        Flip();
    }

    public void RandomMovingDir() //huong di chuyen ngau nhien cua chim
    {
        m_moveLeftOnStart = transform.position.x > 0 ? true : false; //neu vi tri x cua chim o ben tay phai thi no se di chuyen ve ben trai
    }

    void Flip()
    {
        if (m_moveLeftOnStart) //neu con chim di chuyen ve phia tay trai thi kiem tra Scale
        {
            if (transform.localScale.x < 0) // neu > 0 thi thay doi huong di chuyen
                return;

            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            if (transform.localScale.x > 0)
                return;

            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

    }

    public void Die()
    {
        m_isDead = true;

        GameController.Ins.BirdKill++;

        Destroy(gameObject);

        if(deathVfx) //hieu ung mau ban ra khi chim chet
           Instantiate(deathVfx, transform.position, Quaternion.identity);
        
    }
}
