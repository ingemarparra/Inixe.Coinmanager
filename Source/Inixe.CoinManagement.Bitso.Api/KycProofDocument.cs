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
        /// <summary>Initializes a new instance of the <see cref="KycProofDocument"/> class.</summary>
        /// <param name="docType">Type of the document.</param>
        /// <param name="stream">The stream.</param>
        /// <param name="fileType">Type of the file.</param>
        /// <exception cref="ArgumentException">Invalid document type - docType</exception>
        /// <exception cref="ArgumentNullException">
        /// stream
        /// or
        /// fileType
        /// </exception>
        public KycProofDocument(KycDocumentType docType, Stream stream, string fileType)
        {
            if (docType == KycDocumentType.None)
            {
                throw new ArgumentException("Invalid document type", nameof(docType));
            }

            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (string.IsNullOrWhiteSpace(fileType))
            {
                throw new ArgumentNullException(nameof(fileType));
            }

            this.DocumentType = docType;
            this.FileType = fileType;
            this.LoadDocument(stream);
        }

        /// <summary>Gets or sets the type of the document.</summary>
        /// <value>The type of the document.</value>
        public KycDocumentType DocumentType { get; set; }

        /// <summary>Gets or sets the type of the file.</summary>
        /// <value>The type of the file.</value>
        public string FileType { get; set; }

        /// <summary>Gets or sets the contents.</summary>
        /// <value>The contents.</value>
        public string Contents { get; set; }

        private void LoadDocument(Stream stream)
        {
            stream.Position = 0;
            using (var reader = new BinaryReader(stream))
            {
                var bytes = reader.ReadBytes(int.MaxValue);
                this.Contents = Convert.ToBase64String(bytes);
            }
        }
    }
}
