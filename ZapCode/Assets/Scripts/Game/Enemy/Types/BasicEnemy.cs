using UnityEngine;
using System.Collections;

public class BasicEnemy : EnemyType {

    public override void Initialize(Enemy parent)
    {
        base.Initialize(parent);
        m_vDirection = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
        m_vDirection.Normalize();
 
        m_sName = "Basic Enemy";
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
        {
            m_vDirection.x *= -1;
            //pos.x = upperRight.x;
        }
        else if (pos.x > upperRight.x)
        {
            m_vDirection.x *= -1;
            //pos.x = bottomLeft.x;
        }

        if (pos.y < bottomLeft.y)
        {
            m_vDirection.y *= -1;
            //pos.y = upperRight.y;
        }
        else if (pos.y > upperRight.y)
        {
            m_vDirection.y *= -1;
            //pos.y = bottomLeft.y;
        }
        transform.position = pos;
    }
}
