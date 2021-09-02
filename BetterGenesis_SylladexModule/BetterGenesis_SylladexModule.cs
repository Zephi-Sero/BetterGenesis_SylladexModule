using System;
using System.Collections.Generic;
using TheGenesisProjectModPatcher;
using TheGenesisProjectModPatcher.Mod;
using TheGenesisProjectModPatcher.Inventory;

namespace BetterGenesis_SylladexModule {
    public class BetterGenesis_SylladexModule : TGPMod {
        public override string ModName => "BetterGenesis_SylladexModule";
        public override string ModVersion => "1.0.0";
        public override string ModAuthor => "zephyrouSerotonin";
        public override Pair<string, string>[] Dependencies => new Pair<string, string>[0];

        private List<FetchModus> fetchmodi;
        public override void PatchMod() {
            Queuestack qs = new Queuestack();
            fetchmodi = new List<FetchModus>(new FetchModus[] {
                qs,
            });
            ModPatcher.AddEventListener(new LobbyInitListener(this, qs));
        }
    }
}
