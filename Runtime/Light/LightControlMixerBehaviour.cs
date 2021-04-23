using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace yothuba.ycustomplayables
{
    public class LightControlMixerBehaviour : PlayableBehaviour
    {
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            Light trackBinding = playerData as Light;
            float findIntensity = 0f;
            Color findColor = Color.black;

            if (!trackBinding)
                return;

            int inputCount = playable.GetInputCount(); //トラック上の全クリップ数

            for (int i = 0; i < inputCount; i++)
            {
                float inputWeight = playable.GetInputWeight(i);
                ScriptPlayable<LightControlBehaviour> inputPlayable =
                    (ScriptPlayable<LightControlBehaviour>) playable.GetInput(i);
                LightControlBehaviour input = inputPlayable.GetBehaviour();

                findIntensity += input.intensity * inputWeight;
                findColor += input.color * inputWeight;
            }

            trackBinding.intensity = findIntensity;
            trackBinding.color = findColor;
        }
    }
}