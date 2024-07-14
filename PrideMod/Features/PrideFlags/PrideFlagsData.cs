using System;
using System.Collections.Generic;

namespace PrideMod.Features.PrideFlags
{
    [Serializable]
    public class PrideFlagsData
    {
        public List<PrideFlagData> Flags { get; set; } = new List<PrideFlagData>();
    }
}