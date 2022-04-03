using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Contagion.Content.Items.Armor
{
    public class FerrymanVisuals : ModPlayer
    {
        public bool ferrymanOn;

        public override void ResetEffects()
        {
            ferrymanOn = false;
        }

        public override void ModifyDrawInfo(ref PlayerDrawSet drawInfo)
        {
        }
    }
}
