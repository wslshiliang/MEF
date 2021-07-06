using System;
using DAL;

namespace BLL
{
    [System.ComponentModel.Composition.Export(typeof(ICard))]
    public class ZHCard : ICard
    {
        public string GetCountInfo()
        {
            return "Bank Of China";
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
