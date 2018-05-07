// -----------------------------------------------------------------------
// <copyright file="MarketDataViewModel.cs" company="GBM">
//   GBM GRUPO BURSÁTIL MEXICANO, S.A DE C.V., CASA DE BOLSA
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Desk.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Timers;
    using System.Windows;
    using Inixe.CoinManagement.Bitso.Api;

    /// <summary>Class MarketDataViewModel. </summary>
    /// <remarks>None</remarks>
    internal class MarketDataViewModel : INotifyPropertyChanged
    {
        private readonly BitsoClient publicClient;
        private readonly Timer marketDataTimer;
        private readonly ObservableCollection<Ticker> tickers;

        /// <summary>Initializes a new instance of the <see cref="MarketDataViewModel"/> class.</summary>
        public MarketDataViewModel()
        {
            this.marketDataTimer = new Timer(2000);
            this.marketDataTimer.Elapsed += this.MarketDataTimer_Elapsed;
            this.tickers = new ObservableCollection<Ticker>();
            this.publicClient = new BitsoClient();

            this.marketDataTimer.Start();
            
        }

        /// <summary>Occurs when a property value changes.</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>Gets the tickers.</summary>
        /// <value>The tickers.</value>
        public ObservableCollection<Ticker> Tickers
        {
            get
            {
                return this.tickers;
            }
        }

        /// <summary>Called when a property has changed.</summary>
        /// <param name="propertyName">Name of the property that triggered the change.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var args = new PropertyChangedEventArgs(propertyName);
            this.PropertyChanged?.Invoke(this, args);
        }

        private void MarketDataTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var newTicks = this.publicClient.GetAllTickers();
            Application.Current.Dispatcher.Invoke(() =>
            {
                this.Tickers.Clear();

                foreach (var item in newTicks)
                {
                    this.Tickers.Add(item);
                }
            });

        }
    }
}
