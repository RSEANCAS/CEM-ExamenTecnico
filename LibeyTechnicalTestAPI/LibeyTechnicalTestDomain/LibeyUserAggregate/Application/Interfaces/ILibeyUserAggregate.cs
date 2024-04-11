using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserAggregate
    {
        List<LibeyUserResponse> ListResponseBy(string? documentNumber, string? name, string? fathersLastName, string? mothersLastName);
        LibeyUserResponse FindResponse(string documentNumber);
        void Save(UserUpdateorCreateCommand command);
        void Delete(string documentNumber);
    }
}