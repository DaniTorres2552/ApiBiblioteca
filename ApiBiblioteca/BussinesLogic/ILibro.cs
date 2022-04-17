using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBiblioteca.BussinesLogic
{
    internal interface ILibro
    {
        int vIntId { get; set; }
        string vStrTitulo { get; set; }
        DateTime vDtmFecha { get; set; }
        int vIntNumPag { get; set; }
        string vStrAutor { get; set; }

        bool AutorExiste(string pvStrnombre);

        int CantRegistros(DateTime vDtmFecha);




    }
}
