using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace BlocksAsTabs.Models.Blocks
{
    [ContentType(DisplayName = "TabsBlock", GUID = "42A0899A-032E-4A80-9FF6-B884EDD8AD4B", Description = "")]
    public class TabsBlock : BlockData
    {
        [CultureSpecific]
        public virtual ContentArea TabBlocks { get; set; }
    }
}
