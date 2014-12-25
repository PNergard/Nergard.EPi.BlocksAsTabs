using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.WebControls;
using System.Collections;
using System.Collections.Generic;
using EPiServer.SpecializedProperties;
using EPiServer.ServiceLocation;
using BlocksAsTabs.Models.Blocks;

namespace BlocksAsTabs.Views.Blocks
{
    public partial class TabsBlockControl : BlockControlBase<TabsBlock>
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            TabbarnaContent.ItemDataBound += TabbarnaContent_ItemDataBound;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (CurrentBlock.TabBlocks == null)
                return;

            IEnumerable<ContentAreaItem> _tabsToBe = CurrentBlock.TabBlocks.Items;

            Tabbarna.DataSource = _tabsToBe;
            Tabbarna.DataBind();

            TabbarnaContent.DataSource = _tabsToBe;
            TabbarnaContent.DataBind();
        }

        protected void TabbarnaContent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ContentAreaItem item = ((ContentAreaItem)e.Item.DataItem);

                var contentArea = new ContentArea();
                contentArea.Items.Add(item);

                var previewProperty = new PropertyContentArea { Value = contentArea, Name = "PreviewPropertyData" };

                ((Property)e.Item.FindControl("BlockPropertyControl")).InnerProperty = previewProperty;
            }
        }

        public string TabName(ContentAreaItem content)
        {
            var repository = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<IContentRepository>();
            IContent block = repository.Get<IContent>(content.ContentLink);

            string value = string.Empty;
            //string value = ((ContentData)block).Property["HeadingInTabBlock"].ToString();

            if (!string.IsNullOrEmpty(value))
                return value;
            else
                return block.Name;
        }
    }
}