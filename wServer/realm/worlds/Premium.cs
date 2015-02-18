﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace wServer.realm.worlds
{
    public class PremiumShop : World
    {
        public PremiumShop()
        {
            Name = "Premium Shop";
            Background = 0;
            AllowTeleport = true;
            base.FromWorldMap(typeof(RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.premium.wmap"));            
        }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new Island());
        }
    }
}
