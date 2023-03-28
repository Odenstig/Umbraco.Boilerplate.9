using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.Blocks;

namespace Boilerplate.Core.Models.UtilityModels
{
    public class TwoColBlockListItem
    {
        public BlockListItem Block { get; set; }
        public TwoColBlockPosition Position { get; set; }
        public int Index { get; set; }
    }

    public enum TwoColBlockPosition
    {
        Left,
        Right
    }
}
