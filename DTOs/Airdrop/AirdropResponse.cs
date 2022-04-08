namespace octa_dotnet.DTOs.Airdrop
{
    public class AirdropResponse
    {

        public int? AirdropId { get; set; }
        public string? Account { get; set; }
        public int? BoxId { get; set; }
        public int? BoxType { get; set; }
        public int? Boxquota { get; set; }
        public string? Img { get; set; }


        public static AirdropResponse FromAirdrop(octa_dotnet.Entities.Airdrop airdrop)
        {
            return new AirdropResponse
            {
                AirdropId = airdrop.AirdropId,
                Account = airdrop.Account,
                BoxId = airdrop.BoxId,
                BoxType = airdrop.BoxType,
                Boxquota = airdrop.Boxquota,
                 Img = airdrop.Img,
               
           };


    }
}
    }
