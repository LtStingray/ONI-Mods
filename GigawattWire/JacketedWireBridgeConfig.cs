﻿using UnityEngine;

namespace GigawattWire
{
    public class JacketedWireBridgeConfig : WireBridgeConfig
    {
        public new const string ID = "JacketedWireBridge";

        protected override string GetID() => ID;
        
        public override BuildingDef CreateBuildingDef()
        {
            BuildingDef buildingDef = base.CreateBuildingDef();
            buildingDef.AnimFiles = new KAnimFile[1] { Assets.GetAnim("jacketed_wire_bridge_kanim") };
            buildingDef.Mass = ExtendedWire.JACKETED_WIRE_MASS_KG;
            buildingDef.MaterialCategory = ExtendedWire.MEGAWATT_WIRE_MATERIALS;
            GeneratedBuildings.RegisterWithOverlay(OverlayScreen.WireIDs, ID);
            return buildingDef;
        }

        protected override WireUtilityNetworkLink AddNetworkLink(GameObject go)
        {
            WireUtilityNetworkLink wireUtilityNetworkLink = base.AddNetworkLink(go);
            wireUtilityNetworkLink.maxWattageRating = ExtendedWire.WattageRating.Max5kW.ToWireWattageRating();
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
