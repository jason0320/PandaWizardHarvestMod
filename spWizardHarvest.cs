using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Mod_PandaWizardHarvestMod
{
    internal class spWizardHarvest : Spell
    {
        public override bool Perform()
        {
            Chara cc = EClass.pc;
            if (cc == null) return false;

            Point pos = cc.pos;

            int spellPower = GetPower(cc);

            int maxStacks = Mathf.Min(10, 4 + EClass.rnd((spellPower / 50) + 1));

            int goldPerPile = 400 + EClass.rnd(spellPower);
            int totalGold = Mathf.Min(8000, goldPerPile * maxStacks);
            int goldPerStack = totalGold / maxStacks;

            for (int i = 0; i < maxStacks; i++)
            {
                DropGold(cc, goldPerStack);


                if (EClass.rnd(30) == 0)
                {
                    DropItem(cc, "plat");
                }
                else if (EClass.rnd(80) == 0)
                {
                    DropItem(cc, "medal");
                }
                else if (EClass.rnd(2000) == 0)
                {
                    DropItem(cc, "rod_wish");
                }
            }


            return true;
        }

        private void DropGold(Chara caster, int amount)
        {
            if (amount <= 0) return;
            Thing gold = ThingGen.Create("money");
            gold.SetNum(amount);

            caster.DropThing(gold);

            Msg.Say("dropRewardAir");
        }


        private void DropItem(Chara caster, string itemId)
        {
            Thing item = ThingGen.Create(itemId);

            caster.DropThing(item);

            Msg.Say("dropRewardAir");
        }
    }

}
