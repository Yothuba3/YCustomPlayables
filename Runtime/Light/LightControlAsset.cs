using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace yothuba.ycustomplayables
{
    [Serializable]
    public class LightControlAsset : PlayableAsset
    {
        public LightControlBehaviour template;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<LightControlBehaviour>.Create(graph, template);
            return playable;
        }
    }

}