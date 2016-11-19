//App
using RENEGADES.Gameplay.AI.Turrets;

//C#
using System.Collections.Generic;

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Generators
{
    public class TurretGenerator : Spawner
    {
        public TurretType turretData;

        public override void Init()
        {
            
        }

        public void CreateTurret(TurretType.TurretKey key,Vector3 pos)
        {
            int index = turretData.TurretTypes.FindIndex(x => x.key == key);
            Spawn(turretData.TurretTypes[index].turretPrefab, pos);
        }
    }
}
