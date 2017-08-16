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
    public class BanxicoData
    {
        /// <summary>Gets or sets the original string.</summary>
        /// <value>The original string.</value>
        [JsonProperty("cadenaOriginal")]
        public string OriginalString { get; set; }

        /// <summary>Gets or sets the payment concept.</summary>
        /// <value>The payment concept.</value>
        [JsonProperty("conceptoPago")]
        public string PaymentConcept { get; set; }

        /// <summary>Gets or sets the beneficiary account.</summary>
        /// <value>The beneficiary account.</value>
        [JsonProperty("cuentaBeneficiario")]
        public string BeneficiaryAccount { get; set; }

        /// <summary>Gets or sets the ordering account.</summary>
        /// <value>The ordering account.</value>
        [JsonProperty("cuentaOrdenante")]
        public string OrderingAccount { get; set; }

        /// <summary>Gets or sets the name of the beneficiary.</summary>
        /// <value>The name of the beneficiary.</value>
        [JsonProperty("nombreBeneficiario")]
        public string BeneficiaryName { get; set; }

        /// <summary>Gets or sets the name of the beneficiary insitution.</summary>
        /// <value>The name of the beneficiary insitution.</value>
        [JsonProperty("nombreInstBeneficiaria")]
        public string BeneficiaryInsitutionName { get; set; }

        /// <summary>Gets or sets the name of the ordering institution.</summary>
        /// <value>The name of the ordering institution.</value>
        [JsonProperty("nombreInstOrdenante")]
        public string OrderingInstitutionName { get; set; }

        /// <summary>Gets or sets the name of the ordering party.</summary>
        /// <value>The name of the ordering party.</value>
        [JsonProperty("nombreOrdenante")]
        public string OrderingPartyName { get; set; }

        /// <summary>Gets or sets the numeric reference.</summary>
        /// <value>The numeric reference.</value>
        [JsonProperty("referenciaNumerica")]
        public string NumericReference { get; set; }

        /// <summary>Gets or sets the beneficiary taxation number.</summary>
        /// <value>The beneficiary taxation number.</value>
        [JsonProperty("rfcCurpBeneficiario")]
        public string BeneficiaryTaxationNumber { get; set; }

        /// <summary>Gets or sets the ordering taxation number.</summary>
        /// <value>The ordering taxation number.</value>
        [JsonProperty("rfcCurpOrdenante")]
        public string OrderingTaxationNumber { get; set; }

        /// <summary>Gets or sets the digital stamp.</summary>
        /// <value>The digital stamp.</value>
        [JsonProperty("selloDigital")]
        public string DigitalStamp { get; set; }

        /// <summary>Gets or sets the certificate series.</summary>
        /// <value>The certificate series.</value>
        [JsonProperty("serieCertificado")]
        public string CertificateSeries { get; set; }

        /// <summary>Gets or sets the type of the operation.</summary>
        /// <value>The type of the operation.</value>
        [JsonProperty("tipoOperacion")]
        public string OperationType { get; set; }

        /// <summary>Gets or sets the time.</summary>
        /// <value>The time.</value>
        [JsonProperty("hora")]
        public string Time { get; set; }

        /// <summary>Gets or sets the tax.</summary>
        /// <value>The tax.</value>
        [JsonProperty("iva")]
        public decimal Tax { get; set; }

        /// <summary>Gets or sets the amount.</summary>
        /// <value>The amount.</value>
        [JsonProperty("monto")]
        public decimal Amount { get; set; }

        /// <summary>Gets or sets the type of the payment.</summary>
        /// <value>The type of the payment.</value>
        [JsonProperty("tipoPago")]
        public long PaymentType { get; set; }

        /// <summary>Gets or sets the issue date.</summary>
        /// <value>The issue date.</value>
        [JsonProperty("fechaCaptura")]
        public long IssueDate { get; set; }

        /// <summary>Gets or sets the operation date.</summary>
        /// <value>The operation date.</value>
        [JsonProperty("fechaOperacion")]
        public long OperationDate { get; set; }
    }
}
