using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class LibeyUserAggregate : ILibeyUserAggregate
    {
        private readonly ILibeyUserRepository _repository;
        public LibeyUserAggregate(ILibeyUserRepository repository)
        {
            _repository = repository;
        }
        public void Save(UserUpdateorCreateCommand command)
        {
            LibeyUser item = new LibeyUser(command.DocumentNumber, command.DocumentTypeId, command.Name, command.FathersLastName, command.MothersLastName, command.Address, command.UbigeoCode, command.Phone, command.Email, command.Password);
            _repository.Save(item);
        }

        public void Delete(string documentNumber)
        {
            _repository.Delete(documentNumber);
        }

        public List<LibeyUserResponse> ListResponseBy(string? documentNumber, string? name, string? fathersLastName, string? mothersLastName)
        {
            var row = _repository.ListResponseBy(documentNumber, name, fathersLastName, mothersLastName);
            return row;
        }

        public LibeyUserResponse FindResponse(string documentNumber)
        {
            var row = _repository.FindResponse(documentNumber);
            return row;
        }
    }
}