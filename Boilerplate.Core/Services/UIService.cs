using Boilerplate.Core.Models.GeneratedModels;
using Boilerplate.Core.Models.UtilityModels;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.Blocks;

namespace Boilerplate.Core.Services
{
    public static class UIService
    {
        public static string ClassesIf(params ConditionalCssClass[] conditionalCssClasses)
        {
            return string.Join(" ", conditionalCssClasses.Select(c => c.Condition ? c.ClassName : string.Empty)).TrimEnd();
        }

        public static string ConditionalClass(bool condition, string trueClass, string falseClass)
        {
            return condition ? trueClass : falseClass;
        }

        public static string BlockWidthClasses(this IBlockGeneralSettings b)
        {
            if (b != null)
            {
                return b.BlockWidth switch
                {
                    "Standard" => "max-width-md",
                    "Extra small" => "max-width-xs",
                    "Small" => "max-width-sm",
                    "Big" => "max-width-lg",
                    "Full size" => "width-100%",
                    _ => "max-width-md",
                };
            }
            return string.Empty;
        }

        public static string BlockWidthClasses(this IBlockSimpleSettings b)
        {
            if (b != null)
            {
                return b.BlockWidth switch
                {
                    "Standard" => "max-width-md",
                    "Extra small" => "max-width-xs",
                    "Small" => "max-width-sm",
                    "Big" => "max-width-lg",
                    "Full size" => "width-100%",
                    _ => "max-width-md",
                };
            }
            return string.Empty;
        }

        public static string BlockPaddingClasses(this IBlockGeneralSettings b)
        {
            if (b != null)
            {
                var paddingTop = GetPaddingClass(b.BlockPaddingTop, true);
                var paddingBottom = GetPaddingClass(b.BlockPaddingBottom, false);
                return string.Format("{0} {1}", paddingTop, paddingBottom);
            }
            return string.Empty;
        }

        public static string BlockPaddingClasses(this IBlockSimpleSettings b)
        {
            if (b != null)
            {
                var paddingTop = GetPaddingClass(b.BlockPaddingTop, true);
                var paddingBottom = GetPaddingClass(b.BlockPaddingBottom, false);
                return string.Format("{0} {1}", paddingTop, paddingBottom);
            }
            return string.Empty;
        }

        public static string TwoColGap(this string size)
        {
            return size switch
            {
                "Extra large" => "gap-md gap-xl@md",
                "Large" => "gap-md gap-xl@md",
                "Medium" => "gap-md gap-md@md",
                "Small" => "gap-md gap-sm@md",
                "Extra small" => "gap-md gap-xs@md",
                "None" => "gap-md gap-0@md",
                _ => "gap-md",
            };
        }

        public static string BlockTextColor(string hexColor)
        {
            if (string.IsNullOrEmpty(hexColor))
            {
                hexColor = "000000";
            }

            return $"color: #{hexColor}";
        }

        public static (int leftColWidth, int rightColWidth) CalculateColumnDistribution(decimal distributionValue)
        {
            if (distributionValue == 0)
            {
                distributionValue = 6;
            }

            var leftColWidth = (int)distributionValue;
            var rightColWidth = 12 - leftColWidth;
            return (leftColWidth, rightColWidth);
        }

        public static List<IGrouping<int, TwoColBlockListItem>> GetTwoBlockContentRows(BlockListModel leftCol, BlockListModel rightCol)
        {
            var blocks = new List<TwoColBlockListItem>();

            for (int i = 0; i < leftCol.Count; i++)
            {
                blocks.Add(new TwoColBlockListItem { Block = leftCol[i], Index = i, Position = TwoColBlockPosition.Left });
            }

            for (int i = 0; i < rightCol.Count; i++)
            {
                blocks.Add(new TwoColBlockListItem { Block = rightCol[i], Index = i, Position = TwoColBlockPosition.Right });
            }

            return blocks.GroupBy(b => b.Index).ToList();
        }

        private static string GetPaddingClass(string paddingSetting, bool isTop = false)
        {
            var side = isTop ? "top" : "bottom";
            var mobileDefaultPadding = $"padding-{side}-md";

            return paddingSetting switch
            {
                "Extra large" => $"{mobileDefaultPadding} padding-{side}-xl@md",
                "Large" => $"{mobileDefaultPadding} padding-{side}-lg@md",
                "Medium" => $"{mobileDefaultPadding} padding-{side}-md@md",
                "Small" => $"{mobileDefaultPadding} padding-{side}-sm@md",
                "Extra small" => $"{mobileDefaultPadding} padding-{side}-xs@md",
                "None" => $"{mobileDefaultPadding} padding-{side}-0@md",
                _ => $"{mobileDefaultPadding} padding-{side}-lg@md",
            };
        }
    }
}
