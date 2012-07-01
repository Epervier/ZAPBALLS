using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
    #region Variables
    //public float m_fLevelDuration { get { return m_fLevelDuration; } set { SetLevelDuration(value); } }
    public float m_fLevelDuration;

    #endregion

    #region Prefabs
    public Attack m_pAttack = null;
   
    public EnemyType[] m_pEnemyTypes = null;
    public EnemyStats[] m_pEnemyStats = null;
    public LevelObjectType[] m_pLevelObjectTypes = null;
    public LevelObjectStats[] m_pLevelObjectStats = null;

    #endregion


    public void Initialize()
    {

    }
	
	// Update is called once per frame
	void UpdateLevel ( float dt )
    {
	    
	}

    private void SetLevelDuration(float fDuration)
    {
    }
}
