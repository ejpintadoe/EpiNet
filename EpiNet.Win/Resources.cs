using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiNet.Win
{
    class Resources
    {
    }
    public enum MailFolder
    {
        All = 0,
        Announcements = 1,
        ASP = 2,
        WinForms = 4,
        IDETools = 8,
        Frameworks = 16,
        Deleted = 32,
        Custom = 1024
    };
    public enum eOpciones
    {
        Nuevo = 1,
        Editar = 3,
        Regresar = 4,
        SubModulo = 5,
        Buscar = 6,
        Subir = 8,
        Bajar = 9,
        Guardar = 10,
        Cancelar = 11,
        Imprimir = 12,
        Anular = 13

    }
    public enum eTblGen
    {
        GENERO,
        ESTADOCIVIL,
        TIPOENTIDAD,
        TIPOPERSONA,
        PROCEDENCIA,
        TIPOUSO,
        TIPOPAGO,
    }

    public enum eTipoEntidad
    {
        Cliente = 6,
        Proveedor = 7,
    }

}
