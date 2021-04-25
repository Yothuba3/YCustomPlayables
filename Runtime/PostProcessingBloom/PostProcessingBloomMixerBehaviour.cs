using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering.PostProcessing;

namespace yothuba.ycustomplayables
{


    public class PostProcessingBloomMixerBehaviour : PlayableBehaviour
    {
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            PostProcessVolume trackBinding = playerData as PostProcessVolume;
            float findIntensity = 0f;
            float findThreashold = 0f;

            if (!trackBinding)
                return;

            var bloom = trackBinding.profile.GetSetting<Bloom>();
            if(!bloom)
                return;

            int inputCount = playable.GetInputCount();

            for (int i = 0; i < inputCount; i++)
            {
                float inputWeight = playable.GetInputWeight(i);
                ScriptPlayable<PostProcessingBloomBehaviour> inputPlayable =
                    (ScriptPlayable<PostProcessingBloomBehaviour>) playable.GetInput(i);
                PostProcessingBloomBehaviour input = inputPlayable.GetBehaviour();

                findIntensity += input.intensity * inputWeight;
                findThreashold += input.threshold * inputWeight;
            }

            bloom.intensity.Override(findIntensity);
            bloom.threshold.Override(findThreashold);
            PostProcessManager.instance.QuickVolume(trackBinding.gameObject.layer,1, bloom);
        }
    }
}
