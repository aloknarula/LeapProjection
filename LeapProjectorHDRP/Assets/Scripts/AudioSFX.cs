using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSFX : MonoBehaviour
{
    public AudioSource m_audioSource;
    public int m_variations = 6;
    int m_counter = 0;
    public List<AudioSource> m_audios;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<m_variations; i++)
        {
            AudioSource go = Instantiate<AudioSource>(m_audioSource);

            go.loop = false;
            go.transform.parent = transform;
            m_audios.Add(go);
        }
    }

    public void PlayMe()
    {
        m_counter++;
        if(m_counter >= m_audios.Count)
        {
            m_counter = 0;
        }
        if(m_audios[m_counter].isPlaying == false)
            m_audios[m_counter].Play();
    }
}
