using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGenesisProjectModPatcher;
using TheGenesisProjectModPatcher.Inventory;
using UnityEngine;

namespace BetterGenesis_SylladexModule {
    public class Queuestack : FetchModus {
        private List<Modus.Card> itemList = new List<Modus.Card>();
        public void Queuestack_Init() {
            SetDescription("Allows you to access either the first or last item put into the sylladex");
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(File.ReadAllBytes(BetterGenesis_SylladexModule.ModAssets + "/queuestack.png"));
            Sprite spr = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            SetSprite(spr);
        }
        private new void Awake() {
            base.Awake();
            this.itemCapacity = 8;
            this.separation = new Vector2(-this.complexcardsize.x / 4f, this.complexcardsize.y / 4f);
            base.SetIcon("Queuestack");
            base.SetColor(new Color(255f, 128f, 0f));
        }
        protected override bool AddItemToModus(Item toAdd) {
            if(this.itemList.Count >= this.itemCapacity) return false;
            itemList.Add(MakeCard(toAdd, 0, -1));
            return true;
        }

        protected override bool IsRetrievable(Card item) {
            if(this.itemList.Count == 0) return false;
            return item == this.itemList.First() || item == this.itemList.Last();
        }

        protected override bool RemoveItemFromModus(Card item) {
            if(IsRetrievable(item)) {
                this.itemList.Remove(item);
                return true;
            }
            return false;
        }

        protected override IEnumerable<Card> GetItemList() {
            return this.itemList;
        }

        protected override void Load(Item[] items) {
            this.itemList = new List<Modus.Card>();
            for(int i = 0; i < items.Length;i++) {
                this.itemList.Add(MakeCard(items[i], i));
            }
        }

        public override int GetAmount() {
            return this.itemList.Count;
        }
    }
}
