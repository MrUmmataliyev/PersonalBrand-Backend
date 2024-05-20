﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using PersonalBrand.Application.UseCases.IdentitieCases.Commands;
using PersonalBrand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBrand.Application.UseCases.IdentitieCases.Handlers.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseModel>
    {
        private readonly UserManager<UserModel> _manager;
        private IMediator @object;

        public CreateUserCommandHandler(UserManager<UserModel> manager)
        {
            _manager = manager;
        }

        public CreateUserCommandHandler(IMediator @object)
        {
            this.@object = @object;
        }

        public async Task<ResponseModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UserModel
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
            };

            await _manager.CreateAsync(user, request.Password);
            return new ResponseModel
            {
                Message = "Yaratildi",
                IsSuccess = true,
                StatusCode = 201
            };
        }
    }
}
