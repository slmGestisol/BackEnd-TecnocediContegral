using System.Collections.Generic;

namespace com.ServiBarras.Shared.ModelDTO
{
    /// <summary>
    /// Filtros de la pantalla de parametrización de ubicaciones.
    /// Los ocho segmentos corresponden a las posiciones del ubicacionCodigo
    /// de 16 caracteres que guarda la base (la etiqueta trae dos más al frente,
    /// el indicativo de aplicación, que el front descarta antes de llamar):
    /// B 1-2 bodega, A 3-4 área, C 5-6 calle, M 7-8 módulo,
    /// N 9-10 nivel, F 11-12 fila, K 13-14 columna, P 15-16 profundidad.
    /// Cada uno llega como CSV ("02" o "02,03") o null para "todos".
    /// </summary>
    public class UbicacionListaFiltroDTO
    {
        public string b { get; set; }
        public string a { get; set; }
        public string c { get; set; }
        public string m { get; set; }
        public string n { get; set; }
        public string f { get; set; }
        public string k { get; set; }
        public string p { get; set; }

        /// <summary>
        /// Instalación sobre la que se parametriza. El grid nunca mezcla
        /// instalaciones: los tipos de la 15009 son otros.
        /// </summary>
        public long? instalacionId { get; set; }

        public string ubicacionCodigo { get; set; }
        public long? tipoUbicacionId { get; set; }
        public int? ubicacionListaId { get; set; }
        public bool? tieneSaldo { get; set; }
    }

    /// <summary>
    /// Valor existente en un segmento, con cuántas ubicaciones lo tienen.
    /// Alimenta los ocho multi-select en cascada.
    /// </summary>
    public class UbicacionListaSegmentoDTO
    {
        public string segmento { get; set; }
        public string valor { get; set; }
        public int ubicaciones { get; set; }
    }

    /// <summary>
    /// Una lista de UbicacionesListas para los checks de la pantalla.
    /// ubicacionListaAyuda trae el significado operativo de las listas que
    /// lo tienen (008 = parciales, 007 = orden de picking).
    /// </summary>
    public class UbicacionListaCatalogoDTO
    {
        public int ubicacionListaId { get; set; }
        public string ubicacionListaCodigo { get; set; }
        public string ubicacionListaNombre { get; set; }
        public string ubicacionListaAyuda { get; set; }
        public int ubicaciones { get; set; }
    }

    /// <summary>
    /// Fila del grid: la ubicación con su tipo, sus listas actuales y su
    /// situación de saldo.
    /// </summary>
    public class UbicacionListaConsultaDTO
    {
        public long ubicacionId { get; set; }
        public string ubicacionCodigo { get; set; }

        public string b { get; set; }
        public string a { get; set; }
        public string c { get; set; }
        public string m { get; set; }
        public string n { get; set; }
        public string f { get; set; }
        public string k { get; set; }
        public string p { get; set; }

        public long? tipoUbicacionId { get; set; }
        public string tipoUbicacionCodigo { get; set; }
        public string listas { get; set; }
        public bool manejaParciales { get; set; }
        public bool tieneSaldo { get; set; }
        public string bodegasLogicasSaldo { get; set; }
    }

    /// <summary>
    /// Lo que la pantalla envía al aplicar: las ubicaciones seleccionadas,
    /// las listas marcadas y el tipo de ubicación a asignar.
    /// </summary>
    public class UbicacionListaAsignacionDTO
    {
        public List<long> ubicaciones { get; set; }
        public List<int> ubicacionListaIds { get; set; }
        public string tipoUbicacionCodigo { get; set; }
        public long usuarioId { get; set; }
    }

    /// <summary>
    /// Resultado de la aplicación. El mensaje viene del @Resultado del
    /// procedimiento, que es el que sabe por qué se rechazó.
    /// </summary>
    public class UbicacionListaRespuestaDTO
    {
        public bool exitoso { get; set; }
        public string mensaje { get; set; }
    }
}
