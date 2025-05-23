//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v9.1.0+b0a4a92f578580e6045a0cf58a4ba5ff65fc4187
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Infrastructure.ModelsBuilder;
using Umbraco.Cms.Core;
using Umbraco.Extensions;

namespace Boilerplate.Core.Models.GeneratedModels
{
	/// <summary>Image</summary>
	[PublishedModel("imageBlock")]
	public partial class ImageBlock : PublishedElementModel, IBlockNameDocType
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.1.0+b0a4a92f578580e6045a0cf58a4ba5ff65fc4187")]
		public new const string ModelTypeAlias = "imageBlock";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.1.0+b0a4a92f578580e6045a0cf58a4ba5ff65fc4187")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.1.0+b0a4a92f578580e6045a0cf58a4ba5ff65fc4187")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public new static IPublishedContentType GetModelContentType(IPublishedSnapshotAccessor publishedSnapshotAccessor)
			=> PublishedModelUtility.GetModelContentType(publishedSnapshotAccessor, ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.1.0+b0a4a92f578580e6045a0cf58a4ba5ff65fc4187")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(IPublishedSnapshotAccessor publishedSnapshotAccessor, Expression<Func<ImageBlock, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(publishedSnapshotAccessor), selector);
#pragma warning restore 0109

		private IPublishedValueFallback _publishedValueFallback;

		// ctor
		public ImageBlock(IPublishedElement content, IPublishedValueFallback publishedValueFallback)
			: base(content, publishedValueFallback)
		{
			_publishedValueFallback = publishedValueFallback;
		}

		// properties

		///<summary>
		/// Image
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.1.0+b0a4a92f578580e6045a0cf58a4ba5ff65fc4187")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("imageBlock_image")]
		public virtual global::Umbraco.Cms.Core.Models.MediaWithCrops ImageBlock_image => this.Value<global::Umbraco.Cms.Core.Models.MediaWithCrops>(_publishedValueFallback, "imageBlock_image");

		///<summary>
		/// Name: This is only used in Umbraco. Use a short descriptive name of what the block contains.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.1.0+b0a4a92f578580e6045a0cf58a4ba5ff65fc4187")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("blockName")]
		public virtual string BlockName => global::Boilerplate.Core.Models.GeneratedModels.BlockNameDocType.GetBlockName(this, _publishedValueFallback);
	}
}
