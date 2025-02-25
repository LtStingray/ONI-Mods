﻿using UnityEngine;

namespace GigawattWire
{
    public class GigawattWireBridgeConfig : WireBridgeHighWattageConfig
    {
        public new const string ID = "GigawattWireBridge";

        protected override string GetID() => ID;

        public override BuildingDef CreateBuildingDef()
        {
            BuildingDef buildingDef = base.CreateBuildingDef();
            buildingDef.AnimFiles = new KAnimFile[1] { Assets.GetAnim("gigawatt_wire_bridge_kanim") };
            buildingDef.Mass = ExtendedWire.GIGAWATT_WIRE_MASS_KG;
            buildingDef.MaterialCategory = ExtendedWire.GIGAWATT_WIRE_MATERIALS;
            buildingDef.Overheatable = true;
            buildingDef.OverheatTemperature = 3.15f;
            buildingDef.SceneLayer = Grid.SceneLayer.WireBridges;
            buildingDef.ForegroundLayer = Grid.SceneLayer.TileMain;
            GeneratedBuildings.RegisterWithOverlay(OverlayScreen.WireIDs, ID);
            return buildingDef;
        }

        protected override WireUtilityNetworkLink AddNetworkLink(GameObject go)
        {
            WireUtilityNetworkLink wireUtilityNetworkLink = base.AddNetworkLink(go);
            wireUtilityNetworkLink.maxWattageRating = ExtendedWire.WattageRating.Max1GW.ToWireWattageRating();
            return wireUtilityNetworkLink;
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            base.DoPostConfigureUnderConstruction(go);
            Constructable component = go.GetComponent<Constructable>();
            component.requiredSkillPerk = Db.Get().SkillPerks.CanPowerTinker.Id;
        }
    }

}
