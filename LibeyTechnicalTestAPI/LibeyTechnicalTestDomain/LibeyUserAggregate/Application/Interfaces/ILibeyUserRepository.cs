using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserRepository
    {
        List<LibeyUserResponse> ListResponseBy(string? documentNumber, string? name, string? fathersLastName, string? mothersLastName);
        LibeyUserResponse FindResponse(string documentNumber);
        void Save(LibeyUser libeyUser);
        void Delete(string documentNumber);
    }
}
