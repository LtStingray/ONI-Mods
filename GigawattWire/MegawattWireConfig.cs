﻿using UnityEngine;

namespace GigawattWire
{
    public class MegawattWireConfig : BaseWireConfig
    {
        public const string ID = "MegawattWire";

        public override BuildingDef CreateBuildingDef()
        {
            BuildingDef buildingDef = this.CreateBuildingDef(ID, "megawatt_wire_kanim", 3f, ExtendedWire.MEGAWATT_WIRE_MASS_KG, 0.05f, noise: TUNING.NOISE_POLLUTION.NONE, decor: TUNING.BUILDINGS.DECOR.PENALTY.TIER3);
            buildingDef.MaterialCategory = ExtendedWire.MEGAWATT_WIRE_MATERIALS;
            buildingDef.BuildLocationRule = BuildLocationRule.NotInTiles;
            return buildingDef;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            DoPostConfigureComplete(ExtendedWire.WattageRating.Max1MW.ToWireWattageRating(), go);
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            base.DoPostConfigureUnderConstruction(go);
            Constructable component = go.GetComponent<Constructable>();
            component.requiredSkillPerk = Db.Get().SkillPerks.CanPowerTinker.Id;
        }
    }
}
