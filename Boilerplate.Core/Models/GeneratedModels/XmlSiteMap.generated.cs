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
	/// <summary>Sitemap</summary>
	[PublishedModel("xmlSiteMap")]
	public partial class XmlSiteMap : PublishedContentModel
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.1.0+b0a4a92f578580e6045a0cf58a4ba5ff65fc4187")]
		public new const string ModelTypeAlias = "xmlSiteMap";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.1.0+b0a4a92f578580e6045a0cf58a4ba5ff65fc4187")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.1.0+b0a4a92f578580e6045a0cf58a4ba5ff65fc4187")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public new static IPublishedContentType GetModelContentType(IPublishedSnapshotAccessor publishedSnapshotAccessor)
			=> PublishedModelUtility.GetModelContentType(publishedSnapshotAccessor, ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.1.0+b0a4a92f578580e6045a0cf58a4ba5ff65fc4187")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(IPublishedSnapshotAccessor publishedSnapshotAccessor, Expression<Func<XmlSiteMap, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(publishedSnapshotAccessor), selector);
#pragma warning restore 0109

		private IPublishedValueFallback _publishedValueFallback;

		// ctor
		public XmlSiteMap(IPublishedContent content, IPublishedValueFallback publishedValueFallback)
			: base(content, publishedValueFallback)
		{
			_publishedValueFallback = publishedValueFallback;
		}

		// properties

		///<summary>
		/// Excluded Document Types: A comma delimited list of document type alias to exclude from the XML site map.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.1.0+b0a4a92f578580e6045a0cf58a4ba5ff65fc4187")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("excludedDocumentTypes")]
		public virtual string ExcludedDocumentTypes => this.Value<string>(_publishedValueFallback, "excludedDocumentTypes");

		///<summary>
		/// Max SiteMap Depth: The depth of the Sitemap through the content tree.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.1.0+b0a4a92f578580e6045a0cf58a4ba5ff65fc4187")]
		[ImplementPropertyType("maxSiteMapDepth")]
		public virtual int MaxSiteMapDepth => this.Value<int>(_publishedValueFallback, "maxSiteMapDepth");
	}
}
