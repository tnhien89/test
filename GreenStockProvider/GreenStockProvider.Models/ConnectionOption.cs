using System;

namespace GreenStockProvider.Models
{
    public class ConnectionOption : IConnectionOption
    {
        public string DbConnectionString { get; set; }
        public string StockMgmtDBName { get; set; }
        public string AppConfigCollectionName { get; set; }
        public string UserCollectionName { get; set; }
        public string StockCandleDBName { get; set; }
        public int CandleUpdateIntervalSecond { get; set; }
        public int BotFightingRunIntervalSecond { get; set; }
    }

    public interface IConnectionOption 
    {
        string DbConnectionString { get; set; }
        string StockMgmtDBName { get; set; }
        string AppConfigCollectionName { get; set; }
        string UserCollectionName { get; set; }
        string StockCandleDBName { get; set; }
        int CandleUpdateIntervalSecond { get; set; }
        int BotFightingRunIntervalSecond { get; set; }
    }
}
