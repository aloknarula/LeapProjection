using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

public class HandCollider : MonoBehaviour
{
    public CapsuleHand m_hand;
    public HandEnableDisable m_handEnableDisable;
    public Rigidbody m_rigidbody;
    public float m_lerp = 12f;
    bool m_wasDisabled;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody.useGravity = false;
        m_rigidbody.isKinematic = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(m_handEnableDisable.gameObject.activeSelf)
        {
            if(m_wasDisabled)
            {
                transform.position = m_hand.GetLeapHand().PalmPosition.normalized * 20f;
                m_wasDisabled = false;
            }
            m_rigidbody.MovePosition(Vector3.Lerp(transform.position, m_hand.GetLeapHand().PalmPosition, Time.fixedDeltaTime * m_lerp));
        }
        else
        {
            m_wasDisabled = true;
            m_rigidbody.MovePosition(Vector3.Lerp(transform.position, transform.position.normalized * 20f, Time.fixedDeltaTime * m_lerp));
        }
    }
}
