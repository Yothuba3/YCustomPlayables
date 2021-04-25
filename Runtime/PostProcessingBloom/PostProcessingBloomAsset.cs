using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace yothuba.ycustomplayables
{
    [Serializable]
    public class PostProcessingBloomAsset : PlayableAsset
    {
        public PostProcessingBloomBehaviour template;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<PostProcessingBloomBehaviour>.Create(graph, template);
            return playable;
        }
    }
}
