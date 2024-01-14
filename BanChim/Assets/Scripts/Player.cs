using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float fireRate;
    float m_curFireRate;
    public GameObject viewfinder;
    bool m_isShooted;
    GameObject m_viewfinderClone;

    private void Awake()
    {
        m_curFireRate = fireRate; 
    }

    private void Start()
    {
        if(viewfinder)
           m_viewfinderClone = Instantiate(viewfinder, Vector3.zero, Quaternion.identity);
        
    }
    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // lay vi tri con tro chuot, chuyen doi giua toa do o tren man hinh nguoi chuoi sang toa do khi nhan tro chuot cua unity 

        

        if (Input.GetMouseButtonDown(0) && !m_isShooted) //kiem tra xem chuot phai da nhan hay chua
        {
            Shoot(mousePos);
        }

        if(m_isShooted) // kiem tra sung da ban hay chua
        {
            m_curFireRate -= Time.deltaTime;

            if(m_curFireRate <= 0)
            {   
                m_isShooted = false;

                m_curFireRate = fireRate;
            }
        }

        if(m_viewfinderClone)
        {
            m_viewfinderClone.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);

        }
    }
    
    void Shoot(Vector3 mousePos) // vi tri con tro chuot
    {
        m_isShooted = true;

        // huong tu camera toi con tro chuot
        Vector3 shootDir = Camera.main.transform.position - mousePos;

        shootDir.Normalize(); // gian luoc vector de may tinh de tinh toan hon

        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, shootDir); // giong tia lazer cham trung cai gi se tra ve thong tin

        if(hits !=null  && hits.Length > 0 )
        {
           for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];

                if (hit.collider && (Vector3.Distance((Vector2)hit.collider.transform.position, (Vector2)mousePos) <= 0.4f)) {
                    Bird bird = hit.collider.GetComponent<Bird>();

                    if(bird) //kiem tra khi con tro chuot ban vao chim thi chim se die
                    {
                        bird.Die();
                    }
                }//kiem tra xem no va cham vat nao chua, k/c va cham giua doi tuong va duong Raycast den con tro chuot ma <= 0.4f 
            }
        }

        AudioController.Ins.PlaySound(AudioController.Ins.shooting);
    }

}
