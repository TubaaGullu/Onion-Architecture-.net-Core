using MVC_Onion_Project.Application.DTO_s.AuthorDTO_s;
using MVC_Onion_Project.Application.DTO_s.BookDTO_s;
using MVC_Onion_Project.Domain.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Application.Services.BookService
{
    public interface  IBookService
    {
        Task <IDataResult<BookDTO>> AddAsync(BookCreateDTO bookCreateDTO); //create
        Task<IDataResult<List<BookListDTO>>> GetAllAsync(); //index
        Task <IResult> DeleteAsync(Guid id); //delete
        Task<IDataResult<BookDTO>> GetByIdAsync(Guid id); //detail
        Task<IDataResult<BookDTO>> UpdateAsync(BookEditDTO bookEditDto); // update



    }
}
