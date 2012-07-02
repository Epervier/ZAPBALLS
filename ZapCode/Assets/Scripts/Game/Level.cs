using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
    #region Public Variables
    public float    m_fLevelDuration;

    public Vector3  m_vBottomLeftCorner;
    public Vector3  m_vUpperRightCorner;

    #endregion

    #region Prefabs
    public Attack               m_pAttack = null;
   
    public EnemyType[]          m_pEnemyTypes = null;
    public EnemyStats[]         m_pEnemyStats = null;
    public LevelObjectType[]    m_pLevelObjectTypes = null;
    public LevelObjectStats[]   m_pLevelObjectStats = null;
    #endregion

    //  The current actual objects in the game
    private BetterList<Attack>      m_pAttacks;
    private BetterList<Enemy>       m_pEnemies;
    private BetterList<LevelObject> m_pLevelObjects;

    public void Initialize()
    {
        m_pAttacks = new BetterList<Attack>();
        m_pEnemies = new BetterList<Enemy>();
        m_pLevelObjects = new BetterList<LevelObject>();

        Vector3 pos = new Vector3(Random.Range(m_vBottomLeftCorner.x, m_vUpperRightCorner.x), Random.Range(m_vBottomLeftCorner.y, m_vUpperRightCorner.y), 50);
        CreateEnemy(pos);

        pos = new Vector3(Random.Range(m_vBottomLeftCorner.x, m_vUpperRightCorner.x), Random.Range(m_vBottomLeftCorner.y, m_vUpperRightCorner.y), 50);
        CreateEnemy(pos);

        pos = new Vector3(Random.Range(m_vBottomLeftCorner.x, m_vUpperRightCorner.x), Random.Range(m_vBottomLeftCorner.y, m_vUpperRightCorner.y), 50);
        CreateEnemy(pos);

    }
	
	// Update is called once per frame
	public bool UpdateLevel ( float dt )
    {
        foreach (Attack attack in m_pAttacks)
        {
            if (attack == null)
                continue;
        }

        foreach (Enemy enemy in m_pEnemies)
        {
            if (enemy == null)
                continue;
            enemy.UpdateEnemy(dt);
            enemy.CheckBounds(m_vBottomLeftCorner, m_vUpperRightCorner);
        }

        foreach (LevelObject lo in m_pLevelObjects)
        {
            if (lo == null)
                continue;
            lo.UpdateLevelObject(dt);
        }

        return false;       // Level is not over
	}

    private void CreateEnemy(Vector3 pos)
    {
        Enemy enemy = Enemy.CreateEnemy(m_pEnemyTypes[Random.Range(0, m_pEnemyTypes.Length)], m_pEnemyStats[Random.Range(0, m_pEnemyStats.Length)], pos, this.gameObject);
        enemy.transform.parent = this.transform;

        m_pEnemies.Add(enemy);
    }
}
