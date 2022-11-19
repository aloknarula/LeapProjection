using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParticleTrigger : MonoBehaviour
{
    public UnityEvent m_triggerEnter;
    public UnityEvent m_triggerExit;
    public List<Collider> m_collidersInside;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 8)
            return;

        if(m_collidersInside.Contains(other) == false)
        {
            m_collidersInside.Add(other);

            if(m_collidersInside.Count == 1)
            {
                m_triggerEnter.Invoke();
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != 8)
            return;

        if(m_collidersInside.Contains(other))
        {
            m_collidersInside.Remove(other);

            if(m_collidersInside.Count == 0)
            {
                m_triggerExit.Invoke();
            }
        }
    }
}
