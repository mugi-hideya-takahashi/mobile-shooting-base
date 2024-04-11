using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerBullet
{
    public bool IsAlive();
    public GameObject getObj();
}

public class PlayerBullet : MonoBehaviour, IPlayerBullet
{
    private Vector3 m_myPosition;
    private GameObject m_myObj;

    private bool m_isAlive = false;

    void Awake()
    {
        m_isAlive = true;
        m_myObj = this.gameObject;
        m_myPosition = this.gameObject.transform.localPosition;
        m_myPosition.y += 10.0f;
        SpriteRenderer renderer = this.gameObject.GetComponent<SpriteRenderer>();
        renderer.color = Color.green;
    }

    public bool IsAlive()
    {
        return m_isAlive;
    }

    public GameObject getObj()
    {
        return m_myObj;
    }

    public void OnDestroy()
    {
    }

    private void Update()
    {
        if (m_isAlive)
        {
            if (m_myPosition.y >= 3300.0f)
            {
                m_isAlive = false;
            }
            m_myPosition.Set(m_myPosition.x, m_myPosition.y + 5f, m_myPosition.z);
            m_myObj.transform.SetLocalPositionAndRotation(m_myPosition, Quaternion.identity);

            //Debug.Log("pos:" + m_myPosition);
        }
    }

    // できること
    // N方向の弾
    // 弾の形状を変える（色変えたい、雷みたいなのにするとか)
}
