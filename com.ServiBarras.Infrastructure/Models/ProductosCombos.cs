using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class ProductosCombos
    {
        public long productoIdCombo { get; set; }
        public long presentacionIdCombo { get; set; }
        public long productoIdDestino { get; set; }
        public long presentacionIdDestino { get; set; }
        public decimal productoComboCantidad { get; set; }
        public byte productoComboEstado { get; set; }

        public virtual Presentaciones presentacionIdComboNavigation { get; set; }
        public virtual Presentaciones presentacionIdDestinoNavigation { get; set; }
        public virtual Productos productoIdComboNavigation { get; set; }
        public virtual Productos productoIdDestinoNavigation { get; set; }
    }
}
