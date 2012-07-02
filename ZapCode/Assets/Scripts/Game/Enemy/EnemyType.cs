using UnityEngine;
using System.Collections;

public class EnemyType : MonoBehaviour {

    public string m_sName = "EnemyType";
    private Enemy m_pParent = null;

    public void Initialize(Enemy parent)
    {
        m_pParent = parent;
        this.transform.parent = m_pParent.transform;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void UpdateType(float dt)
    {

    }

}
