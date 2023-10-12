using MVC_Onion_Project.Application.DTO_s;
using MVC_Onion_Project.Application.DTO_s.AuthorDTO_s;
using MVC_Onion_Project.Domain.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Application.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<IDataResult<List<AuthorListDTO>>> GetAllAsync();//index
        Task<IDataResult<AuthorDTO>> GetByIdAsync(Guid id); //detail
        Task<IDataResult<AuthorDTO>> AddAsync(AuthorCreateDTO authorCreateDTO); // create

        Task<IDataResult<AuthorDTO>> UpdateAsync(AuthorEditDTO authoreditDto); // update

        Task<IResult> DeleteAsync(Guid id); // delete




    }
}
