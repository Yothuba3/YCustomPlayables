using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Timeline;

namespace yothuba.ycustomplayables
{
    [TrackClipType(typeof(PostProcessingBloomAsset))]
    [TrackBindingType(typeof(PostProcessVolume))]
    public class PostProcessingBloomTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<PostProcessingBloomMixerBehaviour>.Create(graph, inputCount);
        }
    }
}