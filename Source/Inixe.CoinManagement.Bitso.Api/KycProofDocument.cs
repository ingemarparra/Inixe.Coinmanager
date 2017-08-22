// -----------------------------------------------------------------------
// <copyright file="KycProofDocument.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Document Types
    /// </summary>
    public enum KycDocumentType
    {
        /// <summary>The none value.</summary>
        /// <remarks>This value should never be used. It's declared for initialization purposes only.</remarks>
        None,

        /// <summary>The official identifier</summary>
        OfficialId,

        /// <summary>The proof of residency</summary>
        ProofOfResidency,

        /// <summary>The signed contract</summary>
        SignedContract,

        /// <summary>The origin of fund</summary>
        OriginOfFund,
    }

    /// <summary>
    /// Class KycProofDocument
    /// </summary>
    /// <remarks>None</remarks>
    internal class KycProofDocument
    {
        public KycProofDocument(KycDocumentType docType, Stream stream)
        {

        }

        public KycDocumentType DocumentType { get; set; }

        public string FileType { get; set; }

        public string Contents { get; set; }
    }
}
