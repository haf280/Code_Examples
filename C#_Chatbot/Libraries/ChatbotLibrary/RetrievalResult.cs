using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotLibrary
{
    public class RetrievalResult
    {
        private List<RetrievalResultItem> itemList;

        public RetrievalResult()
        {
            itemList = new List<RetrievalResultItem>();
        }

        public List<RetrievalResultItem> ItemList
        {
            get { return itemList; }
            set { itemList = value; }
        }
    }
}
