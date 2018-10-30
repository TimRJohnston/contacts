using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularPhonebookApp.Models.Mappers
{
    public interface IEntityMapper<D, E>
    {
        E ToEntity(D dto);

        D ToDTO(E entity);
    }
}
