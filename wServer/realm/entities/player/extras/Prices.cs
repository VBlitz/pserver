using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wServer.realm.entities.player
{
    public class Prices
    {
        public Dictionary<short, int> prices = new Dictionary<short, int>();

        public List<int> SellSlots = new List<int>();

        public Prices()
        {
            //Note: These are SELL prices, not BUY prices.

            AddPrice(30, "Potion of Defense", "Potion of Attack", "Potion of Mana", "Potion of Dexterity", "Potion of Wisdom", "Potion of Vitality", "Potion of Speed");
            AddPrice(100, "Potion of Mana", "Potion of Life");
            AddPrice(110, "Agateclaw Dagger", "Staff of Astral Knowledge", "Skysplitter Sword", "Eldricht Blades", "Bow of Innocent Blood", "Wand of Ancient Warning", "Robe of the Elder Warlock", "Griffon Hide Armor", "Abyssal Armor");
            AddPrice(95, "Emeraldshard Dagger", "Staff of Diabolic Secrets", "Archon Sword", "Emerald Malevolence Blades", "Bow of Fey Magic", "Wand of Shadow", "Robe of the Moon Wizard", "Hippogriff Hide Armor", "Vengeance Armor");
            AddPrice(65, "Ragetalon Dagger", "Staff of Necrotic Arcana", "Dragonsoul Sword", "Rage Claw Blades", "Verdant Bow", "Wand of Deep Sorcery", "Robe of the Shadow Magus", "Roc Leather Armor", "Desolation Armor");
            AddPrice(50, "Fire Dagger", "Staff of Horror", "Ravenheart Sword", "Infinity Blades", "Golden Bow", "Wand of Death", "Robe of the Master", "Drakehide Armor", "Dragonscale Armor");
            AddPrice(80, "Magic Nova Spell", "Tome of Divine Favor", "Golden Quiver", "Cloak of Endless Twilight", "Golden Helm", "Mithril Shield", "Seal of the Holy Warrior", "Lifedrinker Skull", "Nightwing Venom", "Dragonstalker Trap", "Banishment Orb", "Prism of Phantoms", "Scepter of Skybolts", "Invincibility Jacket", "Ice Star");
            AddPrice(60, "Destruction Sphere Spell", "Tome of Rejuvination", "Magesteel Quiver", "Cloak of the Red Agent", "Steel Helm", "Golden Shield", "Seal of the Devine", "Essence Tap Skull", "Felwasp Poison", "Demonhunter Trap", "Timelock Orb", "Prism of Figments", "Cloudflash Scepter", "Murderous Jacket", "Wind Circle");
            AddPrice(250, "Dagger of Foul Malevolence", "Staff of the Cosmic Whole", "Sword of Acclaim", "Master Blades", "Wand of Recompense", "Bow of Covert Havens", "Robe of the Grand Sorcerer", "Hydra Skin Armor", "Acropolis Armor");
            AddPrice(190, "Elemental Detonation Spell", "Tome of Holy Guidance", "Quiver of Elvish Mastery", "Cloak of Ghostly Concealment", "Helm of the Great General", "Colossus Shield", "Seal of the Blessed Champion", "Bloodsucker Skull", "Baneserpent Poison", "Giantcatcher Trap", "Planefetter Orb", "Prism of Apparitions", "Scepter of Storms", "Jacket of Sorrows", "Doom Circle");
            AddPrice(310, "Dagger of Sinister Deeds", "Staff of the Vital Unity", "Sword of Splendor", "Wand of Evocation", "Bow of Mystical Energy", "Robe of the Star Mother", "Wyrmhide Armor", "Dominion Armor");
            AddPrice(245, "Souleater Skull", "Mobstopper Trap", "Cloak of Dimensions", "Bloodorc Quiver", "Space Deterioration Spell", "Helm of the Holy Warrior", "Tome of the Fountains", "Magma Shield", "1940s Orb", "Toothpaste Poison", "Seal of Mass Power", "Prism of the Soul Stealer", "Scepter of the Grand Sorcerer", "Skyfall Jacket");
            AddPrice(400, "Dagger of Dire Hatred", "Staff of the Fundamental Core", "Sword of Majesty", "Wand of Retribution", "Bow of Deep Enchantment", "Robe of the Ancient Intellect", "Leviathan Armor", "Annihilation Armor");
            AddPrice(320, "Skull of the Undead King", "Azure Trap", "Cloak of the Phantom", "Quiver of Artemis", "Spell of the Eternal Void", "Helm of the Leviathan General", "Tome of the Ancients", "Shield of Death", "Fury Orb", "Bile Poison", "Seal of War", "Prism of the Bloody Surprise", "Scepter of Vorv", "Jacket of Bloodrut Nature");
            AddPrice(250, "Potion of Oryx");
            AddPrice(350, "Wine Cellar Incantation");
            AddPrice(500, "Crystal Sword", "Crystal Wand", "Crystal Dagger", "Forge Amulet", "Ring of the Pyramid", "Ring of the Nile", "Ring of the Sphinx", "Spectral Cloth Armor", "Captain's Ring");
            AddPrice(325, "Staff of Extreme Prejudice", "Wand of the Bulwark", "Anatis Staff", "Orb of the Chaos Walker", "Prism of Inception", "Tome of Holy Protection", "Tome of Noble Assault", "Scepter of Thunderclash");
            AddPrice(310, "Spirit Dagger", "Ghostly Prism");
            AddPrice(450, "Doom Bow", "Demon Blade", "Platinum Sword", "Platinum Wand", "Miasma Poison", "Shield of Ogmur", "Coral Bow");
            AddPrice(800, "Chicken Leg of Doom");
            AddPrice(400, "Thousand Shot", "Cloak of the Planewalker");
            AddPrice(2750, "Sword of Dark Enchantment");
            AddPrice(1750, "Sword of Dark Enchantment");
        }

        public bool HasPrices(Player p)
        {
            bool ret = false;
            List<int> removeSlots = new List<int>();
            foreach (var i in SellSlots)
                if (p.Inventory[i] != null && prices.ContainsKey(p.Inventory[i].ObjectType))
                    ret = true;
                else
                    removeSlots.Add(i);
            foreach (var i in removeSlots)
                SellSlots.Remove(i);
            return ret;
        }

        public int GetPrices(Player p)
        {
            int price = 0;
            foreach (var i in SellSlots)
                if (p.Inventory[i] != null && prices.ContainsKey(p.Inventory[i].ObjectType))
                    price += prices[p.Inventory[i].ObjectType];
            return price;
        }

        public void AddPrice(int price, params string[] items)
        {
            foreach (var i in items)
                try { prices.Add(XmlDatas.IdToType[i], price); }
                catch { Console.Out.WriteLine("Can't find item: " + i); }
        }
    }
}
