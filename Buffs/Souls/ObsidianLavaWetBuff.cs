﻿using Terraria;
using Terraria.ModLoader;

namespace FargowiltasSouls.Buffs.Souls
{
    public class ObsidianLavaWetBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lava Wet");
            Description.SetDefault("You are dripping lava");
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<FargoSoulsPlayer>().LavaWet = true;
        }
    }
}