﻿using UnityEngine;

namespace GigawattWire
{
    public class JacketedWireConfig : BaseWireConfig
    {
        public const string ID = "JacketedWire";
        
        public override BuildingDef CreateBuildingDef()
        {
            BuildingDef buildingDef = this.CreateBuildingDef(ID, "jacketed_wire_kanim", 3f, ExtendedWire.JACKETED_WIRE_MASS_KG, 0.05f, noise: TUNING.NOISE_POLLUTION.NONE, decor: TUNING.BUILDINGS.DECOR.NONE);
            buildingDef.MaterialCategory = ExtendedWire.MEGAWATT_WIRE_MATERIALS;
            return buildingDef;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            DoPostConfigureComplete(ExtendedWire.WattageRating.Max5kW.ToWireWattageRating(), go);
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            base.DoPostConfigureUnderConstruction(go);
            Constructable component = go.GetComponent<Constructable>();
            component.requiredSkillPerk = Db.Get().SkillPerks.CanPowerTinker.Id;
        }
    }
}
