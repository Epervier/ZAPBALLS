using UnityEngine;
using System.Collections;

public class EnemyType : MonoBehaviour {


    public string m_sName = "EnemyType";
    public Vector3 m_vDirection;
    protected Enemy m_pParent = null;
    


    public virtual void Initialize(Enemy parent)
    {
        m_pParent = parent;
        this.transform.parent = m_pParent.transform;
        this.gameObject.name = m_sName;
        this.transform.position = new Vector3();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public virtual void UpdateType(float dt)
    {

    }

    /// <summary>
    /// Check vs the level bounds to see if something should happen.  Some types may want to change direction, or fade out, or whatever
    /// </summary>
    /// <param name="bottomLeft"></param>
    /// <param name="upperRight"></param>
    public virtual void CheckBounds(Vector3 bottomLeft, Vector3 upperRight)
    {
        
    }

}
