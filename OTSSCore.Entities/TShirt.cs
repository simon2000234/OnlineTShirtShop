using System;

namespace OTSSCore.Entities
{
    public class TShirt
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public bool IsMan { get; set; }
        public string ImgLink { get; set; }
    }
}
