// -----------------------------------------------------------------------
// <copyright file="KeyViewModel.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Desk.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>Class KeyViewModel. </summary>
    /// <remarks>Holds Data for WebAPI</remarks>
    internal class KeyViewModel : INotifyPropertyChanged
    {
        private string apiKey;
        private string apiSecret;

        /// <summary>Occurs when a property value changes.</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>Gets or sets the API key.</summary>
        /// <value>The API key.</value>
        public string ApiKey
        {
            get
            {
                return this.apiKey;
            }

            set
            {
                if (this.apiKey != value)
                {
                    this.apiKey = value;
                    this.OnPropertyChanged("ApiKey");
                    this.OnPropertyChanged("HasKeyPair");
                }
            }
        }

        /// <summary>Gets a value indicating whether this instance has key pair.</summary>
        /// <value><c>true</c> if this instance has key pair; otherwise, <c>false</c>.</value>
        public bool HasKeyPair
        {
            get
            {
                return !(string.IsNullOrWhiteSpace(this.ApiKey) || string.IsNullOrWhiteSpace(this.ApiSecret));
            }
        }

        /// <summary>Gets or sets the API secret.</summary>
        /// <value>The API secret.</value>
        public string ApiSecret
        {
            get
            {
                return this.apiSecret;
            }

            set
            {
                if (this.apiSecret != value)
                {
                    this.apiSecret = value;
                    this.OnPropertyChanged("ApiSecret");
                    this.OnPropertyChanged("HasKeyPair");
                }
            }
        }

        /// <summary>Called when a property has changed.</summary>
        /// <param name="propertyName">Name of the property that triggered the change.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var args = new PropertyChangedEventArgs(propertyName);
            this.PropertyChanged?.Invoke(this, args);
        }
    }
}
