using DAL;
using System.ComponentModel.Composition;

namespace BLL
{
    [Export(typeof(ICard))]
    public class NHCard : ICard
    {
        public string GetCountInfo()
        {
            return "Nong Ye Yin Hang";
        }

        public void SaveMoney(double money)
        {
            this.Money += money;
        }

        public void CheckOutMoney(double money)
        {
            this.Money -= money;
        }

        public double Money { get; set; }
    }
}
