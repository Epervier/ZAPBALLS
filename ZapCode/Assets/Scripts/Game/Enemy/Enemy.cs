using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    #region Variables

    private float m_fHealth;
    private float m_fSpeed;

    /// <summary>
    /// Contains the stats the enemy has when it is spawned.  Doesnt change!  The pointer might, but the values within are read only.
    /// </summary>
    public EnemyStats m_pStats;
    public EnemyType m_pType;

    #endregion

    #region Properties   
    
    public float Health
    {
        get { return m_fHealth; }
        set { m_fHealth = value; }
    }

    public float Speed
    {
        get { return m_fSpeed; }
        set { m_fSpeed = value; }
    }

    #endregion

   
    public void Initialize(EnemyType type, EnemyStats stats)
    {
        m_pStats = Instantiate(stats) as EnemyStats;
        m_pStats.transform.parent = this.transform;
        m_pStats.gameObject.layer = this.gameObject.layer;

        m_pType = Instantiate(type) as EnemyType;
        m_pType.Initialize(this);
        m_pType.gameObject.layer = this.gameObject.layer;
        gameObject.name = m_pType.m_sName;
        
        
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void UpdateEnemy( float dt ) 
    {
        m_pType.UpdateType(dt);
	}

    public void CheckBounds(Vector3 bottomLeft, Vector3 upperRight)
    {
        m_pType.CheckBounds(bottomLeft, upperRight);
    }

    public static Enemy CreateEnemy(EnemyType type, EnemyStats stats, Vector3 pos, GameObject parent)
    {
        GameObject go = new GameObject();
        go.AddComponent<Enemy>();
        go.layer = parent.layer;

        Enemy enemy = go.GetComponent<Enemy>();
        enemy.Initialize(type, stats);

        go.transform.position = pos;

        return enemy;
    }
}
