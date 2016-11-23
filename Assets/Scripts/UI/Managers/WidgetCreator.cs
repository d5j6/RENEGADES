//App
using RENEGADES.Common.UI;
using RENEGADES.Gameplay.Generators;

//Unity
using UnityEngine;

//C#
using System.Collections.Generic;

namespace RENEGADES.UI.Managers
{

    public class WidgetCreator : Spawner
    {
        public enum WidgetToSpawn
        {
            PlayerModule,
            RoundText
        }

        [System.Serializable]
        public struct Widget
        {
            public string name;
            public WidgetToSpawn type;
            public UIWidget widget;
        }

        [Header("All Spawnable UI Widgets")]
        public List<Widget> WIDGETS;


        public override void Init(){ }

        public UIWidget CreateWidget(WidgetToSpawn type)
        {
            int index = WIDGETS.FindIndex(x => x.type == type);
            return SpawnUI(WIDGETS[index].widget);
        }

    }
}
