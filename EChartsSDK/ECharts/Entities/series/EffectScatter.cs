///////////////////////////////////////////////////////////
//  EffectScatter.cs
//  Implementation of the Class EffectScatter
//  Generated by Enterprise Architect
//  Created on:      15-2��-2017 22:04:53
//  Original author: Doku
///////////////////////////////////////////////////////////

namespace ECharts.Entities.series
{
    public class EffectScatter : Scatter
    {
        public EffectScatter()
        {
            type = ChartType.effectScatter;
        }

        public EffectScatter(string name)
            : this()
        {
            this.name = name;
        }

        public string effectType { get; set; }

        public ShowEffectType showEffectOn { get; set; }


        public RippleEffect rippleEffect { get; set; }

        public EffectScatter EffectType(string effectType)
        {
            this.effectType = effectType;
            return this;
        }

        public EffectScatter ShowEffectOn(ShowEffectType showEffectOn)
        {
            this.showEffectOn = showEffectOn;

            return this;
        }

        public RippleEffect RippleEffect()
        {
            if (rippleEffect == null)
                rippleEffect = new RippleEffect();
            return rippleEffect;
        }

        public RippleEffect RippleEffect(RippleEffect rippleEffect)
        {
            this.rippleEffect = rippleEffect;
            return rippleEffect;
        }
    } //end EffectScatter
} //end namespace series