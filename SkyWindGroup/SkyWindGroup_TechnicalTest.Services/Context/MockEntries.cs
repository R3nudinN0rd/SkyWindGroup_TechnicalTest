
using SkyWindGroup_TechnicalTest.Entities;

namespace SkyWindGroup_TechnicalTest.Context
{
    public static class MockEntries
    {
        public static List<User> GetUserMockData()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = 1,
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    IdentificationNumber = "1234567890123",
                    Email = "Email1",
                    Password = "2ac9cb7dc02b3c0083eb70898e549b63",
                    PhoneNumber = "1234567890",
                    CreatedDate = DateTime.Now,
                    BirthDate = new DateTime(day: 1, month:1,year:1999),
                    Address = "Address1",
                    City = "City1",
                    Country = "Country1",
                    EmailVerified = false,
                    BannedAccount = false
                },
                new User()
                {
                    Id = 2,
                    FirstName = "FirstName2",
                    LastName = "LastName2",
                    IdentificationNumber = "2234567890123",
                    Email = "Email2",
                    Password = "6f9dff5af05096ea9f23cc7bedd65683",
                    PhoneNumber = "2234567890",
                    CreatedDate = DateTime.Now,
                    BirthDate = new DateTime(day: 2, month:2,year:1999),
                    Address = "Address2",
                    City = "City2",
                    Country = "Country2",
                    EmailVerified = false,
                    BannedAccount = false
                },
                new User()
                {
                    Id = 3,
                    FirstName = "FirstName3",
                    LastName = "LastName3",
                    IdentificationNumber = "3234567890123",
                    Email = "Email3",
                    Password = "874fcc6e14275dde5a23319c9ce5f8e4",
                    PhoneNumber = "3234567890",
                    CreatedDate = DateTime.Now,
                    BirthDate = new DateTime(day: 3, month:3,year:1999),
                    Address = "Address3",
                    City = "City3",
                    Country = "Country3",
                    EmailVerified = false,
                    BannedAccount = false
                },
                new User()
                {
                    Id = 4,
                    FirstName = "FirstName4",
                    LastName = "LastName4",
                    IdentificationNumber = "4234567890123",
                    Email = "Email4",
                    Password = "b025a0d0ec287ba8ad0d90f4ff69158f",
                    PhoneNumber = "4234567890",
                    CreatedDate = DateTime.Now,
                    BirthDate = new DateTime(day: 4, month:4,year:1999),
                    Address = "Address4",
                    City = "City4",
                    Country = "Country4",
                    EmailVerified = false,
                    BannedAccount = false
                },
                new User()
                {
                    Id = 5,
                    FirstName = "FirstName5",
                    LastName = "LastName5",
                    IdentificationNumber = "5234567890123",
                    Email = "Email5",
                    Password = "b025a0d0ec287ba8ad0d90f4ff69158f",
                    PhoneNumber = "5234567890",
                    CreatedDate = DateTime.Now,
                    BirthDate = new DateTime(day: 5, month:5,year:1999),
                    Address = "Address5",
                    City = "City5",
                    Country = "Country5",
                    EmailVerified = false,
                    BannedAccount = false
                },
                new User()
                {
                    Id = 6,
                    FirstName = "FirstName6",
                    LastName = "LastName6",
                    IdentificationNumber = "6234567890123",
                    Email = "Email6",
                    Password = "7df5222fb59b99c7c598bee2ef00b85e",
                    PhoneNumber = "6234567890",
                    CreatedDate = DateTime.Now,
                    BirthDate = new DateTime(day: 6, month:6,year:1999),
                    Address = "Address6",
                    City = "City6",
                    Country = "Country6",
                    EmailVerified = false,
                    BannedAccount = false
                },
                new User()
                {
                    Id = 7,
                    FirstName = "FirstName7",
                    LastName = "LastName7",
                    IdentificationNumber = "7234567890123",
                    Email = "Email7",
                    Password = "fabb2e3f5cee3fa92c8a872832d21fec",
                    PhoneNumber = "7234567890",
                    CreatedDate = DateTime.Now,
                    BirthDate = new DateTime(day: 7, month:7,year:1999),
                    Address = "Address7",
                    City = "City7",
                    Country = "Country7",
                    EmailVerified = false,
                    BannedAccount = false
                },
                new User()
                {
                    Id = 8,
                    FirstName = "FirstName8",
                    LastName = "LastName8",
                    IdentificationNumber = "8234567890123",
                    Email = "Email8",
                    Password = "fabb2e3f5cee3fa92c8a872832d21fec",
                    PhoneNumber = "8234567890",
                    CreatedDate = DateTime.Now,
                    BirthDate = new DateTime(day: 8, month:8,year:1999),
                    Address = "Address8",
                    City = "City8",
                    Country = "Country8",
                    EmailVerified = false,
                    BannedAccount = false
                },
                new User()
                {
                    Id = 9,
                    FirstName = "FirstName9",
                    LastName = "LastName9",
                    IdentificationNumber = "9234567890123",
                    Email = "Email9",
                    Password = "fabb2e3f5cee3fa92c8a872832d21fec",
                    PhoneNumber = "9234567890",
                    CreatedDate = DateTime.Now,
                    BirthDate = new DateTime(day: 9, month:9,year:1999),
                    Address = "Address9",
                    City = "City9",
                    Country = "Country9",
                    EmailVerified = false,
                    BannedAccount = false
                }
            };
        }
        public static List<LotteryType> GetLotteryTypeMockData()
        {
            return new List<LotteryType>()
            {
                new LotteryType
                {
                    Id = 1,
                    Title = "6/49",
                    Description = "6 numbers between 1 and 49 are extracted.",
                    ExtractedNumbers = 6,
                    MinimumValue = 1,
                    MaximumValue = 49
                },
                new LotteryType
                {
                    Id = 2,
                    Title = "5/40",
                    Description = "5 numbers between 1 and 40 are extracted",
                    ExtractedNumbers = 5,
                    MinimumValue = 1,
                    MaximumValue = 40
                },
                new LotteryType
                {
                    Id = 3,
                    Title = "Keno",
                    Description = "Jucatorul isi alege 20 numere norocoase dintr-o grila de al 1 la 80.",
                    ExtractedNumbers = 20,
                    MinimumValue = 1,
                    MaximumValue = 80
                }
            };
        }
        public static List<Currency> GetCurrencyMockData()
        {
            return new List<Currency>()
            {
                new Currency
                {
                    Id = 1,
                    CurrencyIndicator = "RON"
                },
                new Currency
                {
                    Id = 2,
                    CurrencyIndicator = "EUR"
                }
            };
        }
        public static List<Prize> GetPrizeMockData()
        {
            return new List<Prize>()
            {
                new Prize
                {
                    Id = 1,
                    MatchedNumbers = 6,
                    LotteryPrizeValue = 3000000,
                    CurrencyId = 1,
                    LotteryTypeId = 1
                },
                new Prize
                {
                    Id = 2,
                    MatchedNumbers = 5,
                    LotteryPrizeValue = 10000,
                    CurrencyId = 1,
                    LotteryTypeId = 1
                },
                new Prize
                {
                    Id = 3,
                    MatchedNumbers = 4,
                    LotteryPrizeValue = 100,
                    CurrencyId = 1,
                    LotteryTypeId = 1
                },
                new Prize
                {
                    Id = 4,
                    MatchedNumbers = 5,
                    LotteryPrizeValue = 1000000,
                    CurrencyId = 1,
                    LotteryTypeId = 2
                },
                new Prize
                {
                    Id = 5,
                    MatchedNumbers = 4,
                    LotteryPrizeValue = 10000,
                    CurrencyId = 1,
                    LotteryTypeId = 2
                },
                new Prize
                {
                    Id = 6,
                    MatchedNumbers = 10,
                    LotteryPrizeValue = 400000,
                    CurrencyId = 2,
                    LotteryTypeId = 3
                },
                new Prize
                {
                    Id = 7,
                    MatchedNumbers = 9,
                    LotteryPrizeValue = 10000,
                    CurrencyId = 2,
                    LotteryTypeId = 3
                }
            };
        }
        public static List<DrawHistory> GetDrawHistoryMockData()
        {
            return new List<DrawHistory>
            {
                new DrawHistory
                {
                    Id = 1,
                    DrawDate = new DateTime(day: 2, month:7,year:2023),
                    ExtractedNumbers = "23,24,31,42,45,49",
                    LotteryTypeId = 1
                },
                new DrawHistory
                {
                    Id = 2,
                    DrawDate = new DateTime(day: 2, month:7,year:2023),
                    ExtractedNumbers = "11,23,25,34,35",
                    LotteryTypeId = 2
                },
                new DrawHistory
                {
                    Id = 3,
                    DrawDate = new DateTime(day: 16, month:7,year:2023),
                    ExtractedNumbers = "7,12,19,23,44,46",
                    LotteryTypeId = 1
                },
                new DrawHistory
                {
                    Id = 4,
                    DrawDate = new DateTime(day: 16, month:7,year:2023),
                    ExtractedNumbers = "1,3,9,12,23",
                    LotteryTypeId = 2
                },
                new DrawHistory
                {
                    Id = 5,
                    DrawDate = new DateTime(day: 23, month:7,year:2023),
                    ExtractedNumbers = "1,3,5,6,9,12,22,24,31,32,36,42,46,49,51,57,63,69,73,76",
                    LotteryTypeId = 3
                }
            };
        }
        public static List<Ticket> GetTicketMockData()
        {
            return new List<Ticket>
            {
                new Ticket
                {
                    Id = 1,
                    NumbersCombination = "2,4,7,9,17,31",
                    BoughtDate = new DateTime(day: 5, month:7,year:2023),
                    PlayedTicket = true,
                    DrawHistoryId = 1,
                    TicketValue = 30,
                    CurrencyId = 1,
                    UserId = 1
                },
                new Ticket
                {
                    Id = 2,
                    NumbersCombination = "3,5,6,12,14,35",
                    BoughtDate = new DateTime(day: 5, month:7,year:2023),
                    PlayedTicket = true,
                    DrawHistoryId = 1,
                    TicketValue = 30,
                    CurrencyId = 1,
                    UserId = 1
                },
                new Ticket
                {
                    Id = 3,
                    NumbersCombination = "4,6,11,19,27",
                    BoughtDate = new DateTime(day: 6, month:7,year:2023),
                    PlayedTicket = true,
                    DrawHistoryId = 1,
                    TicketValue = 20,
                    CurrencyId = 1,
                    UserId = 2
                },
                new Ticket
                {
                    Id = 4,
                    NumbersCombination = "3,5,11,19,31",
                    BoughtDate = new DateTime(day: 5, month:7,year:2023),
                    PlayedTicket = true,
                    DrawHistoryId = 2,
                    TicketValue = 20,
                    CurrencyId = 1,
                    UserId = 1
                },
                new Ticket
                {
                    Id = 5,
                    NumbersCombination = "2,8,15,22,27,34",
                    BoughtDate = new DateTime(day: 7, month:7,year:2023),
                    PlayedTicket = true,
                    DrawHistoryId = 2,
                    TicketValue = 30,
                    CurrencyId = 1,
                    UserId = 2
                },
                new Ticket
                {
                    Id = 6,
                    NumbersCombination = "\"1,3,5,6,9,12,22,24,31,32,44,46,49,54,57,61,68,73,78,80",
                    BoughtDate = new DateTime(day: 5, month:7,year:2023),
                    PlayedTicket = true,
                    DrawHistoryId = 2,
                    TicketValue = 10,
                    CurrencyId = 2,
                    UserId = 5
                },

            };

        }
    }
}
