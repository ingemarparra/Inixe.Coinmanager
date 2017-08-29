// -----------------------------------------------------------------------
// <copyright file="BanxicoData.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Class SpeiCda
    /// </summary>
    /// <remarks>Holds the Spei Specific data</remarks>
    public sealed class BanxicoData
    {
        /// <summary>Gets the original string.</summary>
        /// <value>The original string.</value>
        [JsonProperty("cadenaOriginal")]
        public string OriginalString { get; internal set; }

        /// <summary>Gets the payment concept.</summary>
        /// <value>The payment concept.</value>
        [JsonProperty("conceptoPago")]
        public string PaymentConcept { get; internal set; }

        /// <summary>Gets the beneficiary account.</summary>
        /// <value>The beneficiary account.</value>
        [JsonProperty("cuentaBeneficiario")]
        public string BeneficiaryAccount { get; internal set; }

        /// <summary>Gets the ordering account.</summary>
        /// <value>The ordering account.</value>
        [JsonProperty("cuentaOrdenante")]
        public string OrderingAccount { get; internal set; }

        /// <summary>Gets the name of the beneficiary.</summary>
        /// <value>The name of the beneficiary.</value>
        [JsonProperty("nombreBeneficiario")]
        public string BeneficiaryName { get; internal set; }

        /// <summary>Gets the name of the beneficiary insitution.</summary>
        /// <value>The name of the beneficiary insitution.</value>
        [JsonProperty("nombreInstBeneficiaria")]
        public string BeneficiaryInsitutionName { get; internal set; }

        /// <summary>Gets the name of the ordering institution.</summary>
        /// <value>The name of the ordering institution.</value>
        [JsonProperty("nombreInstOrdenante")]
        public string OrderingInstitutionName { get; internal set; }

        /// <summary>Gets the name of the ordering party.</summary>
        /// <value>The name of the ordering party.</value>
        [JsonProperty("nombreOrdenante")]
        public string OrderingPartyName { get; internal set; }

        /// <summary>Gets the numeric reference.</summary>
        /// <value>The numeric reference.</value>
        [JsonProperty("referenciaNumerica")]
        public string NumericReference { get; internal set; }

        /// <summary>Gets the beneficiary taxation number.</summary>
        /// <value>The beneficiary taxation number.</value>
        [JsonProperty("rfcCurpBeneficiario")]
        public string BeneficiaryTaxationNumber { get; internal set; }

        /// <summary>Gets the ordering taxation number.</summary>
        /// <value>The ordering taxation number.</value>
        [JsonProperty("rfcCurpOrdenante")]
        public string OrderingTaxationNumber { get; internal set; }

        /// <summary>Gets the digital stamp.</summary>
        /// <value>The digital stamp.</value>
        [JsonProperty("selloDigital")]
        public string DigitalStamp { get; internal set; }

        /// <summary>Gets the certificate series.</summary>
        /// <value>The certificate series.</value>
        [JsonProperty("serieCertificado")]
        public string CertificateSeries { get; internal set; }

        /// <summary>Gets the type of the operation.</summary>
        /// <value>The type of the operation.</value>
        [JsonProperty("tipoOperacion")]
        public string OperationType { get; internal set; }

        /// <summary>Gets the time.</summary>
        /// <value>The time.</value>
        [JsonProperty("hora")]
        public string Time { get; internal set; }

        /// <summary>Gets the tax.</summary>
        /// <value>The tax.</value>
        [JsonProperty("iva")]
        public decimal Tax { get; internal set; }

        /// <summary>Gets the amount.</summary>
        /// <value>The amount.</value>
        [JsonProperty("monto")]
        public decimal Amount { get; internal set; }

        /// <summary>Gets the type of the payment.</summary>
        /// <value>The type of the payment.</value>
        [JsonProperty("tipoPago")]
        public long PaymentType { get; internal set; }

        /// <summary>Gets the issue date.</summary>
        /// <value>The issue date.</value>
        [JsonProperty("fechaCaptura")]
        public long IssueDate { get; internal set; }

        /// <summary>Gets the operation date.</summary>
        /// <value>The operation date.</value>
        [JsonProperty("fechaOperacion")]
        public long OperationDate { get; internal set; }
    }
}
