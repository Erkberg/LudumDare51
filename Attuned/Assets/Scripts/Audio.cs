using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Attuned
{
    public class Audio : MonoBehaviour
    {
        public List<AudioSource> supportSources;
        public AudioSource endSource;

        public void StartSupportSource(int id)
        {
            if(id != -1)
            {
                supportSources[id].Play();
            }            
        }

        public void OnEnd()
        {
            foreach(AudioSource source in supportSources)
            {
                source.Stop();
            }
            endSource.Play();
        }
    }
}
