using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeWayBullet : MonoBehaviour, IPlayerBullet
{
    private Vector3 m_leftPosition = new Vector3(0.0f, 10.0f, 0.0f);
    private Vector3 m_centerPosition = new Vector3(0.0f, 10.0f, 0.0f);
    private Vector3 m_rightPosition = new Vector3(0.0f, 10.0f, 0.0f);

    [SerializeField]
    private GameObject leftBullet;
    [SerializeField]
    private GameObject centerBullet;
    [SerializeField]
    private GameObject rightBullet;

    private bool m_isAlive = false;

    void Awake()
    {
        m_isAlive = true;

        SpriteRenderer renderer = leftBullet.gameObject.GetComponent<SpriteRenderer>();
        renderer.color = Color.blue;
        renderer = centerBullet.gameObject.GetComponent<SpriteRenderer>();
        renderer.color = Color.blue;
        renderer = rightBullet.gameObject.GetComponent<SpriteRenderer>();
        renderer.color = Color.blue;
    }

    public bool IsAlive()
    {
        return m_isAlive;
    }

    public void OnDestroy()
    {
    }
    public GameObject getObj()
    {
        return this.gameObject;
    }

    private void Update()
    {
        if (m_isAlive)
        {
            if (m_centerPosition.y >= 3300.0f)
            {
                m_isAlive = false;
            }
            m_centerPosition.Set(m_centerPosition.x, m_centerPosition.y + 5f, m_centerPosition.z);
            centerBullet.transform.SetLocalPositionAndRotation(m_centerPosition, Quaternion.identity);

            m_leftPosition.Set(m_leftPosition.x - 1f, m_leftPosition.y + 5f, m_leftPosition.z);
            leftBullet.transform.SetLocalPositionAndRotation(m_leftPosition, Quaternion.identity);

            m_rightPosition.Set(m_rightPosition.x + 1f, m_rightPosition.y + 5f, m_rightPosition.z);
            rightBullet.transform.SetLocalPositionAndRotation(m_rightPosition, Quaternion.identity);

            //Debug.Log("pos:" + m_centerPosition);
        }
    }

    // できること
    // N方向の弾
    // 弾の形状を変える（色変えたい、雷みたいなのにするとか)
}

