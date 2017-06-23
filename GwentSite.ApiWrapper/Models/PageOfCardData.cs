using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentSite.ApiWrapper.Models
{
    public class PageOfCardData : IPageOfCardData
    {
        List<ICardData> _cardList = new List<ICardData>();

        public PageOfCardData(string jsonCards)
        {
            _cardList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ICardData>>(jsonCards);
        }
        public IEnumerator<ICardData> GetEnumerator()
        {
            return new PageEnum(_cardList);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<CardData>) GetEnumerator();
        }
    }
    public class PageEnum : IEnumerator<ICardData>
    {
        List<ICardData> _cards;
        int _position = -1;

        public PageEnum(List<ICardData> cards)
        {
            _cards = cards;
        }
        public ICardData Current
        {
            get
            {
                try
                {
                    return _cards[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public bool MoveNext()
        {
            _position++;
            return (_position < _cards.Count);
        }
        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
