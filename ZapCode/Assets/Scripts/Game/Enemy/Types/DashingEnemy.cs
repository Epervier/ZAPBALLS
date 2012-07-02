using UnityEngine;
using System.Collections;

public class DashingEnemy : EnemyType {

    enum State { Moving = 0, Slowing, Stopped }

    public override void Initialize(Enemy parent)
    {
        base.Initialize(parent);
        m_sName = "Dashing Enemy";
    }

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    public override void UpdateType(float dt)
    {

    }
}
