//Unity
using UnityEngine;

//C#
using System.Collections.Generic;

namespace RENEGADES.Common
{
    //lerper help class to go between two values
    public class Lerper 
    {
        public enum Type { COLOR,VECTOR,FLOAT}

        private float speed;
        public Lerper(float speed) { this.speed = speed; }

        public Dictionary<Type,float> calculations = new Dictionary < Type,float>()
        {
            {Type.COLOR,0},
            {Type.VECTOR,0},
            {Type.FLOAT,0}
        };

        public Vector3 Morph(bool trigger,Vector3 current,Vector3 next)
        {
            calculations[Type.VECTOR] = (trigger) ? Mathf.Min(0, calculations[Type.VECTOR] + Time.deltaTime* speed) : Mathf.Max(1, calculations[Type.VECTOR] - Time.deltaTime* speed);
            return Vector3.Lerp(current, next, calculations[Type.VECTOR]);
        }

        public float Morph(bool trigger, float current, float next)
        {
            calculations[Type.FLOAT] = (trigger) ? Mathf.Min(current, calculations[Type.FLOAT] + Time.deltaTime* speed) : Mathf.Max(next, calculations[Type.FLOAT] - Time.deltaTime* speed);
            return calculations[Type.FLOAT];
        }

        public Color Morph(bool trigger,Color current,Color next)
        {
            calculations[Type.COLOR] = (trigger) ? Mathf.Min(0, calculations[Type.COLOR] + Time.deltaTime * speed) : Mathf.Max(1, calculations[Type.COLOR] - Time.deltaTime * speed);
            return Color.Lerp(current, next, calculations[Type.COLOR]);
        }

    }
}
