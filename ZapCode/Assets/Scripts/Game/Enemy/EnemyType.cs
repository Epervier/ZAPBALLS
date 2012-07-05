using UnityEngine;
using System.Collections;

public class EnemyType : MonoBehaviour {

    public float m_fSize = 1.0f;
    public string m_sName = "EnemyType";
    public Vector3 m_vDirection;
    protected Enemy m_pParent = null;
    
    public virtual void Initialize(Enemy parent)
    {
        m_pParent = parent;
        this.transform.parent = m_pParent.transform;
        this.gameObject.name = m_sName;
        this.transform.localScale = new Vector3(m_fSize, m_fSize, m_fSize);
        this.transform.position = new Vector3();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public virtual void UpdateType(float dt)
    {
        float fAlpha = m_pParent.Health / m_pParent.m_pStats.fHealth;
        if (fAlpha < 0)
            fAlpha = 0;
        
        foreach (Material mat in this.renderer.materials)
	    {
            Color col = mat.color;
            col.a = fAlpha;
            mat.SetColor("_Color", col);
	    }
        
    }

    /// <summary>
    /// Check vs the level bounds to see if something should happen.  Some types may want to change direction, or fade out, or whatever
    /// </summary>
    /// <param name="bottomLeft"></param>
    /// <param name="upperRight"></param>
    public virtual void CheckBounds(Vector3 bottomLeft, Vector3 upperRight)
    {
        
    }

    public virtual void EnemyHit( float fDamage )
    {
        m_pParent.Health -= fDamage;
    }

    public virtual void OnDeath()
    {

    }
}
