using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FargowiltasSouls.Items.Accessories.Enchantments
{
    public class SpookyEnchant : SoulsItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spooky Enchantment");
            Tooltip.SetDefault(
@"All of your minions gain an extra scythe attack
'Melting souls since 1902'");
            DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "阴森魔石");
            Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, 
@"你的召唤物获得了额外的镰刀攻击
'自1902年以来融化的灵魂'");
        }

        public override void SafeModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(100, 78, 116);
                }
            }
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = ItemRarityID.Yellow;
            Item.value = 250000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<FargoSoulsPlayer>().SpookyEffect(hideVisual);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.SpookyHelmet)
            .AddIngredient(ItemID.SpookyBreastplate)
            .AddIngredient(ItemID.SpookyLeggings)
            .AddIngredient(ItemID.ButchersChainsaw)
            .AddIngredient(ItemID.DeathSickle)
            .AddIngredient(ItemID.RavenStaff)

            //psycho knife
            //eoc yoyo
            //dark harvest
            //.AddIngredient(ItemID.CursedSapling);
            //.AddIngredient(ItemID.EyeSpring);

            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}
