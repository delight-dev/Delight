#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ListExample
    {
        protected override void BeforeLoad()
        {
            base.BeforeLoad();

            System.Random random = new System.Random();

            var playerList = new BindableCollection<Player>();
            for (int i = 0; i < 50; ++i)
            {
                playerList.Add(new Player { Name = "Item " + i, Color = new Color(random.Next(0, 255) / 255f, random.Next(0, 255) / 255f, random.Next(0, 255) / 255f) });
            }
            Players = playerList;

            //PlayerList.TemplateSelector = x => MyTemplateSelector(x);
        }

        public void SelectItem()
        {
            int.TryParse(ItemIndex, out var index);
            Debug.Log("Scrolling to: " + index);
            Players.SelectAndScrollTo(index, ElementAlignment.Center);
            //PlayerList.ScrollTo(index, ElementAlignment.Center);
        }

        public void ScrollTo()
        {
            int.TryParse(ItemIndex, out var index);
            Debug.Log("Scrolling to: " + index);
            Players.ScrollTo(index, ElementAlignment.Center);
        }

        public void ScrollToSelected()
        {
            int.TryParse(ItemIndex, out var index);
            //Debug.Log("Scrolling to: " + index);
            //Players.ScrollTo(index, ElementAlignment.Center);

            Debug.Log("Scrolling to: " + SelectedPlayer?.Name);
            Players.ScrollTo(SelectedPlayer, ElementAlignment.Center);
        }

        public string MyTemplateSelector(Player player)
        {
            if (player.Name == "Item 1" || player.Name == "Item 5" || player.Name == "Item 23")
                return "TemplateB";

            return "TemplateA";
        }
    }
}
