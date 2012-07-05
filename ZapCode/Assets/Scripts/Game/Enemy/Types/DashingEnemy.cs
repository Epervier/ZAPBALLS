using UnityEngine;
using System.Collections;

public class DashingEnemy : EnemyType {

    enum State { Moving = 0, Slowing, Stopped }

    public override void Initialize(Enemy parent)
    {
        base.Initialize(parent);
        float fAngle = Random.Range(0, 360);
        
        m_vDirection = new Vector3(1, 1, 0);
        float m_fSin = Mathf.Sin(fAngle);
        float m_fCos = Mathf.Cos(fAngle);
        float fX = m_vDirection.x * m_fCos - m_vDirection.y * m_fSin;
        float fY = m_vDirection.x * m_fSin + m_vDirection.y * m_fCos;
        m_vDirection.x = fX;
        m_vDirection.y = fY;
        m_vDirection.Normalize();

        m_sName = "Dashing Enemy";
    }

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    public override void UpdateType(float dt)
    {
        base.UpdateType(dt);
        this.transform.position += m_vDirection * dt * m_pParent.Speed;

    }

    public override void CheckBounds(Vector3 bottomLeft, Vector3 upperRight)
    {
        Vector3 pos = transform.position;
        if (pos.x < bottomLeft.x)
            pos.x = upperRight.x;
        else if (pos.x > upperRight.x)
            pos.x = bottomLeft.x;

        if (pos.y < bottomLeft.y)
            pos.y = upperRight.y;
        else if (pos.y > upperRight.y)
            pos.y = bottomLeft.y;

        transform.position = pos;
    }
}
