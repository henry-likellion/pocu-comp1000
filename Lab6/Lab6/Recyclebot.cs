using System;
using System.Collections.Generic;
namespace Lab6
{
    public class Recyclebot
    {
        readonly List<Item> MrecycleItems = new List<Item>();
        readonly List<Item> MnonRecycleItems = new List<Item>();

        public List<Item> RecycleItems
        {
            get { return MrecycleItems; }
        }

        public List<Item> NonRecycleItems
        {
            get { return MnonRecycleItems; }
        }

        public void Add(Item item)
        {
            if (item.Type == EType.Paper || item.Type == EType.Furniture || item.Type == EType.Electronics)
            {
                if (item.Weight < 5 && item.Weight >= 2)
                {
                    RecycleItems.Add(item);
                }
                else
                {
                    NonRecycleItems.Add(item);
                }
            }
            else
            {
                RecycleItems.Add(item);
            }
        }

        public List<Item> Dump()
        {
            List<Item> dumpItems = new List<Item>();
            foreach (var item in NonRecycleItems)
            {
                if (!item.Volume.Equals(10) && !item.Volume.Equals(11) && !item.Volume.Equals(15))
                {
                    if (item.IsToxicWaste == false)
                    {
                        if (item.Type != EType.Electronics && item.Type != EType.Furniture)
                        {
                            dumpItems.Add(item);
                        }
                    }
                    else
                    {
                        dumpItems.Add(item);
                    }

                }
                else
                {
                    dumpItems.Add(item);
                }
            }

            return dumpItems;
        }
    }
}
