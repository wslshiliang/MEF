using DAL;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace WYQ.MEF
{
    public class CardsMEF : BaseIEnumberableMEF<ICard>
    { 
        public static string GetData()
        {
            string str = string.Empty;
            CardsMEF pro = new CardsMEF();
            pro.Compose();
            if (pro.cards != null)
            {
                foreach (var c in pro.cards)
                {
                    str += c.GetCountInfo();
                }
            }
            return str;
        }

    }
}
