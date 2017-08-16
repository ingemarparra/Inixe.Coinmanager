// -----------------------------------------------------------------------
// <copyright file="Withdrawal.cs" company="GBM">
//   GBM GRUPO BURSÁTIL MEXICANO, S.A DE C.V., CASA DE BOLSA
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public enum TransferStatus
    {
        None,
        Pending,
        Complete,
        Cancelled,
        Processing
    }

    public enum TransferMethod
    {
        None,
        Sp,
        Bitcoin,
        Ether,
    }

    /// <summary>
    /// Class Withdrawal
    /// </summary>
    /// <remarks>None</remarks>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    internal class WithdrawalBase : IWithdrawalBase
    {
        [JsonProperty("wid")]
        public string Id { get; set; }

        public TransferStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Currency { get; set; }

        public TransferMethod Method { get; set; }

        public decimal Amount { get; set; }

        public TransferDetails Details { get; set; }

    }

    internal class TransferDetails : ICrytoCurrencyTransferDetails, ISpeiTransferDetails
    {
        public string WithdrawalAddress { get; set; }
        public string TransferHash { get; set; }
        public string BeneficiaryName { get; set; }
        public string BeneficiaryBank { get; set; }
        public string BeneficiaryClabe { get; set; }
        public string NumericReference { get; set; }
        public string Concept { get; set; }
        public string TrackingCode { get; set; }
    }

    public interface IWithdrawalBase
    {
        [JsonProperty("wid")]
        string Id { get; set; }

        TransferStatus Status { get; set; }

        DateTime CreatedAt { get; set; }

        string Currency { get; set; }

        TransferMethod Method { get; set; }

        decimal Amount { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public interface ICrytoCurrencyTransferDetails
    {
        string WithdrawalAddress { get; set; }

        [JsonProperty("tx_hash")]
        string TransferHash { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public interface ISpeiTransferDetails
    {
        string BeneficiaryName { get; set; }

        string BeneficiaryBank { get; set; }

        string BeneficiaryClabe { get; set; }

        string NumericReference { get; set; }

        [JsonProperty("concept")]
        string Concept { get; set; }

        [JsonProperty("clave_rastreo")]
        string TrackingCode { get; set; }
    }
}
