namespace GwentSite.ApiWrapper.Models
{
    public interface IVariation
    {
        string Availability { get; set; }
        string Href { get; set; }
        BasicInfo Rarity { get; set; }
    }
}