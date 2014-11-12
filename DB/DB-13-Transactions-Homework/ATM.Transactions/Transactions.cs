namespace ATM.Transactions
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using ATM.Data;

    public class Transactions
    {
        public static void Main()
        {
            SeedData();

            try
            {
                WithdrawMoney(1000, "2222222222", "2222");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fail " + ex);
            }
        }

        public static void SeedData()
        {
            using (var db = new ATMEntities())
            {
                if (db.CardAccounts.FirstOrDefault() == null)
                {
                    return;
                }

                for (int i = 0; i < 25; i++)
                {
                    db.CardAccounts.Add(new CardAccount()
                    {
                        Cash = 10000,
                        Number = new string(i.ToString()[0], 10),
                        Pin = new string(i.ToString()[0], 4)
                    });
                }

                db.SaveChanges();
            }
        }

        public static void WithdrawMoney(decimal amout, string cardNumber, string cardPin)
        {
            DepositMoney(-amout, cardNumber, cardPin);
        }

        public static void DepositMoney(decimal amount, string cardNumber, string cardPin)
        {
            if (cardNumber.Length != 10 || cardPin.Length != 4)
            {
                throw new ArgumentException("Card {0} has invalid length", cardPin.Length == 4 ? "Number" : "Pin");
            }

            using (var db = new ATMEntities())
            {
                using (var tran = db.Database.BeginTransaction(IsolationLevel.RepeatableRead))
                {
                    var card = db.CardAccounts.Where(c => c.Number == cardNumber).FirstOrDefault();

                    if (card == null)
                    {
                        throw new ArgumentException("Card with this number does not exist");
                    }

                    if (card.Pin != cardPin)
                    {
                        throw new ArgumentException("Incorect Pin number");
                    }

                    if (amount < 0 && card.Cash < (-1) * amount)
                    {
                        throw new ArgumentException("Not enough cash");
                    }

                    card.Cash += amount;

                    if (InteractWithMoney(amount))
                    {
                        db.TransactionsHistories.Add(new TransactionsHistory() 
                        {
                            Amount = amount,
                            CardNumber = cardNumber,
                            TransactionDate = DateTime.Now
                        });

                        try
                        {
                            db.SaveChanges();
                            tran.Commit();
                            Console.WriteLine("Success");
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw ex;
                        }
                    }
                    else
                    {
                        tran.Rollback();
                        throw new ArgumentException("Something is wrong with the ATM machine");
                    }
                }
            }
        }

        public static bool InteractWithMoney(decimal amount)
        {
            // some complex magic checks if the money actually leave/enter the ATM machine

            return true;
        }
    }
}
