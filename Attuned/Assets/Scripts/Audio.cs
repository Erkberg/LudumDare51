using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Attuned
{
    public class Audio : MonoBehaviour
    {
        public List<AudioSource> supportSources;

        public void StartSupportSource(int id)
        {
            if(id != -1)
            {
                supportSources[id].Play();
            }            
        }
    }
}
