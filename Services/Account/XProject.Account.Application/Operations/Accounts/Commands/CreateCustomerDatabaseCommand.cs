using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XProject.Account.Domain.Contracts;
using XProject.Shared.Dtos;

namespace XProject.Account.Application.Operations.Accounts.Commands
{
    public class CreateCustomerDatabaseCommand : IRequest<Response<bool>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
    }


    public class CreateCustomerDatabaseResponseHandler : IRequestHandler<CreateCustomerDatabaseCommand, Response<bool>>
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _uof;

        public CreateCustomerDatabaseResponseHandler(IMediator mediator, IUnitOfWork uof)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _uof = uof ?? throw new ArgumentNullException(nameof(uof));
        }

        public async Task<Response<bool>> Handle(CreateCustomerDatabaseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                 await _uof.MigrateDatabase("");
            }
            catch (Exception ex)
            {
                throw;
            }

            return Response<bool>.Success(200);  
        }
    }
}
