using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenStockProvider.Models
{
    public class Strategy
    {
        [BsonElement("id")]
        public string Id { get; set; }
        [BsonElement("content")]
        public string Content { get; set; }
        [BsonElement("isSuspended")]
        public bool IsSuspended { get; set; }
        [BsonElement("placeOrderSettings")]
        public StrategyAction PlaceOrderSettings { get; set; }

        public Strategy() : this(Guid.NewGuid().ToString("N"))
        { 
            
        }

        public Strategy(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("Id");
            }

            Id = id;
            PlaceOrderSettings = new StrategyAction();
        }
    }

    public class StrategyAction
    {
        [BsonElement("type")]
        public StrategyActionType Type { get; set; }
        [BsonElement("quantity")]
        public StrategyActionQuantity Quantity { get; set; }
        [BsonElement("orderType")]
        public StrategyActionOrderType OrderType { get; set; }
        [BsonElement("orderLimitPrice")]
        public StrategyActionOrder_Limit Order_Limit_Price { get; set; }
        [BsonElement("dontSellIfLoss")]
        public bool Dont_Sell_If_Loss { get; set; }
        [BsonElement("lossPercent")]
        public double LossPercent { get; set; }

        public StrategyAction()
        {
            Type = StrategyActionType.BUY;
            Quantity = new StrategyActionQuantity();
            OrderType = StrategyActionOrderType.STOP_LIMIT;
            Order_Limit_Price = new StrategyActionOrder_Limit();
            Dont_Sell_If_Loss = true;
            LossPercent = 100000;
        }
    }

    public class StrategyActionQuantity
    {
        [BsonElement("type")]
        public StrategyActionQtyType Type { get; set; }
        [BsonElement("specificQty")]
        public int SpecificQty { get; set; }

        public StrategyActionQuantity()
        {
            Type = StrategyActionQtyType.ALL_FUND;
            SpecificQty = 11;
        }
    }

    public class StrategyActionOrder_Limit 
    {
        [BsonElement("firstPriceType")]
        public StrategyActionOrderPriceType FirstPriceType { get; set; }
        [BsonElement("firstSpecificPrice")]
        public double FirstSpecificPrice { get; set; }
        [BsonElement("secondPriceType")]
        public StrategyActionOrderPriceType SecondPriceType { get; set; }
        [BsonElement("secondSpecificPrice")]
        public double SecondSpecificPrice { get; set; }

        public StrategyActionOrder_Limit()
        {
            FirstPriceType = StrategyActionOrderPriceType.BID;
            FirstSpecificPrice = 25.00;
            SecondPriceType = StrategyActionOrderPriceType.ASK;
            SecondSpecificPrice = 60.50;
        }
    }

    public class StrategyActionOrder_StopLimit
    {
        [BsonElement("firstPrice")]
        public double FirstPrice { get; set; }
        [BsonElement("firstActivationPrice")]
        public double FirstActivationPrice { get; set; }
        [BsonElement("secondPrice")]
        public double SecondPrice { get; set; }
        [BsonElement("secondActivationPrice")]
        public double SecondActivationPrice { get; set; }

        public StrategyActionOrder_StopLimit()
        {
            FirstActivationPrice = 10.10;
            FirstActivationPrice = 15.55;
            SecondPrice = 40.00;
            SecondActivationPrice = 55.55;
        }
    }

    public enum StrategyActionType
    {
        /// <summary>
        /// Buy shares if strategy is matched
        /// </summary>
        BUY = 1,
        /// <summary>
        /// Sell shares if strategy is matched
        /// </summary>
        SELL = 2
    }

    public enum StrategyActionOrderType
    {
        /// <summary>
        /// Sell/buy shares with specific price preset by strategy
        /// </summary>
        LIMIT = 1,
        /// <summary>
        /// Sell/buy shares with a specific price when the share's price reached stop value
        /// </summary>
        STOP_LIMIT = 2
    }

    public enum StrategyActionQtyType
    {
        [Description("Much as possible")]
        ALL_FUND,
        [Description("Specific")]
        LIMIT
    }

    public enum StrategyActionOrderPriceType
    {
        [Description("BID")]
        BID,
        [Description("(BID+ASK)/2")]
        HALF_BID_ASK,
        [Description("ASK")]
        ASK,
        [Description("Specific")]
        SPECIFIC
    }
}
