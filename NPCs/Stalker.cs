using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using SpookyTerraria.Utilities;

namespace SpookyTerraria.NPCs
{
    // TODO: Multiple stalker spawns
    // TODO: Heartrate fix when near stalker
    public class Stalker : ModNPC
    {
        /// <summary>
        /// Is there 1 stalker alive?
        /// </summary>
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("");
            Main.npcFrameCount[npc.type] = 1;
        }
        public override void SetDefaults()
        {
            npc.width = 42;
            npc.height = 110;
            npc.damage = 1;
            npc.defense = 6;
            npc.lifeMax = 50;
            npc.dontTakeDamage = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            Main.npcFrameCount[npc.type] = 2;
            npc.alpha = 220;
        }
        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
            damage = target.statLifeMax2 + 50;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (target.statLife <= 0)
            {
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Action/Jumpscare"), target.Center);
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.worldName != SpookyTerrariaUtils.slenderWorldName && !Main.player[Main.myPlayer].GetModPlayer<SpookyPlayer>().stalkerConditionMet && !ModContent.GetInstance<SpookyTerraria>().beatGame && Main.player[Main.myPlayer].townNPCs < 4 ? .25f : 0f;
        }
        public override void PostAI()
        {
        }
        public override void AI()
        {
            Player player = Main.player[Main.myPlayer];
            if (player.dead)
            {
                npc.active = false;
            }
        }
        public override bool CheckActive()
        {
            // Main.player[Main.myPlayer].GetModPlayer<SpookyPlayer>().stalkerConditionMet = true;
            return true;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
        }
        public override void NPCLoot()
		{
		}
	}
}