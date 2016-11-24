//Game
using RENEGADES.Common.UI;

//UNity
using UnityEngine;

namespace RENEGADES.UI.InGame.PopUps
{
    public class GameOverUI : UIWidget
    {
        private const float ANIM_TIME = 1.0f;
        private const float ANIM_SCALE = 1.0f;
        private const iTween.EaseType ANIM_EASETYPE = iTween.EaseType.linear;

        public override void Init()
        {
            base.Init();
            SetAlpha(0);
            Punch_Animation();
            FadeTo();
        }


        private void FadeTo()
        {   //the gameobject that animates
            iTween.ValueTo(gameObject, iTween.Hash(
              "from", GetAlpha(),
              "to", 1.0f,
              "time", ANIM_TIME,
              "easetype", ANIM_EASETYPE,
             // "oncomplete","Anim_OnCompleted",
              "onupdate", "Alpha")); //function called every frame of animation
        }

        private void Alpha(float newValue) //function that gets called every frame
        {
            SetAlpha(newValue);
        }

        private void Punch_Animation()
        {
            iTween.PunchScale(gameObject, new Vector3(ANIM_SCALE*1.1f, ANIM_SCALE * 1.1f, 0), ANIM_TIME+1);
        }
    }
}
