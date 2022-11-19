using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour
{
    public ParticleSystem m_effect;

    void Awake()
    {
        if(m_effect == null)
        {
            m_effect = GetComponent<ParticleSystem>();   
        }
    }

    void SetEmmision(bool set)
    {
        if(m_effect == null)
        {
            return;
        }

        ParticleSystem.EmissionModule em = m_effect.emission;

        em.enabled = set;
    }

    public void EnableEffect()
    {
        SetEmmision(true);
    }
    
    public void DisableEffect()
    {
        SetEmmision(false);
    }
}
