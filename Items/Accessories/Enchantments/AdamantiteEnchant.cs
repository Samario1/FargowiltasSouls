using FargowiltasSouls.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace FargowiltasSouls.Items.Accessories.Enchantments
{
    public class AdamantiteEnchant : BaseEnchant
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            DisplayName.SetDefault("Adamantite Enchantment");
            Tooltip.SetDefault("Every weapon shot will split into 2" +
                "\nAll weapon shots deal 50% damage" +
                "\nThey hit twice as fast and gain armor penetration equal to 50% damage" +
                "\n'Chaos'");

            // DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "精金魔石");
            // Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "每秒会随机使你的一个弹幕分裂成三个" +
            //     "\n'一气化三清！'");
        }

        protected override Color nameColor => new Color(221, 85, 125);

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.rare = ItemRarityID.Lime;
            Item.value = 100000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            AdamantiteEffect(player, Item);
        }

        public static void AdamantiteEffect(Player player, Item item)
        {
            FargoSoulsPlayer modplayer = player.GetModPlayer<FargoSoulsPlayer>();
            modplayer.AdamantiteEnchantItem = item;
        }

        public static void AdamantiteSplit(Projectile projectile)
        {
            foreach (Projectile p in FargoSoulsGlobalProjectile.SplitProj(projectile, 3, MathHelper.ToRadians(8), 1f))
            {
                if (p != null && p.active)
                {
                    p.GetGlobalProjectile<FargoSoulsGlobalProjectile>().HuntressProj = projectile.GetGlobalProjectile<FargoSoulsGlobalProjectile>().HuntressProj;
                }
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("FargowiltasSouls:AnyAdamHead")
                .AddIngredient(ItemID.AdamantiteBreastplate)
                .AddIngredient(ItemID.AdamantiteLeggings)
                .AddIngredient(ItemID.Boomstick)
                .AddIngredient(ItemID.QuadBarrelShotgun)
                .AddIngredient(ItemID.DarkLance)
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }
}
