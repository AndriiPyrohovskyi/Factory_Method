using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    abstract class BuyCrypto
    {
        public abstract void BuyingCrypto(double n_coins, double price);
    }
    class BuyBTC : BuyCrypto
    {
        public override void BuyingCrypto(double n_coins, double price)
        {
            Console.WriteLine($"Buying {n_coins} BTC with price {price} USDT. Limit Order created and costs {n_coins*price} USDT.");
        }
    }
    class BuyETH : BuyCrypto
    {
        public override void BuyingCrypto(double n_coins, double price)
        {
            Console.WriteLine($"Buying {n_coins} ETH with price {price} USDT. Limit Order created and costs {n_coins * price} USDT.");
        }
    }
    class BuyTON : BuyCrypto
    {
        public override void BuyingCrypto(double n_coins, double price)
        {
            Console.WriteLine($"Buying {n_coins} TON with price {price} USDT. Limit Order created and costs {n_coins * price} USDT.");
        }
    }
    abstract class BuyCryptoFactory
    {
        public abstract BuyCrypto BuyCryptocurrency();
    }
    class BuyBTC_Factory : BuyCryptoFactory
    {
        public override BuyCrypto BuyCryptocurrency()
        {
            return new BuyBTC();
        }
    }
    class BuyETH_Factory : BuyCryptoFactory
    {
        public override BuyCrypto BuyCryptocurrency()
        {
            return new BuyETH();
        }
    }
    class BuyTON_Factory : BuyCryptoFactory
    {
        public override BuyCrypto BuyCryptocurrency()
        {
            return new BuyTON();
        }
    }
    class BuyingCrypto
    {
        private BuyCrypto _crypto;

        public BuyingCrypto(BuyCryptoFactory factory)
        {
            _crypto = factory.BuyCryptocurrency();
        }

        public void Buy (double n_coins, double price)
        {
            _crypto.BuyingCrypto(n_coins, price);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BuyCryptoFactory BTCfactory = new BuyBTC_Factory();
            BuyingCrypto BTC = new BuyingCrypto(BTCfactory);
            BTC.Buy(0.13, 66231.2);

            BuyCryptoFactory ETHfactory = new BuyETH_Factory();
            BuyingCrypto ETH = new BuyingCrypto(ETHfactory);
            ETH.Buy(5, 2924.31);

            BuyCryptoFactory TONfactory = new BuyTON_Factory();
            BuyingCrypto TON = new BuyingCrypto(TONfactory);
            TON.Buy(100, 5.9);
        }
    }
}
