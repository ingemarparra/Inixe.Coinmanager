// -----------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="GBM">
//   GBM GRUPO BURSÁTIL MEXICANO, S.A DE C.V., CASA DE BOLSA
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Desk.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Timers;
    using Inixe.CoinManagement.Bitso.Api;

    /// <summary>Class MainViewModel. </summary>
    /// <remarks>None</remarks>
    internal class MainViewModel
    {
        private BitsoClient privateClient;

        public MainViewModel()
        {
            this.Key = new KeyViewModel();
            this.Key.PropertyChanged += this.Key_PropertyChanged;
        }

        private void Key_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            
        }

        /// <summary>Gets or sets the key.</summary>
        /// <value>The key.</value>
        public KeyViewModel Key { get; set; }
    }
}
