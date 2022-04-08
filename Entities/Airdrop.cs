using System;
using System.Collections.Generic;

namespace octa_dotnet.Entities
{
    public partial class Airdrop
    {
        public int AirdropId { get; set; }
        public string? Account { get; set; }
        public int? BoxId { get; set; }
        public int? BoxType { get; set; }
        public int? Boxquota { get; set; }
        public string? Status { get; set; }
        public string? Img { get; set; }
        public byte[]? Date { get; set; }
    }
}
