using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordInterfaceBlindtest.Models
{
    public class Blindtest
    {
        public List<BlindtestItem> ListItem { get; set; }

        public Blindtest()
        {
            ListItem = new List<BlindtestItem>();
        }
        //public void RemoveItem(int index)
        //{
        //    this.ListItem.RemoveAt(index);
        //}

        // DisplayItem()
        // {
        //     var listElement = "";
        //     this.ListItem.forEach(item => listElement += (item + '\n'));
        //     return listElement;
        // }
    }
}
