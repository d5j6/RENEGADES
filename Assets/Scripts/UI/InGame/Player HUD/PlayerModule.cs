//Game
using GameEngineering.UI.Common;
using RENEGADES.Managers;
using RENEGADES.Common.UI;

//Unity
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RENEGADES.UI.Gameplay
{

    public class PlayerModule : UIWidget
    {
        private HealthSlider healthSlider;
        private HealthSlider _HealthSlider
        {
            get { return healthSlider ?? (healthSlider = GetComponentInChildren<HealthSlider>()); }
        }

        private CrystalText crystalText;
        private CrystalText _CrystalText
        {
            get { return crystalText ?? (crystalText = GetComponentInChildren<CrystalText>()); }
        }

        [Header("Player Textures")]
        public Sprite AssaultTexture;
        public Sprite EngineerTexture;

        [Header("Simple UI Elements")]
        public TextMeshProUGUI playerNameText;
        public Image playerIcon;

        public override void Init()
        {
            base.Init();
        }

        public void SetContent(int playerNumber, GameSettings.PlayerType type)
        {
            if (playerNameText != null) playerNameText.text = "Player " + playerNumber.ToString();
            else { Debug.LogError("Player Text Not Assigned in Editor Gameobject"); }
            if (playerIcon != null) playerIcon.sprite = type == GameSettings.PlayerType.Assault ? AssaultTexture : EngineerTexture;
            else { Debug.LogError("Player Icon Not Assigned in Editor Gameobject"); }

            SetPos(playerNumber);
        }


        //Set UI Module on the side of the screen
        private void SetPos(int playerNumber)
        {
            if(playerNumber == 1)
            {
                Rect.SetAnchor(AnchorPresets.BottomLeft);
                Rect.SetPivot(PivotPresets.BottomLeft);
            }
            else if(playerNumber == 2)
            {
                Rect.SetAnchor(AnchorPresets.BottomRight);
                Rect.SetPivot(PivotPresets.BottomRight);
            }
        }

        public void SetMaxHealth(float h)
        {
            _HealthSlider.SetMaxValue(h);
        }

        public void UpdateHealth(float h)
        {
            _HealthSlider.UpdateHealth(h);
        }

        public void UpdateCrystal(float c)
        {
            _CrystalText.SetText(c.ToString());
        }
    }
}
