//Unity
using TMPro;
using UnityEngine;
using UnityEngine.UI;


//Game
using RENEGADES.Common;
using RENEGADES.Managers;

namespace RENEGADES.UI.MainMenu.CharacterSelect
{
    public class CharacterDisplay : MonoBehaviour
    {
        [Header("What player is this?")]
        public GameSettings.PlayerType playerType;

        private TextMeshProUGUI txt;
        private TextMeshProUGUI Txt
        {
            get { return txt ?? (txt = GetComponentInChildren<TextMeshProUGUI>()); }
        }

        private RawImage image;
        private RawImage Img
        {
            get { return image ?? (image = GetComponent<RawImage>()); }
        }

        private CharacterSelect selection;
        private CharacterSelect Selection
        {
            get { return selection ?? (selection = GetComponentInParent<CharacterSelect>()); }
        }

        private bool isSelected;

        private Lerper txtColorLerp = new Lerper(1);
        private Lerper imageColorLerp = new Lerper(3);

        public int controllCount = 0;

        public Vector3 GetPos()
        {
            return transform.localPosition;
        }

        private void Update()
        {
            Txt.color = txtColorLerp.Morph(isSelected, Selection.textDeSelectedColor, Selection.textSelectedColor);
            Img.color = imageColorLerp.Morph(isSelected, Selection.imageDeSelectedColor, Selection.imageSelectedColor);
        }

        public void UpdateControllCount(int num)
        {
            controllCount += num;
            PlaySound(num);
            isSelected = controllCount >= 1 ? true : false;
        }

        private void PlaySound(int num)
        {
            if (num > 0)
            {
                GameManager.Instance.AudioManager.PlaySound(playerType == GameSettings.PlayerType.Assault ? Audio.Sounds.Sound.Assault_Hey : Audio.Sounds.Sound.Engineer_Hey);
            }
        }


        private void OnDestroy()
        {
            txtColorLerp = null;
            imageColorLerp = null;

        }
    }
}
