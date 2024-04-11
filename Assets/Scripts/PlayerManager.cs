using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    GameObject playerObj;

    [SerializeField]
    PlayerBullet m_simpleBullet;
    [SerializeField]
    ThreeWayBullet m_threeWayBullet;


    [SerializeField]
    GameObject m_PlayerBulletRoot;

    List<IPlayerBullet> m_listPlayerBullets;

    private int m_cnt = 0;

    float posX;
    float posY;

    // Start is called before the first frame update
    void Start()
    {
        posX = 0.0f;
        posY = -1300.0f;

        playerObj.transform.SetLocalPositionAndRotation(new Vector3(posX, -1300.0f, 0.0f), Quaternion.identity);

        m_listPlayerBullets = new List<IPlayerBullet>();

        m_cnt = 0;
        StartCoroutine(BulletAliveCheckCoroutine());
    }

    IEnumerator BulletAliveCheckCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            for (int i = m_listPlayerBullets.Count - 1; i >= 0; --i)
            {
                if (!m_listPlayerBullets[i].IsAlive())
                {
                    var tgt = m_listPlayerBullets[i];
                    m_listPlayerBullets.RemoveAt(i);

                    //tgt.gameObject.SetActive(false);
                    Destroy(tgt.getObj());
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        bool isChange = false;

        // ç∂âE
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            posX -= 2.0f;
            isChange = true;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            posX += 2.0f;
            isChange = true;
        }

        //è„â∫
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            posY += 2.0f;
            isChange = true;
        }else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            posY -= 2.0f;
            isChange = true;
        }

        if (isChange)
        {
            posX = Mathf.Clamp(posX, -870f, 870f);
            posY = Mathf.Clamp(posY, -1500.0f, 1350.0f);

            playerObj.transform.SetLocalPositionAndRotation(new Vector3(posX, posY/*-4.0f*/, 0.0f), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(m_cnt%2 == 0)
            {
                PlayerBullet bullet =
                    Instantiate(
                        m_simpleBullet,
                        playerObj.transform.localPosition,
                        Quaternion.identity,
                        m_PlayerBulletRoot.transform);
                m_listPlayerBullets.Add(bullet);
            }
            else
            {
                ThreeWayBullet threeWayBullet = 
                    Instantiate(
                        m_threeWayBullet,
                        playerObj.transform.localPosition,
                        Quaternion.identity,
                        m_PlayerBulletRoot.transform);

                m_listPlayerBullets.Add(threeWayBullet);
            }
            m_cnt++;

        }
    }
}
