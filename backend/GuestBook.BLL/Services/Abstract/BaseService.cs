using AutoMapper;
using GuestBook.DAL.Context;

namespace GuestBook.BLL.Services.Abstract;

public abstract class BaseService
{
    private protected readonly GuestBookContext _context;
    private protected readonly IMapper _mapper;

    protected BaseService(GuestBookContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}