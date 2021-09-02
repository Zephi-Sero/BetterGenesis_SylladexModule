using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGenesisProjectModPatcher;
using TheGenesisProjectModPatcher.Mod;
using TheGenesisProjectModPatcher.Mod.Event;

namespace BetterGenesis_SylladexModule {
    public class LobbyInitListener : SingleEventListener {
        Queuestack qs;
        public LobbyInitListener(TGPMod mod, Queuestack qs) : base(mod) {
            this.listeningFor = new List<Type>(new Type[] {typeof(LobbyInitEvent)});
            this.qs = qs;
        }
        public override bool OnEvent(IGameEvent evt) {
            qs.Queuestack_Init();
            return true;
        }
    }
}
