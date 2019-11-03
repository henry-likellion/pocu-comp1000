using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    public class Frame
    {
        public EFeatures Features { get; private set; }
        public uint ID { get; private set; }
        public string Name { get; private set; }

        public Frame (uint id, string name)
        {
            ID = id;
            Name = name;
            Features = EFeatures.Default;
        }

        public void ToggleFeatures (EFeatures features)
        {
            Features ^= features;
        } 

        public void TurnOnFeatures (EFeatures features)
        {
            Features |= features;
        }

        public void TurnOffFeatures (EFeatures features)
        {
            Features &= ~features;
        }
    }
}
