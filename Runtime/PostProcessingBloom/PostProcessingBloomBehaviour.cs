using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


namespace yothuba.ycustomplayables
{
    [Serializable]
    public class PostProcessingBloomBehaviour : PlayableBehaviour
    {
        public float threshold = 1.0f;
        public float intensity = 1.0f;
    }
}