using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Buffs.Masomode
{
    public class Purged : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Purged");
            Description.SetDefault("Dodge effects don't work");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<FargoSoulsPlayer>().noDodge = true;
        }
    }
}