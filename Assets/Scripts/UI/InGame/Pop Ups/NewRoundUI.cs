//Game
using RENEGADES.Common.UI;

//UNity
using UnityEngine;
using TMPro;

namespace RENEGADES.UI.InGame.PopUps
{
    /// <summary>
    /// Simple class to show that a new round is coming up
    /// Decrements timer in round blueprint class and displays round
    /// </summary>
    public class NewRoundUI : UIWidget
    {

        private TextMeshProUGUI txt;
        private TextMeshProUGUI Txt
        {
            get { return txt ?? (txt = GetComponent<TextMeshProUGUI>()); }
        }

        //Lifetime
        private int lifeTime;
        private float alpha = 1;

        //increment timer (3..2..1..)
        private float incrementTimer;
        private float fadeTimer;
        

        //itween punch anim times & fades
        private const float TEXT_ANIM_TIME = 0.5f;
        private const float TEXT_ANIM_SIZE = 2f;
        private const float FADE_TIME = 1.0f;

        //current round
        private int round = 0;

        //once true dont animate anymore
        private bool OnComplete = false;

        public override void Init()
        {
            base.Init();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            //Fade Out
            if (OnComplete)
            {
                SetAlpha(alpha -= Time.deltaTime * FADE_TIME);
                if (GetAlpha() == 0) Destroy(gameObject);
                 return;
            }

            incrementTimer += Time.deltaTime;
            //3..2..1 increment
            if (incrementTimer >= 1 && lifeTime - 1 != 0)
            {
                incrementTimer = 0;
                lifeTime--;
                SetText((lifeTime - 1).ToString(), "Nothing");
            }
            //Set Round text
            else if (lifeTime - 1 == 0)
            {
                OnComplete = true;
                SetText("ROUND " + round.ToString(), "RoundTxtOnComplete");
            }

        }

        public void SetContent(int lifeTime, int round)
        {
            this.lifeTime = lifeTime;
            this.round = round;
            SetText((lifeTime - 1).ToString(), "Nothing");
        }

        public void SetText(string s, string OnAnimComplete)
        {
            Txt.text = s;
            iTween.PunchScale(Txt.gameObject, new Vector3(TEXT_ANIM_SIZE, TEXT_ANIM_SIZE, 0), TEXT_ANIM_TIME);
        }
    }
}
