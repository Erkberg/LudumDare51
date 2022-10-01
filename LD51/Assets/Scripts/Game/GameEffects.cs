using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class GameEffects : MonoBehaviour
    {
        public ParticleSystem hearticle;

        public void EmitHearticleAtPosition(Vector3 position)
        {
            hearticle.transform.position = position;
            hearticle.Emit(1);
        }
    }
}
