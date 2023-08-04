using Microsoft.EntityFrameworkCore;
using SkyWindGroup_TechnicalTest.Entities;

namespace SkyWindGroup_TechnicalTest.Context
{
    public class SkyWindTTContext:DbContext
    {
        public SkyWindTTContext(DbContextOptions<SkyWindTTContext> options):base(options) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<DrawHistory> DrawsHistory { get; set; }
        public DbSet<LotteryType> LotteryTypes { get; set; }
        public DbSet<Prize> Prises { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Table Bonds
            modelBuilder.Entity<Ticket>()
                .HasOne<User>(ticket => ticket.User)
                .WithMany(user => user.Tickets)
                .HasForeignKey(ticket => ticket.UserId);
            modelBuilder.Entity<Ticket>()
                .HasOne<Currency>(ticket => ticket.Currency)
                .WithMany(currency => currency.Tickets)
                .HasForeignKey(ticket => ticket.CurrencyId);
            modelBuilder.Entity<Ticket>()
                .HasOne<DrawHistory>(ticket => ticket.DrawHistory)
                .WithMany(drawHistory => drawHistory.Tickets)
                .HasForeignKey(ticket => ticket.DrawHistoryId)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<DrawHistory>()
                .HasOne<LotteryType>(drawHistory => drawHistory.LotteryType)
                .WithMany(lotteryType => lotteryType.DrawsHistory)
                .HasForeignKey(drawHistory => drawHistory.LotteryTypeId);

            modelBuilder.Entity<Prize>()
                .HasOne<LotteryType>(prize => prize.LotteryType)
                .WithMany(lotteryType => lotteryType.Prises)
                .HasForeignKey(prize => prize.LotteryTypeId);

            modelBuilder.Entity<Prize>()
                .HasOne<Currency>(prize => prize.Currency)
                .WithMany(currency => currency.Prises)
                .HasForeignKey(prize => prize.CurrencyId);

            #endregion
            #region Mock Data
            modelBuilder.Entity<User>().HasData(
                 MockEntries.GetUserMockData()
                 );
            modelBuilder.Entity<LotteryType>().HasData(
                MockEntries.GetLotteryTypeMockData()
                );
            modelBuilder.Entity<Currency>().HasData(
                MockEntries.GetCurrencyMockData()
                );
            modelBuilder.Entity<Prize>().HasData(
                MockEntries.GetPrizeMockData()
                );
            modelBuilder.Entity<DrawHistory>().HasData(
                MockEntries.GetDrawHistoryMockData()
                );
            modelBuilder.Entity<Ticket>().HasData(
                MockEntries.GetTicketMockData()
                );
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
