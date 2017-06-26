using GwentSite.ApiWrapper.Models;
using GwentSite.ApiWrapper.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentSite.ApiWrapper
{
    public interface IClient
    {
        Task<IPageOfCardData> GetPageOfCards(GetPageOfCardsRequest request);
        Task<ICardData> GetCardData(GetCardDataRequest request);
        Task<IVariationDetail> GetVariationDetail(GetVariationDetailRequest request);
        Task<IArtwork> GetArtwork(GetArtworkRequest request);
        Task<List<IArtwork>> GetArtworkList(GetArtworkListRequest request);
    }
}