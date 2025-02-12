using Terraria;
using Terraria.ModLoader;

namespace FargowiltasSouls.Buffs.Masomode
{
    public class NanoInjection : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nano Injection");
            Description.SetDefault("Life regeneration and stats reduced");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<FargoSoulsPlayer>().NanoInjection = true;
            player.GetDamage(DamageClass.Generic) -= 0.1f;
            player.moveSpeed -= 0.1f;
            player.statDefense -= 10;
        }
    }
}